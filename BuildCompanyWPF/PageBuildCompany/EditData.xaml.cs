using BuildCompanyWPF.ApplicationData;
using BuildCompanyWPF.Page;
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

namespace BuildCompanyWPF.PageBuildCompany
{
    /// <summary>
    /// Логика взаимодействия для EditData.xaml
    /// </summary>
    public partial class EditData
    {
        private ImportProduct _editgoods = new ImportProduct();
        public EditData(ImportProduct selectedP)
        {
            InitializeComponent();
            if (selectedP != null)
            {
                _editgoods = selectedP;
            }
            DataContext = _editgoods;
            ComboCategory.ItemsSource = BuildCompanyEntities1.GetContext().CategoryProduct.Select(x => x.CategoryProduct1).ToList();
            ComboManuf.ItemsSource = BuildCompanyEntities1.GetContext().Manufacture.Select(x => x.manufacture1).ToList();
            ComboProvider.ItemsSource = BuildCompanyEntities1.GetContext().Supplier.Select(x => x.supplier1).ToList();
            ComboUnits.ItemsSource = BuildCompanyEntities1.GetContext().UnitTable.Select(x => x.Unit).ToList();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Page.PageForAdmin());
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_editgoods.Article))
            {
                errors.AppendLine("Введите артикль");
            }
            else if (instock.Text == "")
            {
                MessageBox.Show("Введите значение 'в наличии'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (actdics.Text == "")
            {
                MessageBox.Show("Введите значение 'актуальная скидка'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (maxdisc.Text == "")
            {
                MessageBox.Show("Введите значение 'максимальная скидка'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Введите значение 'Цена'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else if (instock.Text == "")
            {
                MessageBox.Show("Введите значение 'в наличии'!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_editgoods.Id == 0)
            {
                BuildCompanyEntities1.GetContext().ImportProduct.Add(_editgoods);
            }
            try
            {
                BuildCompanyEntities1.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            AppFrame.frameMain.Navigate(new PageForAdmin());
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageForAdmin());
        }
    }
}
