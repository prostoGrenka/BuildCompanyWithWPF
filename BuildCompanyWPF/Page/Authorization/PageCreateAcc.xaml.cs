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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BuildCompanyWPF.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
        private void PasswordBox_PasswordChange(Object sender, RoutedEventArgs e)
        {
            if(repeadPassword.Password != passwordInput.Password)
            {
                create.IsEnabled = false;
                repeadPassword.Background = Brushes.LightCoral;
                repeadPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                create.IsEnabled = true;
                repeadPassword.Background = Brushes.LightGreen;
                repeadPassword.BorderBrush = Brushes.Green;
                
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(AppConnect.modelOdb.Users.Count(x => x.Login == loginInput.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Users userObj = new Users()
                {
                    Login = loginInput.Text,
                    FirstName = nameUser.Text,
                    Surname = SecondNameUser.Text,
                    Password = passwordInput.Password,
                    Id_Role = 2
                };
                AppConnect.modelOdb.Users.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
