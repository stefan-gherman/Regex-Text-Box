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
using System.Text;
using System.Text.RegularExpressions;

namespace RegexTextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void NameCheck(string name)
        {
            string personName = "[a-zA-Z]+";
            string whitespace = @"\s";
            string pattern = "^(" + personName + whitespace + "*)+$";
            if(!Regex.IsMatch(name, pattern))
            {
                MessageBox.Show("Name is invalid");
            }
            
        }

        public void EmailCheck(string email)
        {
            string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if(!Regex.IsMatch(email, emailRegex ))
            {
                MessageBox.Show("Invalid Email");
            }
        }

        public void PhoneCheck(string phone)
        {
            string phoneRegex = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
            if(!Regex.IsMatch(phone, phoneRegex))
            {
                MessageBox.Show("Invalid Phone");
            }
            else
            {
                txtPhone.Text = PhoneFormat(phone);
            }
           
        }

        public string PhoneFormat(string phone)
        {
            string phoneRegex = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
            return Regex.Replace(phone, phoneRegex, @"($1)-$2-$3");
        }



        private void svButton_Click(object sender, RoutedEventArgs e)
        {
            NameCheck(txtName.Text);
            EmailCheck(txtEmail.Text);
            PhoneCheck(txtPhone.Text);
        }
    }
}
