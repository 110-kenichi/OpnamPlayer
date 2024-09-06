using OPNAMPlayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace zanac.VGMPlayer
{
    public partial class FormMain : Form, IMessageFilter
    {
        private SerialPort serialPort;

        private Stack<String> dirStack = new Stack<String>();

        private ListViewItem currentSongItem;

        /// <summary>
        /// 
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            listViewList.Columns[0].Width = -2;
            SetHeight(listViewList, SystemInformation.MenuHeight);
            listViewList.ListViewItemSorter = new ListViewIndexComparer(listViewList);

            listingPortNames();

            restoreSettings();
        }

        protected override void OnCreateControl()
        {
            System.Windows.Forms.Application.AddMessageFilter(this);

            base.OnCreateControl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                stopCurrentSong();
                sendCmd("reset fm", 1);
            }
            catch { }
            try
            {
                storeCurrentDir();
                serialPort?.Dispose();
            }
            catch { }

            storeSettings();
        }

        private static int GET_APPCOMMAND_LPARAM(IntPtr lParam)
        {
            return (int)(lParam.ToInt64() >> 16) & 0xFFF;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeConstants.WM_APPCOMMAND:
                    int cmd = GET_APPCOMMAND_LPARAM(m.LParam);
                    switch ((ApplicationCommand)cmd)
                    {
                        case ApplicationCommand.MediaPlay:
                            buttonPlay.PerformClick();
                            goto default;
                        case ApplicationCommand.MediaPlayPause:
                            buttonPlay.PerformClick();
                            goto default;
                        case ApplicationCommand.MediaNexttrack:
                            buttonNext.PerformClick();
                            goto default;
                        case ApplicationCommand.MediaPrevioustrack:
                            buttonPrev.PerformClick();
                            goto default;
                        case ApplicationCommand.MediaStop:
                            buttonStop.PerformClick();
                            goto default;
                        case ApplicationCommand.Close:
                            Close();
                            goto default;
                        default:
                            /* According to MSDN, when handling
                             * this message, we must return TRUE. */
                            m.Result = new IntPtr(1);
                            base.WndProc(ref m);
                            return;
                    }
            }

            base.WndProc(ref m);
        }

        private const int WM_XBUTTONDOWN = 0x020B;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_XBUTTONDOWN)
            {
                var hword = (m.WParam & 0xffff0000) >> 16;

                switch (hword)
                {
                    case 0x0001:    //Back
                        try
                        {
                            var ret = sendCmd("cd ..", 1);

                            String dir = null;
                            if (dirStack.Count != 0)
                            {
                                dir = dirStack.Pop();
                                if (!listingFiles(dir))
                                    dirStack.Push(dir);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        return true;
                    case 0x0002:    //Forward
                        if (currentSongItem != null)
                        {
                            currentSongItem.EnsureVisible();
                            if (currentSongItem.SubItems[1].Text.Equals("<dir>"))
                            {
                                if (currentSongItem.SubItems[0].Text.Contains("?"))
                                    break;

                                if (!currentSongItem.Text.Equals(".."))
                                {
                                    try
                                    {
                                        sendCmd("cd " + currentSongItem.Text, 1);
                                        dirStack.Push(currentSongItem.Text);

                                        if (!listingFiles(null))
                                        {
                                            dirStack.Pop();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="height"></param>
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        /// <summary>
        /// 
        /// </summary>
        private void restoreSettings()
        {
            if (!String.IsNullOrEmpty(Settings.Default.PortName))
            {
                for (int i = 0; i < comboBoxSerial.Items.Count; i++)
                {
                    if (String.Equals(comboBoxSerial.Items[i].ToString(), Settings.Default.PortName))
                    {
                        comboBoxSerial.SelectedIndex = i;
                        break;
                    }
                }
            }

            comboBoxOpmClock.SelectedIndex = Settings.Default.OpmClock;
            comboBoxOpnaClock.SelectedIndex = Settings.Default.OpnaClock;

            comboBoxLight.SelectedIndex = Settings.Default.Light;

            numericUpDownTimeout.Value = Settings.Default.Timeout;

            checkBoxLoop.Checked = Settings.Default.Loop;
            numericUpDownLooped.Value = Settings.Default.LoopCount;

            checkBoxTimer.Checked = Settings.Default.LoopTime;
            try
            {
                dateTimePickerLoopTimes.Value = Settings.Default.LoopTimes;
            }
            catch { }

            checkBoxEnterDir.Checked = Settings.Default.EnterDir;
        }

        /// <summary>
        /// 
        /// </summary>
        private void storeSettings()
        {
            //
            Settings.Default.PortName = "";
            if (comboBoxSerial.SelectedIndex >= 0)
            {
                Settings.Default.PortName = comboBoxSerial.Items[comboBoxSerial.SelectedIndex].ToString();
            }

            Settings.Default.OpmClock = comboBoxOpmClock.SelectedIndex;
            Settings.Default.OpnaClock = comboBoxOpnaClock.SelectedIndex;

            Settings.Default.Light = comboBoxLight.SelectedIndex;

            Settings.Default.Timeout = numericUpDownTimeout.Value;

            Settings.Default.Loop = checkBoxLoop.Checked;
            Settings.Default.LoopCount = numericUpDownLooped.Value;

            Settings.Default.LoopTime = checkBoxTimer.Checked;
            Settings.Default.LoopTimes = dateTimePickerLoopTimes.Value;

            Settings.Default.EnterDir = checkBoxEnterDir.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listViewList.SelectedItems.Count != 0)
            {
                playSelectedItem(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopCurrentSong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (currentSongItem != null)
                idx = currentSongItem.Index;
            if (idx < 0 && listViewList.Items.Count != 0)
            {
                var item = listViewList.Items[0];
                item.Selected = true;
                playSelectedItem(checkBoxEnterDir.Checked);
            }
            else
            {
                idx--;
                if (idx < 0)
                    idx = listViewList.Items.Count - 1;

                var item = listViewList.Items[idx];
                item.Selected = true;
                playSelectedItem(checkBoxEnterDir.Checked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            int idx = 0;
            if (currentSongItem != null)
                idx = currentSongItem.Index;
            if (idx < 0 && listViewList.Items.Count != 0)
            {
                var item = listViewList.Items[0];
                item.Selected = true;
                playSelectedItem(checkBoxEnterDir.Checked);
            }
            else
            {
                idx++;
                if (idx >= listViewList.Items.Count)
                    idx = 0;

                var item = listViewList.Items[idx];
                item.Selected = true;
                playSelectedItem(checkBoxEnterDir.Checked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canenterDir"></param>
        private void playSelectedItem(bool canenterDir)
        {
            if (currentSongItem != null)
            {
                var item = listViewList.Items[currentSongItem.Index];
                item.Selected = true;
                item.EnsureVisible();
                if (item.SubItems[1].Text.Equals("<dir>"))
                {
                    if (canenterDir)
                    {
                        if (item.SubItems[0].Text.Contains("?"))
                            return;

                        try
                        {
                            bool popped = false;
                            sendCmd("cd " + item.Text, 1);

                            String dir = null;
                            if (item.Text.Equals(".."))
                            {
                                if (dirStack.Count != 0)
                                {
                                    dir = dirStack.Pop();
                                    popped = true;
                                }
                            }
                            else
                            {
                                dirStack.Push(item.Text);
                            }

                            if (!listingFiles(dir))
                            {
                                if (item.Text.Equals(".."))
                                {
                                    if (popped)
                                        dirStack.Push(dir);
                                }
                                else
                                {
                                    dirStack.Pop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    playFile(currentSongItem.Text);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private void playFile(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            try
            {
                switch (ext.ToUpper())
                {
                    case ".MML":
                    case ".VGM":
                    case ".MDX":
                    case ".S98":
                        break;
                    default:
                        return;
                }
                stopTimer();
                setLight();
                sendCmd("play " + fileName, 1);
                setOpmClock();
                setOpnaClock();

                string[] dirs = new string[dirStack.Count];
                dirStack.CopyTo(dirs, 0);
                StringBuilder fullpath = new StringBuilder();
                foreach (string dir in dirs.Reverse())
                {
                    fullpath.Append(dir);
                    fullpath.Append(Path.DirectorySeparatorChar);
                }
                fullpath.Append(fileName);

                textBoxTitle.Text = fullpath.ToString();
                startTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int loopCount;

        /// <summary>
        /// 
        /// </summary>
        private void startTimer()
        {
            loopCount = 0;
            toolStripStatusLabelElapse.Text = "00:00";
            timer1.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void stopCurrentSong()
        {
            textBoxTitle.Text = string.Empty;

            try
            {
                sendCmd("stop", 1);
                stopTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void stopTimer()
        {
            timer1.Stop();
            toolStripStatusLabelElapse.Text = "00:00";
            loopCount = 0;
        }

        private void listViewList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                playSelectedItem(true);
            }
        }
        private void listViewList_DoubleClick(object sender, EventArgs e)
        {
            playSelectedItem(true);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                switch (e.KeyCode)
                {
                    //矢印キーが押されたことを表示する
                    case Keys.Z:
                        buttonPrev_Click(null, null);
                        e.Handled = true;
                        break;
                    case Keys.X:
                        buttonPlay_Click(null, null);
                        e.Handled = true;
                        break;
                    case Keys.C:
                        buttonNext_Click(null, null);
                        e.Handled = true;
                        break;
                    case Keys.V:
                        buttonStop_Click(null, null);
                        e.Handled = true;
                        break;
                }
            }
        }

        private void listViewList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            foreach (ColumnHeader ch in listViewList.Columns)
                ch.Text = ch.Text.Replace(" ▼", "").Replace(" ▲", "");
            string cn = listViewList.Columns[e.Column].Text;

            ListViewIndexComparer c = listViewList.ListViewItemSorter as ListViewIndexComparer;
            if (c == null)
                listViewList.ListViewItemSorter = new ListViewIndexComparer(listViewList);
            c = listViewList.ListViewItemSorter as ListViewIndexComparer;
            c.SortColumn = e.Column;

            switch (listViewList.Sorting)
            {
                case SortOrder.Ascending:
                    listViewList.Sorting = SortOrder.Descending;
                    listViewList.Columns[e.Column].Text = cn + " ▼";
                    break;
                case SortOrder.Descending:
                    listViewList.Sorting = SortOrder.None;
                    break;
                case SortOrder.None:
                    listViewList.Sorting = SortOrder.Ascending;
                    listViewList.Columns[e.Column].Text = cn + " ▲";
                    break;
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playSelectedItem(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private class ListViewIndexComparer : System.Collections.IComparer
        {
            public int SortColumn
            {
                get;
                set;
            }

            private ListView listView;

            public ListViewIndexComparer(ListView listView)
            {
                this.listView = listView;
            }

            public int Compare(object x, object y)
            {
                int xv;
                if (int.TryParse(((ListViewItem)x).SubItems[SortColumn].Text, out xv))
                {
                    int yv;
                    if (int.TryParse(((ListViewItem)y).SubItems[SortColumn].Text, out yv))
                    {
                        if (listView.Sorting == SortOrder.Ascending)
                            return xv - yv;
                        else if (listView.Sorting == SortOrder.Descending)
                            return yv - xv;
                        else
                            return 0;
                    }
                }

                {
                    if (listView.Sorting == SortOrder.Ascending)
                        return ((ListViewItem)x).SubItems[SortColumn].Text.CompareTo(((ListViewItem)y).SubItems[SortColumn].Text);
                    else if (listView.Sorting == SortOrder.Descending)
                        return ((ListViewItem)y).SubItems[SortColumn].Text.CompareTo(((ListViewItem)x).SubItems[SortColumn].Text);
                    else
                        return 0;
                }
            }
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout ab = new FormAbout();
            ab.VersionText = this.Text;
            ab.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private void setStatusText(string text)
        {
            toolStripStatusLabel.Text = text;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                if (comboBoxSerial.SelectedItem != null)
                {
                    try
                    {
                        serialPort = new SerialPort(comboBoxSerial.SelectedItem.ToString());
                        serialPort.ReadTimeout = (int)Settings.Default.Timeout;
                        serialPort.Open();
                        buttonConnect.Text = "Dis&connect";

                        sendCmd("sd init", 1);
                        string line2 = serialPort.ReadLine();
                        setStatusText(line2);
                        if (!line2.Equals("sd initialized"))
                            return;

                        sendCmd("reset fm", 1);
                        setLight();

                        dirStack.Clear();
                        sendCmd("sd dir", 1);
                        listingFiles(null);

                        restoreCurrentDir();
                    }
                    catch (Exception ex)
                    {
                        serialPort?.Dispose();
                        serialPort = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                storeCurrentDir();
                dirStack.Clear();

                try
                {
                    stopCurrentSong();
                    sendCmd("reset fm", 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    serialPort?.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                serialPort = null;
                buttonConnect.Text = "&Connect";
                listViewList.Items.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void storeCurrentDir()
        {
            StringCollection sc = new StringCollection();
            foreach (var d in dirStack.ToArray())
                sc.Add(d);
            Settings.Default.Dirs = sc;

            if (currentSongItem != null)
                Settings.Default.CurrentSong = currentSongItem.Text;
            else
                Settings.Default.CurrentSong = null;
        }

        /// <summary>
        /// 
        /// </summary>
        private void restoreCurrentDir()
        {
            try
            {
                if (Settings.Default.Dirs != null)
                {
                    StringCollection sc = Settings.Default.Dirs;
                    List<String> scl = new List<string>();
                    foreach (var d in sc)
                        scl.Add(d);
                    try
                    {
                        listViewList.BeginUpdate();
                        foreach (var d in scl.ToArray().Reverse())
                        {
                            sendCmd("cd " + d, 1);
                            dirStack.Push(d);
                            if (!listingFiles(null))
                            {
                                dirStack.Pop();
                                return;
                            }
                        }
                    }
                    finally
                    {
                        listViewList.EndUpdate();
                    }
                }

                if (Settings.Default.CurrentSong != null)
                {
                    foreach (ListViewItem i in listViewList.Items)
                    {
                        if (String.Equals(i.Text, Settings.Default.CurrentSong, StringComparison.OrdinalIgnoreCase))
                        {
                            i.Selected = true;
                            i.EnsureVisible();
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectDir"></param>
        /// <returns></returns>
        private bool listingFiles(String selectDir)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            String line = null;
            do
            {
                try
                {
                    line = serialPort.ReadLine();
                    if (line != null && line.Length >= 46)
                    {
                        ListViewItem lvi = new ListViewItem(
                            //FIRMWA~4.HEX    1141608  2024/05/25 23:14:00  FIRMWARE_263b.hex
                            //0123456789
                            //          0123456789
                            //                    0123456789
                            //                              0123456789
                            //                                        0123456789
                            new String[]
                            {
                                    line.Substring(0, 8).Trim() + line.Substring(8, 4).Trim(),
                                    line.Substring(12, 11).Trim(),
                                    line.Substring(23, 21).Trim(),
                                    line.Substring(44, line.Length - 44).Trim()
                            });
                        if (String.Equals(lvi.Text, "."))
                            continue;

                        if (lvi.SubItems[1].Text.Equals("<dir>"))
                        {
                            if (selectDir != null && String.Equals(selectDir, lvi.Text))
                            {
                                lvi.Selected = true;
                            }
                            items.Add(lvi);
                        }
                        else
                        {
                            string ext = Path.GetExtension(lvi.Text);
                            switch (ext.ToUpper())
                            {
                                case ".MML":
                                case ".VGM":
                                case ".MDX":
                                case ".S98":
                                    if (selectDir != null && String.Equals(selectDir, lvi.Text))
                                        lvi.Selected = true;
                                    items.Add(lvi);
                                    break;
                            }
                        }
                    }
                }
                catch (TimeoutException)
                {
                    break;
                }
            } while (line != null);

            if (items.Count == 0)
                return false;

            try
            {
                listViewList.BeginUpdate();

                listViewList.Items.Clear();
                listViewList.Items.AddRange(items.ToArray());
            }
            finally
            {
                if (listViewList.SelectedItems.Count == 0 && listViewList.Items.Count > 0)
                    listViewList.Items[0].Selected = true;

                foreach (ColumnHeader col in listViewList.Columns)
                    col.Width = -1;

                foreach (ColumnHeader col in listViewList.Columns)
                    col.Width = col.Width + 10;

                listViewList.EndUpdate();

                if (listViewList.SelectedItems.Count > 0)
                {
                    listViewList.SelectedItems[0].EnsureVisible();
                    listViewList.FocusedItem = listViewList.SelectedItems[0];
                }
            }

            return true;
        }

        private void comboBoxSerial_DropDown(object sender, EventArgs e)
        {
            listingPortNames();
        }

        private void listingPortNames()
        {
            String cport = null;
            if (comboBoxSerial.SelectedIndex >= 0)
            {
                cport = comboBoxSerial.Items[comboBoxSerial.SelectedIndex].ToString();
            }

            comboBoxSerial.Items.Clear();
            foreach (var port in SerialPort.GetPortNames())
            {
                int si = comboBoxSerial.Items.Add(port);

                if (port.Equals(cport))
                    comboBoxSerial.SelectedIndex = si;
            }
        }

        private void listViewList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            currentSongItem = e.Item;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                buttonStop_Click(null, null);
                sendCmd("reset fm", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="dummyReads"></param>
        private List<String> sendCmd(string cmd, int readLineCount, bool outputRetvalue = true)
        {
            if (outputRetvalue)
                setStatusText(String.Empty);
            List<String> returns = new List<string>();
            if (serialPort != null)
            {
                serialPort.WriteLine(cmd);
                returns.AddRange(readLines(readLineCount, outputRetvalue));
            }
            return returns;
        }

        private List<String> readLines(int readLineCount, bool outputRetvalue)
        {
            List<String> returns = new List<string>();

            for (int i = 0; i < readLineCount; i++)
            {
                int tryCount = 3;
                for (int j = 0; j < tryCount; j++)
                {
                    try
                    {
                        String line = serialPort.ReadLine();
                        if (outputRetvalue)
                            setStatusText(line);
                        returns.Add(line);
                        break;
                    }
                    catch (TimeoutException ex)
                    {
                        Thread.Sleep(300);
                        if (j + 1 == tryCount)
                            throw ex;
                    }
                }
            }

            return returns;
        }

        /// <summary>
        /// 
        /// </summary>
        private void setOpmClock()
        {

            switch (comboBoxOpmClock.SelectedIndex)
            {
                case 1:
                    sendCmd("clock 2151 3.57", 1);
                    break;
                case 2:
                    sendCmd("clock 2151 4", 1);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void setOpnaClock()
        {

            switch (comboBoxOpnaClock.SelectedIndex)
            {
                case 1:
                    sendCmd("clock 2608 7.98", 1);
                    break;
                case 2:
                    sendCmd("clock 2608 8", 1);
                    break;
            }

        }

        private void setLight()
        {
            switch (comboBoxLight.SelectedIndex)
            {
                case 0:
                    //sendCmd("led off", 1);
                    sendCmd("lcd light off", 1);
                    sendCmd("oled off", 1);
                    break;
                case 1:
                    //sendCmd("led on", 1);
                    sendCmd("lcd light on", 1);
                    sendCmd("oled on", 1);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var returns = sendCmd("play", 2, false);
                if (returns.Count == 2)
                {
                    if (returns[1].Equals("playing..."))
                    {
                        returns = readLines(2, false);
                        if (returns.Count == 2)
                        {
                            toolStripStatusLabelElapse.Text = returns[1];

                            if (checkBoxTimer.Checked)
                            {
                                try
                                {
                                    TimeSpan elapsed = TimeSpan.Parse(toolStripStatusLabelElapse.Text);
                                    if (elapsed > TimeSpan.Parse(dateTimePickerLoopTimes.Text))
                                    {
                                        buttonNext_Click(null, null);
                                    }
                                }
                                catch { };
                            }
                        }
                    }
                    else if (returns[1].Equals("Not playing"))
                    {
                        buttonNext_Click(null, null);
                    }
                }
            }
            catch (TimeoutException)
            {

            }
        }
    }

    internal static class NativeConstants
    {
        public const int WM_APPCOMMAND = 0x0319;
    }

    internal enum ApplicationCommand
    {
        VolumeMute = 8,
        VolumeDown = 9,
        VolumeUp = 10,
        MediaNexttrack = 11,
        MediaPrevioustrack = 12,
        MediaStop = 13,
        MediaPlayPause = 14,
        Close = 31,
        MediaPlay = 46,
        MediaPause = 47,
        MediaFastForward = 49,
        MediaRewind = 50
    }

}
