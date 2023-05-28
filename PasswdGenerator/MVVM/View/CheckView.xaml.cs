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

namespace PasswdGenerator.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для CheckView.xaml
    /// </summary>
    public partial class CheckView : UserControl
    {
        private const string lowerCaseCharsRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string specialChars = "!@#$%^&*()_+";
        private const string numbers = "0123456789";

        public CheckView()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string passwd = tbPasswd.Text;
            bool isNumber = false;
            bool isSpecSymbol = false;
            bool isUpperChar = false;
            bool isLowerChar = false;
            bool isUpperCharRu = false;
            bool isLowerCharRu = false;
            bool isUnique = true;
            int numCrit = 0;

            foreach (char c in passwd)
            {
                if (lowerCaseChars.ToUpper().Contains(c))
                {
                    isUpperChar = true;
                }

                if (lowerCaseChars.Contains(c))
                {
                    isLowerChar = true;
                }

                if (lowerCaseCharsRu.ToUpper().Contains(c))
                {
                    isUpperCharRu = true;
                }

                if (lowerCaseCharsRu.Contains(c))
                {
                    isLowerCharRu = true;
                }

                if (specialChars.Contains(c))
                {
                    isSpecSymbol = true;
                }

                if (numbers.Contains(c))
                {
                    isNumber = true;
                }
            }

            foreach (char c1 in passwd)
            {
                foreach (char c2 in passwd)
                {
                    if (c1 == c2)
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
 
            numCrit = Convert.ToInt32(isNumber) + Convert.ToInt32(isSpecSymbol) + Convert.ToInt32(isUpperChar) + Convert.ToInt32(isLowerChar)
                + Convert.ToInt32(isUpperCharRu) + Convert.ToInt32(isLowerCharRu) + Convert.ToInt32(isUnique);


            //for (int i = 0; i < str.Length; i++)
            //{
            //    tmp = 0;
            //    for (int j = 0; j < str.Length; j++)
            //    {
            //        if (str[i] == str[j])
            //        {
            //            tmp++;
            //        }
            //    }
            //    if (tmp == 1)
            //    {
            //        Console.WriteLine("Уникальный символ {0}", str[i]);
            //        count++;
            //    }
            //}

        }
    }
}
