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

namespace PasswdGenerator.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для GeneratorView.xaml
    /// </summary>
    public partial class GeneratorView : UserControl
    {
        public GeneratorView()
        {
            InitializeComponent();
        }

        private string GeneratePassword()
        {
            const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string specialChars = "!@#$%^&*()_+";
            const string numbers = "0123456789";
            bool unique = false;

            StringBuilder passwordBuilder = new StringBuilder();
            string allowedChars = "";

            if (tbNumbers.IsChecked ?? false)
            {
                allowedChars += numbers;
            }

            if (tbSpecSymbols.IsChecked ?? false)
            {
                allowedChars += specialChars;
            }

            if (tbUpperLowerSymbols.IsChecked ?? false)
            {
                allowedChars += lowerCaseChars.ToUpper();
                tbUpperLowerSymbols.Content = "Верхний регистр";
            }
            else if (tbUpperLowerSymbols.IsChecked == false)
            {
                allowedChars += lowerCaseChars;
                tbUpperLowerSymbols.Content = "Нижний регистр";
            }
            else
            {
                allowedChars += lowerCaseChars.ToUpper();
                allowedChars += lowerCaseChars;
                tbUpperLowerSymbols.Content = "Оба регистра";
            }

            if (tbUnique.IsChecked ?? false)
            {
                unique = true;
                if (sLength.Value > allowedChars.Length)
                {
                    sLength.Value = allowedChars.Length;
                }
            }
            else
            {
                unique = false;
            }

            
            using (var rng = new RNGCryptoServiceProvider())
            {
                var length = (int)sLength.Value;
                byte[] data = new byte[length];
                rng.GetBytes(data);

                for (int i = 0; i < length; i++)
                {
                    int index = data[i] % allowedChars.Length;
                    passwordBuilder.Append(allowedChars[index]);
                    if (unique)
                    {
                        allowedChars = allowedChars.Replace(allowedChars[index].ToString(), String.Empty);
                    }
                }
            }

            tbGeneratedPasswd.Text = passwordBuilder.ToString();
            return passwordBuilder.ToString();
        }

        private void sLength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            GeneratePassword();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void tbNumbers_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void tbSpecSymbols_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void tbUpperLowerSymbols_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void tbUnique_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }
    }
}
