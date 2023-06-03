using System;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace PasswdGenerator.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для GeneratorView.xaml
    /// </summary>
    public partial class GeneratorView : UserControl
    {
        List<string> passwords = new();
        string path = "pswdb";

        private const string lowerCaseCharsRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string specialChars = "!@#$%^&*()_+";
        private const string numbers = "0123456789";

        public GeneratorView()
        {
            InitializeComponent();
            lbPasswords.ItemsSource = passwords;

            if (!File.Exists(path))
            {
                using (StreamWriter writer = new StreamWriter(path, false)) { };
            }
        }

        private string GeneratePassword()
        {
            bool unique = false;

            StringBuilder passwordBuilder = new StringBuilder();
            string allowedChars = "";

            if (tbNumbers.IsChecked ?? false) 
                allowedChars += numbers;

            if (tbSpecSymbols.IsChecked ?? false) 
                allowedChars += specialChars;

            if (tbUpperLowerSymbols.IsChecked ?? false)
            {
                tbUpperLowerSymbols.Content = "Верхний регистр";

                allowedChars += lowerCaseChars.ToUpper();
                if (tbRuSymbols.IsChecked ?? false)
                    allowedChars += lowerCaseCharsRu.ToUpper();
            }
            else if (tbUpperLowerSymbols.IsChecked == false)
            {
                tbUpperLowerSymbols.Content = "Нижний регистр";
                allowedChars += lowerCaseChars;
                if (tbRuSymbols.IsChecked ?? false)
                    allowedChars += lowerCaseCharsRu;
            }
            else
            {
                tbUpperLowerSymbols.Content = "Оба регистра";

                allowedChars += lowerCaseChars.ToUpper();
                allowedChars += lowerCaseChars;
                if (tbRuSymbols.IsChecked ?? false)
                {
                    allowedChars += lowerCaseCharsRu.ToUpper();
                    allowedChars += lowerCaseCharsRu;
                }
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            sLength.Value = 12;
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (tbGeneratedPasswd.Text.Length > 0)
            {
                Clipboard.Clear();
                Clipboard.SetText(tbGeneratedPasswd.Text);
            }
        }

        private void tbRuSymbols_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void lbPasswords_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem lbi = lbPasswords.SelectedItem as ListBoxItem;
            Clipboard.Clear();
            if (lbPasswords.SelectedItem != null)
            {
                Clipboard.SetText(lbPasswords.SelectedItem.ToString());
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            passwords.Add(tbGeneratedPasswd.Text);
            lbPasswords.Items.Refresh();
            SavePasswdInFile();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SavePasswdInFile();
        }

        private void SavePasswdInFile()
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            { 
                foreach (string passwd in passwords)
                {
                    writer.WriteLine(EncodeDecrypt(passwd));
                }
            }
        }

        private void lbPasswords_KeyUp(object sender, KeyEventArgs e)
        {
            int savedIndex;
            if (e.Key == Key.Delete)
            {
                if (lbPasswords.SelectedItem != null)
                {
                    savedIndex = lbPasswords.SelectedIndex;
                    _ = passwords.Remove(lbPasswords.SelectedItem.ToString());
                    lbPasswords.Items.Refresh();

                    if (savedIndex <= lbPasswords.Items.Count - 1)
                    {
                        lbPasswords.SelectedIndex = savedIndex;
                    }
                    else if (lbPasswords.Items.Count > 0)
                    {
                        savedIndex--;
                        lbPasswords.SelectedIndex = savedIndex;
                    }
                }
                SavePasswdInFile();
            }
        }

        private void lbPasswords_Loaded(object sender, RoutedEventArgs e)
        {   
            
            using (StreamReader reader = new StreamReader(path))
            {
                
                string? line;
              
                while ((line = reader.ReadLine()) != null)
                {
                    passwords.Add(EncodeDecrypt(line));
                }
            }
            
            lbPasswords.Items.Refresh();
        }

        public static string EncodeDecrypt(string str)//, ushort secretKey)
        {
            ushort secretKey = 0x0088;
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += (char)(c ^ secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }
    }
}
