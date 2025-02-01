using laboratory.Users_Window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace laboratory
{
    public partial class Authorization : Window
    {
        bool isVisible = false;
        private string captchaValue;
        private DispatcherTimer lockoutTimer;
        private int lockoutSeconds = 10;


        public Authorization()
        {
            InitializeComponent();
            InitializeLockoutTimer();
        }


        private void Button_Click_Enter(object sender, RoutedEventArgs e)
        {
            LaboratoryDB db = new LaboratoryDB();
            string login = Login.Text;
            string password = Password.Password;

            if (lockoutTimer.IsEnabled)
            {
                MessageBox.Show($"Подождите еще {lockoutSeconds} секунд.");
                return;
            }


            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                GenerateCaptcha();
                return;
            }

            var currentUser = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);


            if (currentUser == null)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");
                GenerateCaptcha();
                return;
            }

            var user = db.Users.Find(currentUser.User_ID);


            if (CaptchaTextBox.Text.Equals(captchaValue, StringComparison.OrdinalIgnoreCase) || CaptchaTextBox.Text == "")
            {
                if (currentUser.Role == "администратор")
                {
                    user.Last_Data_Entry = DateTime.Today;
                    db.SaveChanges();
                    Admin_Window admin_Window = new Admin_Window(currentUser.Full_Name);
                    this.Close();
                    admin_Window.ShowDialog();
                }
                else if (currentUser.Role == "лаборант")
                {
                    user.Last_Data_Entry = DateTime.Today;
                    db.SaveChanges();
                    Laborant_Window laborant_Window = new Laborant_Window(currentUser.Full_Name);
                    this.Close();
                    laborant_Window.ShowDialog();
                }
                else if (currentUser.Role == "лаборант-исследователь")
                {
                    user.Last_Data_Entry = DateTime.Today;
                    db.SaveChanges();
                    Laborant_Researcher_Window accountant_Window = new Laborant_Researcher_Window(currentUser.Full_Name);
                    this.Close();
                    accountant_Window.ShowDialog();
                }
                else if (currentUser.Role == "бухгалтер")
                {
                    user.Last_Data_Entry = DateTime.Today;
                    db.SaveChanges();
                    Accountant_Window accountant_Window = new Accountant_Window(currentUser.Full_Name);
                    this.Close();
                    accountant_Window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");
                    GenerateCaptcha();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверную капчу. Пожалуйста проверьте ещё раз");
                GenerateCaptcha();
                StartLockoutTimer();
                return;
            }
        }


        private void ShowCaptcha()
        {
            CaptchaPanel.Visibility = Visibility.Visible;
            CaptchaTextBlock.Text = captchaValue;
        }

        private void GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            StringBuilder captchaStringBuilder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                captchaStringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            captchaValue = captchaStringBuilder.ToString();
            ShowCaptcha();
        }

        private void InitializeLockoutTimer()
        {
            lockoutTimer = new DispatcherTimer();
            lockoutTimer.Interval = TimeSpan.FromSeconds(1);
            lockoutTimer.Tick += LockoutTimer_Tick;
        }

        private void StartLockoutTimer()
        {
            lockoutSeconds = 10;
            lockoutTimer.Start();
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            lockoutSeconds--;

            if (lockoutSeconds <= 0)
            {
                lockoutTimer.Stop();
            }
        }

        private void Update_Captcha_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }


        private void Show_Password_Click(object sender, RoutedEventArgs e)
        {
            if (isVisible == false)
            {
                Image.Source = new BitmapImage(new System.Uri("/Resourses/visible_pas.png", System.UriKind.Relative));
                PasswordText.Text = Password.Password;
                PasswordText.Visibility = Visibility.Visible;
                isVisible = true;
            }
            else
            {
                Image.Source = new BitmapImage(new System.Uri("/Resourses/invisible_pas.png", System.UriKind.Relative));
                Password.Password = PasswordText.Text;
                PasswordText.Visibility = Visibility.Collapsed;
                isVisible = false;
            }
        }
    }
}
