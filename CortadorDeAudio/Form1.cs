using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace CortadorDeAudio
{
    public partial class Form1 : Form
    {
        private IAudioPlayer _audioPlayer;
        private IAudioTools _audioTools;
        private System.Timers.Timer _timer;
        private BindingList<Interval> _intervals;
        private Interval _interval;

        public Form1()
        {
            InitializeComponent();            

            SetPlayer();

            SetTimer();

            SetGrid();
        }

        private void SetPlayer()
        {
            _audioPlayer = new AudioPlayer();
            _audioPlayer.OnPlayerEnds += _audioPlayer_OnPlayerEnds;
            _audioTools = new AudioTools();
        }

        private void SetTimer()
        {
            _timer = new System.Timers.Timer
            {
                Interval = 50
            };

            _timer.Elapsed += Timer_Elapsed;
        }

        private void SetGrid()
        {
            _intervals = new BindingList<Interval>();
            dataGridView.DataSource = _intervals;

            dataGridView.Columns["Begin"].DefaultCellStyle.Format = Extensions.stringFormat;
            dataGridView.Columns["End"].DefaultCellStyle.Format = Extensions.stringFormat;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                _audioPlayer.Play();

                CheckTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to play the music! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                _audioPlayer.Pause();

                CheckTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to pause the music! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void _audioPlayer_OnPlayerEnds(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            try
            {
                _audioPlayer.Stop();

                CheckTimer();

                ResetInterval();

                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to stop the music! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckTimer()
        {
            if (_audioPlayer.PlayerStatus == PlayerStatus.Playing)
                _timer.Start();
            else
                _timer.Stop();
        }

        private void buttonInicialPosition_Click(object sender, EventArgs e)
        {
            try
            {
                var currentTimeString = _audioPlayer.GetMusicCurrentTime();

                txtInitialTime.Text = currentTimeString.ToStringFormat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to update the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFinalPosition_Click(object sender, EventArgs e)
        {
            try
            {
                var currentTimeString = _audioPlayer.GetMusicCurrentTime().ToStringFormat();

                txtFinalTime.Text = currentTimeString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to update the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddInterval_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFormInterval();

                _intervals.Add(new Interval(txtInitialTime.Text.ToTimeSpan(), txtFinalTime.Text.ToTimeSpan()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateInterval_Click(object sender, EventArgs e)
        {
            try
            {
                var formInterval = GetFormInterval();
                var interval = GetSelectedInterval();

                interval.Begin = formInterval.Begin;
                interval.End = formInterval.End;

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to update the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckFormInterval()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text))
                throw new Exception("Choose an initial time!");

            if (string.IsNullOrEmpty(txtFinalTime.Text))
                throw new Exception("Choose a final time!");

            var begin = txtInitialTime.Text.ToTimeSpan();
            var end = txtFinalTime.Text.ToTimeSpan();

            if (begin >= end)
                throw new Exception("Final time must be greater than inicial time!");

            if (end - begin < new TimeSpan(0,0,0,1))
                throw new Exception("Interval must have at least a second!");

            if (begin >= _audioPlayer.GetMusicTotalTime() ||
                end >= _audioPlayer.GetMusicTotalTime() ||
                begin < TimeSpan.Zero || end < TimeSpan.Zero)
                throw new Exception("The selected interval is out of bound!");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckExecutingInterval();           

            UpdateProgressBarPosition();

            UpdateTimeLabel();
        }

        private void CheckExecutingInterval()
        {
            if (_interval != null && _audioPlayer.GetMusicCurrentTime() > _interval.End)
            {
                _audioPlayer.SetMusicCurrentTime(_interval.Begin);
            }
        }
        private void UpdateProgressBarPosition()
        {
            var currentTime = _audioPlayer.GetMusicCurrentTime();

            var totalTime = _audioPlayer.GetMusicTotalTime();

            var position = (int)((currentTime.TotalMilliseconds / totalTime.TotalMilliseconds) * progressBar.Maximum);

            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke((MethodInvoker)delegate
                {
                    if (position > progressBar.Maximum)
                        Stop();
                    else
                        progressBar.Value = position;
                });
            }
        }

        private void UpdateTimeLabel()
        {
            if (timeLabel.InvokeRequired)
            {
                timeLabel.BeginInvoke((MethodInvoker)delegate
                {
                    timeLabel.Text = GetTimeLabelText();
                });
            }
        }

        public string GetTimeLabelText()
        {
            return $"{_audioPlayer.GetMusicCurrentTime().ToStringFormat()}/{_audioPlayer.GetMusicTotalTime().ToStringFormat()}";
        }

        private void UpdateIntervalLength()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text) || string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var intervalLength = txtFinalTime.Text.ToTimeSpan() - txtInitialTime.Text.ToTimeSpan();

            txtintervalLength.Text = intervalLength.ToStringFormat();
        }

        private void ButtonSkipForward_Click(object sender, EventArgs e)
        {
            _audioPlayer.SkipForward(new TimeSpan(0, 0, 0, 0, 3000));
        }

        private void ButtonSkipBackward_Click(object sender, EventArgs e)
        {
            _audioPlayer.SkipBackward(new TimeSpan(0, 0, 0, 0, 3000));
        }

        private void buttonInicialIncreaseTime_Click(object sender, EventArgs e)
        {
            try
            {
                txtInitialTime.Text = UpdateTimeString(txtInitialTime.Text, 100);

                if (ExecutingInterval())
                    ExecuteFormInterval();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to execute the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInicialDecreaseTime_Click(object sender, EventArgs e)
        {
            try
            {
                txtInitialTime.Text = UpdateTimeString(txtInitialTime.Text, -100);

                if (ExecutingInterval())
                    ExecuteFormInterval();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to execute the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFinalIncreaseTime_Click(object sender, EventArgs e)
        {
            try
            {
                txtFinalTime.Text = UpdateTimeString(txtFinalTime.Text, 100);

                if (ExecutingInterval())
                {
                    ExecuteFormInterval();

                    _audioPlayer.SkipBackward(new TimeSpan(0, 0, 0, 0, 500));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to execute the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFinalDecreaseTime_Click(object sender, EventArgs e)
        {
            try
            {
                txtFinalTime.Text = UpdateTimeString(txtFinalTime.Text, -100);

                if (ExecutingInterval())
                {
                    ExecuteFormInterval();

                    _audioPlayer.SkipBackward(new TimeSpan(0, 0, 0, 0, 500));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to execute the interval! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string UpdateTimeString(string time, int milliseconds)
        {
            if (string.IsNullOrEmpty(time))
                return time;

            var newTime = time.ToTimeSpan().Add(new TimeSpan(0, 0, 0, 0, milliseconds));

            return newTime >= _audioPlayer.GetMusicTotalTime() ? time : newTime.ToStringFormat();
        }

        private void buttonExecuteInterval_Click(object sender, EventArgs e)
        {
            if (!_audioPlayer.MusicLoaded)
                return;

            ExecuteFormInterval();
        }

        private void buttonStopExecuteInterval_Click(object sender, EventArgs e)
        {
           ResetInterval();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            UpdateIntervalLength();
        }

        private Interval GetSelectedInterval()
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index ?? -1;

            if (currentRowIndex < 0)
                throw new Exception("Select a line!");

            return _intervals[currentRowIndex];
        }

        private Interval GetFormInterval()
        {
            CheckFormInterval();

            var begin = txtInitialTime.Text.ToTimeSpan();
            var end = txtFinalTime.Text.ToTimeSpan();

            return new Interval(begin, end);
        }

        private void buttonRemoveInterval_Click(object sender, EventArgs e)
        {
            var intervalo = GetSelectedInterval();

            _intervals.Remove(intervalo);

            if(intervalo == _interval)
               ResetInterval();

            dataGridView.Refresh();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (!_intervals.Any())
                return;

            try
            {
                var intervalo = GetSelectedInterval();

                if (intervalo == null)
                    return;

                AtualizarIntervaloDaTela(intervalo);

                ExecuteFormInterval();
            }
            catch (Exception ex)
            {
                ResetInterval();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarIntervaloDaTela(Interval intervalo)
        {
            txtInitialTime.Text = intervalo.Begin.ToStringFormat();

            txtFinalTime.Text = intervalo.End.ToStringFormat();
        }

        private void ExecuteFormInterval()
        {
            try
            {
                SetInterval(GetFormInterval());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to execute the interval - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetInterval(Interval interval)
        {
            _interval = interval;

            _audioPlayer.SetMusicCurrentTime(interval.Begin);            
        }

        private void ResetInterval()
        {
            _interval = null;           
        }

        private bool ExecutingInterval()
        {
            return _interval != null;
        }

        private void volumeControl_ValueChanged(object sender, EventArgs e)
        {
            UpdateVolume();
        }

        private void UpdateVolume()
        {
            var volumeRate = (float)volumeControl.Value / volumeControl.Maximum;

            _audioPlayer.SetVolume(volumeRate);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var theDialog = new OpenFileDialog
            {
                Title = "Select a MP3 file",
                Filter = "MP3 files|*.mp3"
            };
            if (theDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                _audioPlayer.LoadMusic(theDialog.FileName);

                Text = theDialog.FileName;

                _intervals.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error trying to open the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadIntervalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var theDialog = new OpenFileDialog
            {
                Title = "Select a file with the intervals",
                Filter = "txt files|*.txt"
            };

            if (theDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var filelines = File.ReadAllLines(theDialog.FileName);

                var newIntervals = new List<Interval>();

                foreach (var line in filelines)
                {
                    var lineSplitted = line.Split(';');

                    var interval = new Interval(lineSplitted[0].ToTimeSpan(), lineSplitted[1].ToTimeSpan());

                    newIntervals.Add(interval);
                }

                foreach (var newInterval in newIntervals)
                {
                    _intervals.Add(newInterval);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error trying to load the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveIntervalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_intervals.Any())
                throw new Exception("There is no intervals to save!");

            var fileBuilder = new StringBuilder();

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Select a folder to save the file!",
                Filter = "txt files|*.txt"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                foreach (var intervalo in _intervals)
                {
                    fileBuilder.Append($"{intervalo.Begin.ToStringFormat()}; {intervalo.End.ToStringFormat()}");
                }

                File.WriteAllText(saveFileDialog.FileName, fileBuilder.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error trying to save the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_audioPlayer.MusicLoaded)
                throw new Exception("There is no opened file!");

            if (!_intervals.Any())
                throw new Exception("There is no opened file!");

            var folderBrowser = new FolderBrowserDialog
            {
                Description = "Select a folder to save the file!",
            };

            if (folderBrowser.ShowDialog() != DialogResult.OK) return;

            var fileInfo = new FileInfo(_audioPlayer.MusicFileName);

            var fileNameSufix = 1;

            string GetNextFileName()
            {
                var name = $"{folderBrowser.SelectedPath}\\" +
                           $"{fileInfo.Name.Replace(fileInfo.Extension, $"_part{fileNameSufix++}{fileInfo.Extension}")}";

                return File.Exists(name) ? GetNextFileName() : name;
            }

            foreach (var interval in _intervals)
            {
                _audioTools.TrimAudio(_audioPlayer.MusicFileName, GetNextFileName(), interval.Begin, interval.End);
            }
        }
    }
}
