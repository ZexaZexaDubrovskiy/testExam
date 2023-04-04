using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyProject.BaseWindow
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private Base.TradeDBEntities dataBase;
        private bool flag = false;
        Timer timer = new Timer();
        public Authorization()
        {
            InitializeComponent();
            captchaRow.Height = new GridLength(0);

            try
            {
                dataBase = new Base.TradeDBEntities();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе!", "Ошибка", MessageBoxButton.OK);
                Close();
            }
            timer.Interval = 10000;
            timer.Elapsed += timerForUser;
        }
//таймер
        private void timerForUser(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                SignIn.IsEnabled = true;
                SignInRoleGuest.IsEnabled = true;
            }));

            timer.Stop();
        }

//переход на окно mainWindow
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            Base.User User = SourceCore.MyBase.User.SingleOrDefault(u => u.UserLogin == login.Text && u.UserPassword == password.Password);
            if (User != null)
            {
                if (!flag || capthcaForUser.Text == capthcaForProject.Text)
                {
                    MainWindow window = new MainWindow(User);
                    window.Show();
                    Close();
                } else if (capthcaForUser.Text != capthcaForProject.Text)
                {
                    MessageBox.Show("Неверная капча. Система заблокирована на 10 секунд", "Ошибка", MessageBoxButton.OK);

                    timer.Start();
                    SignIn.IsEnabled = false;
                    SignInRoleGuest.IsEnabled = false;
                }
            } else
            {
                if (!flag)
                    MessageBox.Show("Неверный логин или пароль. Для следующий попыток необходимо ввести капчу", "Ошибка", MessageBoxButton.OK);
                if (flag)
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK);
                
                captchaRow.Height = new GridLength(100);

                flag = true;

                String allowchar = " ";
                allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                allowchar += "1,2,3,4,5,6,7,8,9,0";
                //разделитель
                char[] a = { ',' };
                //расщепление массива по разделителю
                String[] ar = allowchar.Split(a);
                String pwd = " ";
                string temp = " ";
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    temp = ar[(r.Next(0, ar.Length))];
                    pwd += temp;
                }
                capthcaForUser.Text = pwd;

            }
        }


//Войти как Гость
        private void SignInRoleGuest_Click(object sender, RoutedEventArgs e)
        {
            Base.User User = new Base.User();

            MainWindow window = new MainWindow(User);
            window.Show();
            Close();
        }
    }
}
