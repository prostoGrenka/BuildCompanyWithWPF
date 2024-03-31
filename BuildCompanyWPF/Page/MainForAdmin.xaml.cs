using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Configuration;
using BuildCompanyWPF.ApplicationData;

namespace BuildCompanyWPF.Page
{
    /// <summary>
    /// Логика взаимодействия для MainForAdmin.xaml
    /// </summary>
    public partial class MainForAdmin
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable phonesTable;
        public MainForAdmin()
        {
            InitializeComponent();

        }

        private void ButtonInput_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
