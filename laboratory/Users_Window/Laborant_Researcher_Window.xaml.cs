using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace laboratory.Users_Window
{
    public partial class Laborant_Researcher_Window : Window
    {
        Authorization authorization_window = new Authorization();
        private DispatcherTimer sessionTimer;
        private TimeSpan sessionDuration = new TimeSpan(0, 02, 0);
        private TimeSpan timeRemaining;
        private DateTime sessionStartTime;
        private bool isBlocked = false;

        public Laborant_Researcher_Window(string user_name)
        {
            InitializeComponent();
            Laborant_researcher_name.Content = user_name;
            StartNewSession();
        }

        private void GenerateReports_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            authorization_window.ShowDialog();
        }

        private void StartNewSession()
        {
            if (isBlocked)
            {
                MessageBox.Show("Вход заблокирован на 30 минут.");
                return;
            }

            sessionStartTime = DateTime.Now;
            timeRemaining = sessionDuration;
            sessionTimer = new DispatcherTimer();
            sessionTimer.Interval = TimeSpan.FromSeconds(1);
            sessionTimer.Tick += OnTimerTick;
            sessionTimer.Start();

            UpdateTimeDisplay();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            timeRemaining -= TimeSpan.FromSeconds(1);

            if (timeRemaining <= TimeSpan.Zero)
            {
                EndSession();
                BlockEntry();
                sessionTimer.Stop();
            }
            else if (timeRemaining == TimeSpan.FromMinutes(01))
            {
                MessageBox.Show("Кварцевание начнётся через " + timeRemaining.ToString(@"mm\:ss"));
            }

            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            Timer.Content= timeRemaining.ToString(@"hh\:mm\:ss");
        }

        private void EndSession()
        {
            this.Close();
            authorization_window.ShowDialog();
        }

        private void BlockEntry()
        {
            isBlocked = true;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(01) };
            timer.Tick += (s, e) =>
            {
                isBlocked = false;
                timer.Stop();
                StartNewSession(); 
            };
            timer.Start();
        }
    }
}
