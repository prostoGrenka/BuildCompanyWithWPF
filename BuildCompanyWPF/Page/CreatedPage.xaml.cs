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

namespace BuildCompanyWPF.Page.Authorization
{
    /// <summary>
    /// Логика взаимодействия для CreatedPage.xaml
    /// </summary>
    public partial class CreatedPage : Window
    {
        public CreatedPage()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void addData_Click(object sender, RoutedEventArgs e)
        {

        }
        private void clearTextBox_Click(object sender, RoutedEventArgs e)
        {

        }
        private void back_Click(object sender, RoutedEventArgs e)
        {

        }

        public void clearData()
        {
            articleProduct.Clear();
            nameProduct.Clear();
            unitProduct.Clear();
            priceProduct.Clear();
            categoryProduct.Clear();
            currentDiscount.Clear();
            quantityProduct.Clear();
            desciptionProduct.Clear();
            maxSizeDiscountProduct.Clear();
            manufactureProduct.Clear();
            adressImageProduct.Clear();
            supplierProduct.Clear();
        }
    }
}
