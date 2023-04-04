using MyProject.BaseWindow;
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

namespace MyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Base.TradeDBEntities dataBase;
        private Base.User User;
        public MainWindow(Base.User User)
        {
            InitializeComponent();
            try
            {
                dataBase = new Base.TradeDBEntities();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе!", "Ошибка", MessageBoxButton.OK);
                Close();
            }

            if (User.UserName != null && User.UserSurname != null && User.UserPatronymic != null)
                FIOtext.Text = $"{User.UserSurname} {User.UserName} {User.UserPatronymic}";

            this.User = User;
            if (User.Role is null)
            {
                rowAdminPanel.Height = new GridLength(0);
            }
            else
            {
                if (this.User.Role.Equals(1))
                    rowAdminPanel.Height = new GridLength(100);
            }

            update();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization window = new Authorization();
            window.Show();
            Close();

        }

        private bool isOpened = false;

        private void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            Base.Product currentProduct = (Base.Product)productList.SelectedItem;



            if (this.User.UserRole.Equals(1))
            {
                editProduct editWindow = new editProduct(currentProduct);
                editWindow.ShowDialog();
            }

            update();

        }

        private void update()
        {
            productList.ItemsSource = SourceCore.MyBase.Product.ToList();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {

            if (User.UserRole.Equals(1))
            {
                editProduct editWindow = new editProduct(null);
                editWindow.ShowDialog();

                update();
            }


        }
    }
}
