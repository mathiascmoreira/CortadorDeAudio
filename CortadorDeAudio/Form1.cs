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
        private readonly IAudioPlayer _audioPlayer;
        private readonly IAudioTools _audioTools;
        private System.Timers.Timer _timer;
        private BindingList<Intervalo> _intervalos;
        private Intervalo _intervalo;

        public Form1()
        {
            InitializeComponent();

            _audioPlayer = new AudioPlayer();
            _audioTools = new AudioTools();
            _intervalos = new BindingList<Intervalo>();
            volumeControl.Value = volumeControl.Maximum;

            dataGridView.DataSource = _intervalos;

            _audioPlayer.OnPlayerEnds += _audioPlayer_OnPlayerEnds;

            SetTimer();

            FormatGrid();
        }

        private void FormatGrid()
        {
            const string intervaloInicioColumn = "Inicio";
            const string intervaloFinalColumn = "Final";

            dataGridView.Columns[intervaloInicioColumn].DefaultCellStyle.Format = "mm':'ss':'ffff";
            dataGridView.Columns[intervaloFinalColumn].DefaultCellStyle.Format = "mm':'ss':'ffff";
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

            ResetInterval();
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
                ValidaIntervaloDaTela();

                _intervalos.Add(new Intervalo(txtInitialTime.Text.ToTimeSpan(), txtFinalTime.Text.ToTimeSpan()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateInterval_Click(object sender, EventArgs e)
        {
            var intervaloDaTela = PegaIntervaloDaTela();
            var intervalo = PegaIntervaloSelecionado();

            intervalo.Inicio = intervaloDaTela.Inicio;
            intervalo.Final = intervaloDaTela.Final;

            SetInterval(intervaloDaTela);

            dataGridView.Refresh();
        }

        private void ValidaIntervaloDaTela()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text))
                throw new Exception("Selecione um tempo inicial!");

            if (string.IsNullOrEmpty(txtFinalTime.Text))
                throw new Exception("Selecione um tempo final!");

            var inicio = txtInitialTime.Text.ToTimeSpan();
            var final = txtFinalTime.Text.ToTimeSpan();

            if (inicio >= final)
                throw new Exception("Tempo final deve ser maior que o inicial!");

            if (final - inicio < new TimeSpan(0,0,0,1))
                throw new Exception("Intervalo deve ter pelo menos 1 segundo");

            if (inicio >= _audioPlayer.GetMusicTotalTime() ||
                final >= _audioPlayer.GetMusicTotalTime() ||
                inicio < TimeSpan.Zero || final < TimeSpan.Zero)
                throw new Exception("Intervalo selecionado não esta contido no audio selecionado!");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_intervalo != null && _audioPlayer.GetMusicCurrentTime() > _intervalo.Final)
            {
                _audioPlayer.SetMusicCurrentTime(_intervalo.Inicio);
            }

            UpdateProgressBarPosition();

            UpdateTimeLabel();
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

        private void UpdateTamanhoDoIntervalo()
        {
            if (string.IsNullOrEmpty(txtInitialTime.Text) || string.IsNullOrEmpty(txtFinalTime.Text))
                return;

            var tamanhoDoIntervalo = txtFinalTime.Text.ToTimeSpan() - txtInitialTime.Text.ToTimeSpan();

            txtTamanhoDoIntervalo.Text = tamanhoDoIntervalo.ToStringFormat();
        }

        private void buttonAvancar_Click(object sender, EventArgs e)
        {
            _audioPlayer.StepAhead(new TimeSpan(0, 0, 0, 0, 3000));
        }

        private void buttonRetroceder_Click(object sender, EventArgs e)
        {
            _audioPlayer.StepBack(new TimeSpan(0, 0, 0, 0, 3000));
        }

        private void buttonInicialTimeMais_Click(object sender, EventArgs e)
        {
            if(EstaExecutandoIntervalo())
                ExecutaIntervaloDaTela();

            txtInitialTime.Text = UpdateTimeString(txtInitialTime.Text, 100);
        }

        private void buttonInicialTimeMenos_Click(object sender, EventArgs e)
        {
            if (EstaExecutandoIntervalo())
                ExecutaIntervaloDaTela();

            txtInitialTime.Text = UpdateTimeString(txtInitialTime.Text, -100);
        }

        private void buttonFinalTimeMais_Click(object sender, EventArgs e)
        {
            if (EstaExecutandoIntervalo())
            {
                ExecutaIntervaloDaTela();

                _audioPlayer.SetMusicCurrentTime(txtFinalTime.Text.ToTimeSpan()
                    .Add(new TimeSpan(0, 0, 0, 0, -500)));
            }
                

            txtFinalTime.Text = UpdateTimeString(txtFinalTime.Text, 100);
        }

        private void buttonFinalTimeMenos_Click(object sender, EventArgs e)
        {
            if (EstaExecutandoIntervalo())
            {
                ExecutaIntervaloDaTela();

                _audioPlayer.SetMusicCurrentTime(txtFinalTime.Text.ToTimeSpan()
                    .Add(new TimeSpan(0, 0, 0, 0, -500)));
            }

            txtFinalTime.Text = UpdateTimeString(txtFinalTime.Text, -100);
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

            ExecutaIntervaloDaTela();
        }

        private void buttonStopExecuteInterval_Click(object sender, EventArgs e)
        {
           ResetInterval();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            UpdateTamanhoDoIntervalo();
        }

        private Intervalo PegaIntervaloSelecionado()
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index ?? -1;

            if (currentRowIndex < 0)
                throw new Exception("Selecione uma linha!");

            return _intervalos[currentRowIndex];
        }

        private Intervalo PegaIntervaloDaTela()
        {
            ValidaIntervaloDaTela();

            var inicio = txtInitialTime.Text.ToTimeSpan();
            var final = txtFinalTime.Text.ToTimeSpan();

            return new Intervalo(inicio, final);
        }

        private void buttonRemoveInterval_Click(object sender, EventArgs e)
        {
            var intervalo = PegaIntervaloSelecionado();

            _intervalos.Remove(intervalo);

            if(intervalo == _intervalo)
               ResetInterval();

            dataGridView.Refresh();
        }

        private void StripMenuItemOpen_Click(object sender, EventArgs e)
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

                _intervalos.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar o arquivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveIntervals_Click(object sender, EventArgs e)
        {
            if (!_intervalos.Any())
                throw new Exception("Nao há intervalos adicionados!");

            var fileBuilder = new StringBuilder();

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Selecione um local para salvar o arquivo.",
                Filter = "txt files|*.txt"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                foreach (var intervalo in _intervalos)
                {
                    fileBuilder.Append($"{intervalo.Inicio.ToStringFormat()}; {intervalo.Final.ToStringFormat()}");
                }

                File.WriteAllText(saveFileDialog.FileName, fileBuilder.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar o arquivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarIntervalosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var theDialog = new OpenFileDialog
            {
                Title = "Selecione o arquivo com os intervalos",
                Filter = "txt files|*.txt"
            };

            if (theDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var filelines = File.ReadAllLines(theDialog.FileName);

                var newIntervals = new List<Intervalo>();

                foreach (var line in filelines)
                {
                    var lineSplitted = line.Split(';');

                    newIntervals.Add(new Intervalo(lineSplitted[0].ToTimeSpan(), lineSplitted[1].ToTimeSpan()));
                }

                foreach (var newInterval in newIntervals)
                {
                    _intervalos.Add(newInterval);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o arquivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (!_intervalos.Any())
                return;

            try
            {
                var intervalo = PegaIntervaloSelecionado();

                if (intervalo == null)
                    return;

                AtualizarIntervaloDaTela(intervalo);

                ExecutaIntervaloDaTela();
            }
            catch (Exception ex)
            {
                ResetInterval();
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSalveCuttedAudio_Click(object sender, EventArgs e)
        {
            if(!_audioPlayer.MusicLoaded)
                throw new Exception("Não há nenhum arquivo aberto!");

            if (!_intervalos.Any())
                throw new Exception("Nao há intervalos adicionados!");

            var folderBrowser = new FolderBrowserDialog
            {
                Description = "Selecione um local para salvar os arquivos.",
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

            foreach (var interval in _intervalos)
            {
                _audioTools.TrimAudio(_audioPlayer.MusicFileName, GetNextFileName(), interval.Inicio, interval.Final);
            }
        }

        private void AtualizarIntervaloDaTela(Intervalo intervalo)
        {
            txtInitialTime.Text = intervalo.Inicio.ToStringFormat();

            txtFinalTime.Text = intervalo.Final.ToStringFormat();
        }

        private void ExecutaIntervaloDaTela()
        {
            ValidaIntervaloDaTela();

            SetInterval(PegaIntervaloDaTela());
        }

        private void SetInterval(Intervalo interval)
        {
            _intervalo = interval;

            _audioPlayer.SetMusicCurrentTime(interval.Inicio);
        }

        private void ResetInterval()
        {
            _intervalo = null;
        }

        private void volumeControl_ValueChanged(object sender, EventArgs e)
        {
            UpdateVolume();
        }

        private bool EstaExecutandoIntervalo()
        {
            return _intervalo != null;
        }

        private void UpdateVolume()
        {
            var volumeRate = (float)volumeControl.Value / volumeControl.Maximum;

            _audioPlayer.SetVolume(volumeRate);
        }
    }
}
