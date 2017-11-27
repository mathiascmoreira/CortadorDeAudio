using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;

namespace CortadorDeAudio
{
    public partial class Form1 : Form
    {
        private readonly IAudioPlayer _audioPlayer;
        private System.Timers.Timer _timer;        
        private BindingList<Intervalo> _intervalos;
        
        public Form1()
        {
            InitializeComponent();

            _audioPlayer = new AudioPlayer();
            progressBar.Maximum = 1000;
            _intervalos = new BindingList<Intervalo>();          

            dataGridView.DataSource = _intervalos;

            _audioPlayer.OnPlayerEnds += _audioPlayer_OnPlayerEnds;

            SetTimer();
        }

        private void SetTimer()
        {
            _timer = new System.Timers.Timer
            {
                Interval = 50
            };

            _timer.Elapsed += Timer_Elapsed;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            _audioPlayer.Play();

            CheckTimer();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            _audioPlayer.Pause();

            CheckTimer();
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
            _audioPlayer.Stop();

            CheckTimer();

            progressBar.Value = 0;
        }

        private void buttonInicialPosition_Click(object sender, EventArgs e)
        {
            var currentTimeString = GetTimeSpanString(_audioPlayer.GetMusicCurrentTime());

            txtInitialTime.Text = currentTimeString;
        }

        private void buttonFinalPosition_Click(object sender, EventArgs e)
        {
            var currentTimeString = GetTimeSpanString(_audioPlayer.GetMusicCurrentTime());

            txtFinalTime.Text = currentTimeString;
        }

        private void buttonAddInterval_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInitialTime.Text))
                    throw new Exception("Selecione um tempo inicial!");

                if (string.IsNullOrEmpty(txtFinalTime.Text))
                    throw new Exception("Selecione um tempo final!");

                if(GetTimeSpanFromString(txtInitialTime.Text) >= GetTimeSpanFromString(txtFinalTime.Text))
                    throw new Exception("Tempo final deve ser maior que o inicial!");

                _intervalos.Add(new Intervalo(txtInitialTime.Text, txtFinalTime.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var playerPosition = _audioPlayer.GetPosition();

            var progressBarPosition = Convert.ToInt32(decimal.Floor(_audioPlayer.GetPosition() * progressBar.Maximum));

            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke((MethodInvoker)delegate
                {
                    if (progressBarPosition > progressBar.Maximum)
                        Stop();
                    else
                        progressBar.Value = progressBarPosition;
                });
            }

            if (timeLabel.InvokeRequired)
            {
                timeLabel.BeginInvoke((MethodInvoker)delegate
                {
                    timeLabel.Text = GetTimeLabelText();
                });
            }
        }

        private void StripMenuItemOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var theDialog = new OpenFileDialog
                {
                    Title = "Select a MP3 file",
                    Filter = "MP3 files|*.mp3"
                };
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    _audioPlayer.LoadMusic(theDialog.FileName);

                    Text = theDialog.FileName;

                    _intervalos.Clear();               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o arquivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetTimeLabelText()
        {
            return $"{GetTimeSpanString(_audioPlayer.GetMusicCurrentTime())}/{GetTimeSpanString(_audioPlayer.GetMusicTotalTime())}";
        }

        public string GetTimeSpanString(TimeSpan timeSpan)
        {
            var timeInMinutes = AddLeftZeroIfNeeded(timeSpan.Minutes);
            var timeInSeconds = AddLeftZeroIfNeeded(timeSpan.Seconds);
            var timeInMilliseconds = AddLeftZeroIfNeeded(timeSpan.Milliseconds, 3);

            return $"{ timeInMinutes}:{ timeInSeconds}:{ timeInMilliseconds}";
        }

        public TimeSpan GetTimeSpanFromString(string timeSpanString)
        {
            try
            {
                var splittedString = timeSpanString.Split(':');

                var minutes = Convert.ToInt32(splittedString[0]);
                var seconds = Convert.ToInt32(splittedString[1]);
                var milliseconds = Convert.ToInt32(splittedString[2]);

                return new TimeSpan(0, 0, minutes, seconds, milliseconds);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar obter TimeSpan!");
            }
        }

        private string AddLeftZeroIfNeeded(int time, int size = 2)
        {
            var timeString = time.ToString();

            while (timeString.Length < size)
                timeString = $"0{timeString}";

            return timeString;
        }

        private void CheckTimer()
        {
            if (_audioPlayer.PlayerStatus == PlayerStatus.Playing)
                _timer.Start();
            else
                _timer.Stop();
        }

        private void txtInitialTime_TextChanged(object sender, EventArgs e)
        {
            UpdateTamanhoDoIntervalo();
        }       

        private void txtFinalTime_TextChanged(object sender, EventArgs e)
        {
            UpdateTamanhoDoIntervalo();
        }

        private void UpdateTamanhoDoIntervalo()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text) || string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var tamanhoDoIntervalo = GetTimeSpanFromString(txtFinalTime.Text) - GetTimeSpanFromString(txtInitialTime.Text);

            txtTamanhoDoIntervalo.Text = GetTimeSpanString(tamanhoDoIntervalo);
        }

        private void buttonAvancar_Click(object sender, EventArgs e)
        {

        }

        private void buttonRetroceder_Click(object sender, EventArgs e)
        {

        }


        //private void progressBar_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Left)
        //        return;

        //    var seekerBarPosition = Convert.ToDecimal(progressBar.Value) / Convert.ToDecimal(progressBar.Maximum);

        //    _audioPlayer.SetPosition(seekerBarPosition);

        //    stopSeek = false;
        //}

        //private void progressBar(object sender, MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Left)
        //        return;

        //    stopSeek = true;
        //}

        //private void progressBar_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
        //        return;

        //    var seekerBarPosition = Convert.ToDecimal(progressBar.Value) / Convert.ToDecimal(SeekerTrackBar.Maximum);

        //    _audioPlayer.SetPosition(seekerBarPosition);

        //    stopSeek = false;
        //}

        //private void SeekerTrackBar_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
        //        return;

        //    stopSeek = true;
        //}
    }
}
