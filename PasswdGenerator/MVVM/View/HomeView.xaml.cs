using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        List<byte[]> bytePasswords = new();
        List<string> passwords = new();
        string path = "pswdbase.txt";

        public HomeView()
        {
            InitializeComponent();
            lbPasswords.ItemsSource = passwords;
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

        private void lbPasswords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (lbPasswords.SelectedItem != null)
                {
                    _ = passwords.Remove(lbPasswords.SelectedItem.ToString());
                    lbPasswords.Items.Refresh();
                }
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SavePasswdInFile();
        }

        // Доработать шифрование
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

        public static string EncodeDecrypt(string str)//, ushort secretKey)
        {
            ushort secretKey = 0x0088;
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += (char)(c ^ secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
    }
}
