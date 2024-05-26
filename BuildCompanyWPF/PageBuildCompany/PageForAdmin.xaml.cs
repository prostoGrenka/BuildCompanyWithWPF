using BuildCompanyWPF.ApplicationData;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BuildCompanyWPF.PageBuildCompany;

namespace BuildCompanyWPF.Page
{
    /// <summary>
    /// Логика взаимодействия для PageForAdmin.xaml
    /// </summary>
    public partial class PageForAdmin 
    { 
        public PageForAdmin()
        {
            InitializeComponent();
            var currentProduct = BuildCompanyEntities1.GetContext().ImportProduct.ToList();
            LViewProduct.ItemsSource = currentProduct;
            Downloads();
        }

        List<ImportProduct> importProducts;
        public void Downloads()
        {
            importProducts = AppConnect.modelOdb.ImportProduct.ToList();

            if (importProducts.Count > 0)
            {
                tbCounter.Text = "Найдено " + importProducts.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Ничего не найдено";
            }
            LViewProduct.ItemsSource = importProducts;
            ComboSort.Items.Add("По возрастанию товаров на складе");
            ComboSort.Items.Add("По уменьшению товаров на складе");

            ComboFilter.Items.Add("Скидка от 0 до 10");
            ComboFilter.Items.Add("Скидка от 10 до 15");
            ComboFilter.Items.Add("Скидка от 15");


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageBuildCompany.AddPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = LViewProduct.SelectedItems.Cast<ImportProduct>().ToList();
            List<ImportProduct> product = AppConnect.modelOdb.ImportProduct.ToList();
            var productall = product;
            if (selectedProduct != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить выбранный товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        BuildCompanyEntities1.GetContext().ImportProduct.RemoveRange(selectedProduct);
                        BuildCompanyEntities1.GetContext().SaveChanges();
                        MessageBox.Show("данные удалены");
                        LViewProduct.ItemsSource = BuildCompanyEntities1.GetContext().ImportProduct.ToList();
                        importProducts = AppConnect.modelOdb.ImportProduct.ToList();

                        if (importProducts.Count > 0)
                        {
                            tbCounter.Text = "Найдено " + importProducts.Count + " товаров";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        ImportProduct[] findGoods()
        {
            List<ImportProduct> product = AppConnect.modelOdb.ImportProduct.ToList();
            var productall = product;
            if (TBoxSearch != null)
            {
                product = product.Where(x => x.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }

            //if (ComboFilter.SelectedIndex > 0)
            //{
            //    switch (ComboFilter.SelectedIndex)
            //    {
            //        case 0:
            //            product = product.(x => x.Article > 0 && x.Article < 10).ToList();
            //            break;
            //        case 1:
            //            product = product.Where(x => x.Article >= 10 && x.Article < 15).ToList();
            //            break;
            //        case 2:
            //            product = product.Where(x => x.Article >= 15).ToList();
            //            break;
            //    }
            //}
            if (ComboSort.SelectedIndex > 0)
            {
                switch (ComboSort.SelectedIndex)
                {
                    case 0:
                        product = product.OrderBy(x => x.Quantity).ToList<ImportProduct>();
                        break;
                    case 1:
                        product = product.OrderByDescending(x => x.Quantity).ToList<ImportProduct>();
                        break;
                }
            }
            if (product.Count > 0)
            {
                tbCounter.Text = "Найдено " + product.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Ничего не найдено";
            }
            LViewProduct.ItemsSource = product;
            return product.ToArray();

        }
        private void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSort.SelectedIndex = 0;
            ComboFilter.SelectedIndex = 0;
        }
        private void ochButton_Click(object sender, RoutedEventArgs e)
        {
            ComboSort.SelectedIndex = -1;
            ComboFilter.SelectedIndex = -1;
            TBoxSearch.Text = string.Empty;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            findGoods();
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
