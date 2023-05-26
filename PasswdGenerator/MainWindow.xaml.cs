using System;
using System.Collections.Generic;
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

namespace PasswdGenerator
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

        //private void generateButton_Click(object sender, RoutedEventArgs e)
        // {
        //int passwordLength = (int)passwordLengthSlider.Value;
        //bool includeSpecialChars = (bool)specialCharsCheckBox.IsChecked;
        //bool includeUpperCase = (bool)upperCaseCheckBox.IsChecked;
        //bool includeNumbers = (bool)numbersCheckBox.IsChecked;

        //string password = GeneratePassword(passwordLength, includeSpecialChars, includeUpperCase, includeNumbers);
        //passwordTextBox.Text = password;
        //}

        private string GeneratePassword(int length, bool includeSpecialChars, bool includeUpperCase, bool includeNumbers)
        {
            const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string specialChars = "!@#$%^&*()_+";
            const string numbers = "0123456789";

            StringBuilder passwordBuilder = new StringBuilder();
            string allowedChars = lowerCaseChars;

            if (includeSpecialChars)
            {
                allowedChars += specialChars;
            }

            if (includeUpperCase)
            {
                allowedChars += lowerCaseChars.ToUpper();
            }

            if (includeNumbers)
            {
                allowedChars += numbers;
            }

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];
                rng.GetBytes(data);

                for (int i = 0; i < length; i++)
                {
                    int index = data[i] % allowedChars.Length;
                    passwordBuilder.Append(allowedChars[index]);
                }
            }

            return passwordBuilder.ToString();
        }

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
