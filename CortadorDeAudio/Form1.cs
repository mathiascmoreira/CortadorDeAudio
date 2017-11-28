using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace CortadorDeAudio
{
    public partial class Form1 : Form
    {
        private readonly IAudioPlayer _audioPlayer;
        private System.Timers.Timer _timer;
        private BindingList<Intervalo> _intervalos;
        private Intervalo _intervalo;

        public Form1()
        {
            InitializeComponent();

            _audioPlayer = new AudioPlayer();
            progressBar.Maximum = 1000;
            _intervalos = new BindingList<Intervalo>();

            dataGridView.DataSource = _intervalos;

            _audioPlayer.OnPlayerEnds += _audioPlayer_OnPlayerEnds;

            SetTimer();

            FormatGrid();
        }

        private void FormatGrid()
        {
            dataGridView.Columns["Inicio"].DefaultCellStyle.Format = "mm':'ss':'ffff";
            dataGridView.Columns["Final"].DefaultCellStyle.Format = "mm':'ss':'ffff";
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

            _intervalo = null;
        }

        private void buttonInicialPosition_Click(object sender, EventArgs e)
        {
            var currentTimeString = _audioPlayer.GetMusicCurrentTime();

            txtInitialTime.Text = currentTimeString.ToStringFormat();
        }

        private void buttonFinalPosition_Click(object sender, EventArgs e)
        {
            var currentTimeString = _audioPlayer.GetMusicCurrentTime().ToStringFormat();

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

                if (txtInitialTime.Text.ToTimeSpan() >= txtFinalTime.Text.ToTimeSpan())
                    throw new Exception("Tempo final deve ser maior que o inicial!");

                _intervalos.Add(new Intervalo(txtInitialTime.Text.ToTimeSpan(), txtFinalTime.Text.ToTimeSpan()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (_intervalo != null && _audioPlayer.GetMusicCurrentTime() > _intervalo.Final)
            {
                _audioPlayer.SetMusicCurrentTime(_intervalo.Inicio);
            }

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
            return $"{_audioPlayer.GetMusicCurrentTime().ToStringFormat()}/{_audioPlayer.GetMusicTotalTime().ToStringFormat()}";
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

            var intervalo = PegaIntervaloSelecionado();

            if (intervalo != null)
            {
                intervalo.Inicio = txtInitialTime.Text.ToTimeSpan();
                dataGridView.Refresh();
            }
        }

        private void txtFinalTime_TextChanged(object sender, EventArgs e)
        {
            UpdateTamanhoDoIntervalo();

            var intervalo = PegaIntervaloSelecionado();

            if (intervalo != null)
            {
                intervalo.Final = txtFinalTime.Text.ToTimeSpan();
                dataGridView.Refresh();
            }
        }

        private void UpdateTamanhoDoIntervalo()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text) || string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var tamanhoDoIntervalo = txtFinalTime.Text.ToTimeSpan() - txtInitialTime.Text.ToTimeSpan();

            txtTamanhoDoIntervalo.Text = tamanhoDoIntervalo.ToStringFormat();
        }

        private void buttonAvancar_Click(object sender, EventArgs e)
        {
            _audioPlayer.StepAhead(3000);
        }

        private void buttonRetroceder_Click(object sender, EventArgs e)
        {
            _audioPlayer.StepBack(3000);
        }

        private void buttonInicialTimeMais_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text))
                return;

            var newTime = txtInitialTime.Text.ToTimeSpan().Add(new TimeSpan(0, 0, 0, 0, 100));

            txtInitialTime.Text = newTime.ToStringFormat();
        }

        private void buttonInicialTimeMenos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text))
                return;

            var newTime = txtInitialTime.Text.ToTimeSpan().Add(new TimeSpan(0, 0, 0, 0, -100));

            txtInitialTime.Text = newTime.ToStringFormat();
        }

        private void buttonFinalTimeMais_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var newTime = txtFinalTime.Text.ToTimeSpan().Add(new TimeSpan(0, 0, 0, 0, 100));

            txtFinalTime.Text = newTime.ToStringFormat();
        }

        private void buttonFinalTimeMenos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var newTime = txtFinalTime.Text.ToTimeSpan().Add(new TimeSpan(0, 0, 0, 0, -100));

            txtFinalTime.Text = newTime.ToStringFormat(); ;
        }

        private void buttonExecuteInterval_Click(object sender, EventArgs e)
        {
            _intervalo = PegaIntervaloSelecionado();

            if (_intervalo == null)
                throw new Exception("Não há linhas selecionadas!");

            var initialTime = _intervalo.Inicio;

            _audioPlayer.SetMusicCurrentTime(initialTime);
        }

        private Intervalo PegaIntervaloSelecionado()
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index ?? -1;

            if (currentRowIndex < 0)
                return null;

            return _intervalos[currentRowIndex];
        }

        private void buttonRemoveInterval_Click(object sender, EventArgs e)
        {
            var intervalo = PegaIntervaloSelecionado();

            if (intervalo == null)
                throw new Exception("Selecione uma linha!");

            _intervalos.Remove(intervalo);

            _intervalo = null;

            dataGridView.Refresh();
        }

        private void dataGridView_Enter(object sender, EventArgs e)
        {
            var intervalo = PegaIntervaloSelecionado();

            if (intervalo == null)
                return;

            var posicaoInicial =
                intervalo.Inicio.TotalMilliseconds / _audioPlayer.GetMusicTotalTime().TotalMilliseconds*progressBar.Height + progressBar.Location.X;

           // inicialMark.Location.X = posicaoInicial;
        }

        private void dataGridView_Leave(object sender, EventArgs e)
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
