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

namespace MyProject.BaseWindow
{
    /// <summary>
    /// Interaction logic for editProduct.xaml
    /// </summary>
    public partial class editProduct : Window
    {
        private Base.TradeDBEntities dataBase;
        private Base.Product product;
        public editProduct(Base.Product product)
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
            this.product = product;

            categoryProduct.ItemsSource = SourceCore.MyBase.Category.ToList();
            providerProduct.ItemsSource = SourceCore.MyBase.Providerss.ToList();


            if (!(product is null))
            {
                nameProduct.Text = product.ProductName;
                descriptionPsroduct.Text = product.ProductDescription;
                quantityProduct.Text = product.ProductQuantityInStock.ToString();
                unitProduct.Text = product.UNIT;
                costProduct.Text = product.ProductCost.ToString();
                
                providerProduct.Text = SourceCore.MyBase.Providerss.SingleOrDefault(U => U.id == product.provider).name;
                categoryProduct.Text = SourceCore.MyBase.Category.SingleOrDefault(U => U.id == product.ProductCategory).name;

                acceptButton.Content = "Изменить";
            } else
            {
                acceptButton.Content = "Добавить";
            }

        }

        private bool check()
        {
            if (int.TryParse(quantityProduct.Text, out int result))
                if (result < 0)
                    return true;
            if (int.TryParse(quantityProduct.Text, out int result1))
                if (result1 < 0)
                    return true;

            return false;
        }


        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                MessageBox.Show("Ошибка в полях Количество или Стоимость", "Ошибка", MessageBoxButton.OK);
                return;
            }

            if (product is null)
            {
                var addProduct = new Base.Product();
                addProduct.ProductStatus = "Новый";
                addProduct.ProductManufacturer = "NoName";

                Random r = new Random();
                string names = "";
                for (int i = 0; i < 6; i++)
                    names += r.Next(0, 9);

                addProduct.ProductArticleNumber = names;

                addProduct.ProductName = nameProduct.Text;
                addProduct.ProductDescription = descriptionPsroduct.Text;
                addProduct.ProductQuantityInStock = int.Parse(quantityProduct.Text);
                addProduct.UNIT = unitProduct.Text;
                addProduct.ProductCost = Math.Round(decimal.Parse(costProduct.Text), 4);

                addProduct.ProductCategory = categoryProduct.SelectedIndex+1;
                addProduct.provider = providerProduct.SelectedIndex+1;

                SourceCore.MyBase.Product.Add(addProduct);
            }
            else
            {
                var editProduct = new Base.Product();
                editProduct = SourceCore.MyBase.Product.FirstOrDefault(p => p.ProductArticleNumber == product.ProductArticleNumber);
                editProduct.ProductName = nameProduct.Text;
                editProduct.ProductDescription = descriptionPsroduct.Text;
                editProduct.ProductQuantityInStock = int.Parse(quantityProduct.Text);
                editProduct.UNIT = unitProduct.Text;
                editProduct.ProductCost = Math.Round(decimal.Parse(costProduct.Text), 3);

                editProduct.provider = providerProduct.SelectedIndex + 1;
                editProduct.ProductCategory = categoryProduct.SelectedIndex + 1;

            }


            try
            {
                SourceCore.MyBase.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить/изменить {ex.Message.ToString()}", "Ошибка", MessageBoxButton.OK);
                Close();
            }

        }
    }
}
