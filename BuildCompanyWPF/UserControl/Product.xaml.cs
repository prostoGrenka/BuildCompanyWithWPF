using BuildCompanyWPF.ApplicationData;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace BuildCompanyWPF.UserControl
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product
    {
        public Product()
        {
            InitializeComponent();
        }
        public ImageSource Source
        {
            get { return(ImageSource) GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Product));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Product));

        public string Ref
        {
            get { return (string)GetValue(RefProperty); }
            set { SetValue(RefProperty, value); }
        }

        public static readonly DependencyProperty RefProperty = DependencyProperty.Register("Ref", typeof(string), typeof(Product));

        public string  Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(string), typeof(Product));
        public string Count
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(string), typeof(Product));
        public string AllCount
        {
            get { return (string)GetValue(AllCountProperty); }
            set { SetValue(AllCountProperty, value); }
        }
        public static readonly DependencyProperty AllCountProperty = DependencyProperty.Register("AllCount", typeof(string), typeof(Product));
        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(Product));

        private ImportProduct selectedP;

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageBuildCompany.EditData(selectedP));
        }

        
        }
    }


