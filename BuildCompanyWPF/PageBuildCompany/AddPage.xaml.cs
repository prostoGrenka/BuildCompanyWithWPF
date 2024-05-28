using BuildCompanyWPF.ApplicationData;
using BuildCompanyWPF.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

namespace BuildCompanyWPF.PageBuildCompany
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage 
    {
        private BuildCompanyEntities1 _currentGoods = new BuildCompanyEntities1();
        public AddPage()
        {
            InitializeComponent();

            DataContext = _currentGoods;

            ComboCategory.ItemsSource = BuildCompanyEntities1.GetContext().CategoryProduct.Select(x => x.CategoryProduct1).ToList();
            ComboManuf.ItemsSource = BuildCompanyEntities1.GetContext().Manufacture.Select(x => x.manufacture1).ToList();
            ComboProvider.ItemsSource = BuildCompanyEntities1.GetContext().Supplier.Select(x => x.supplier1).ToList();
            ComboUnits.ItemsSource = BuildCompanyEntities1.GetContext().UnitTable.Select(x => x.Unit).ToList();
        }
        private void butex_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageForAdmin());
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string arti = article.Text;
            int stock = Convert.ToInt32(instock.Text);
            string price = priceBox.Text;
            int actdisc = Convert.ToInt32(actdicsBox.Text);
            int maxdiscc = Convert.ToInt32(maxdiscBox.Text);
            int category = ComboCategory.SelectedIndex + 1;
            int units = ComboUnits.SelectedIndex + 1;
            int provider = ComboProvider.SelectedIndex + 1;
            int manuf = ComboManuf.SelectedIndex + 1;
            string names = NamesBox.Text;
            string descc = desc.Text;
            string photo = photoBox.Text;
            try
            {
                ImportProduct goods = new ImportProduct()
                {
                    Article = arti,
                    Name = names,
                    Id_Unit = units,
                    Price = price,
                    MaxSizeDiscount = maxdiscc,
                    Id_Manufacture = manuf,
                    Id_Supplier = provider,
                    Id_ProductCategory = category,
                    CurrentDiscount = actdisc,
                    Quantity = stock,
                    Description = descc,
                    ImageAddress = photo

                };
                AppConnect.modelOdb.ImportProduct.Add(goods);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("данные добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.Navigate(new PageForAdmin());
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AppConnect.modelOdb.SaveChanges();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Page.PageForAdmin());
        }
    }
}
