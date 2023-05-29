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
            /*
+ англ. низкого регистра
+ англ. верхнего регистра
+ рус. низкого регистра
+ рус. верхнего регистра
+ числа
+ спец. символы.
+ уникальность (символов)
уникальность (по отношению к другим паролям)
+ длина
             */
            string passwd = tbPasswd.Text;
            if (passwd.Length == 0) return;

            bool isNumber = false;
            bool isSpecSymbol = false;
            bool isUpperChar = false;
            bool isLowerChar = false;
            bool isUpperCharRu = false;
            bool isLowerCharRu = false;
            bool isUniqueSymbol = true;
            bool isUniquePasswd = false;
            bool isLenght = false;
            int countCrit = 0;

            if (passwd.Length >= 8) isLenght = true;

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

            for (int i = 0; i < passwd.Length; i++)
            {
                for (int j = 0; j < passwd.Length; j++)
                {
                    if (i == j) continue;
                    if (passwd[i] == passwd[j])
                    {
                        isUniqueSymbol = false;
                        break;
                    }
                }
            }
 
            countCrit = Convert.ToInt32(isNumber) + Convert.ToInt32(isSpecSymbol) + Convert.ToInt32(isUpperChar) + Convert.ToInt32(isLowerChar)
                + Convert.ToInt32(isUpperCharRu) + Convert.ToInt32(isLowerCharRu) + Convert.ToInt32(isUniqueSymbol) + Convert.ToInt32(isLenght);


            // Серый - <1 157	157	157
            // Белый <2	255	255	255
            // Зеленый - < 3 30	255	0	
            // Синий < 5 0	112	221
            // Фиолетовый < 7 163	53	238
            // Легендарный < 9 255	128	0

            if (isLenght == false) countCrit--;

            switch (countCrit)
            {
                case -1:
                case 0:
                case 1:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 157, 157, 157));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 157, 157, 157));
                    tbCheckRareResult.Text = "НИЗКИЙ";
                    tbCheckResultText.Text = "Слишком простой пароль. Не подходит для повседневного использования. Рекомендуется сгенерировать новый";
                    break;

                case 2:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    tbCheckRareResult.Text = "ОБЫЧНЫЙ";
                    tbCheckResultText.Text = "Простой пароль. Рекомендуется сгенерировать новый";
                    break;

                case 3:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 22, 185, 0));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 22, 185, 0));
                    tbCheckRareResult.Text = "НЕОБЫЧНЫЙ";
                    tbCheckResultText.Text = "Это необычный пароль, но достаточно надежный. Повысте сложность или сгенерируйте новый";
                    break;

                case 4:
                case 5:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 112, 221));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 112, 221));
                    tbCheckRareResult.Text = "РЕДКИЙ";
                    tbCheckResultText.Text = "Средний пароль. Для стабильности рекомендуется повысить его сложность";
                    break;

                case 6:
                case 7:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 163, 53, 238));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 163, 53, 238));
                    tbCheckRareResult.Text = "ЭПИЧНЫЙ";
                    tbCheckResultText.Text = "Надежный пароль. Подходит для повседневного использования";
                    break;

                case 8:
                case 9:
                    bCheck.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));
                    tbCheckRareResult.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));
                    tbCheckRareResult.Text = "ЛЕГЕНДАРНЫЙ";
                    tbCheckResultText.Text = "В надежности этого пароля не стоит сомневаться. Он прослужит вам долгие столетия. Можно передавать по наследству";
                    break;

                default:
                    bCheck.Visibility = Visibility.Hidden;
                    bGoGenerate.Visibility = Visibility.Hidden;
                    tbCheckRareResult.Visibility = Visibility.Hidden;
                    tbCheckResultText.Visibility = Visibility.Hidden;
                    break;
            }
            bCheck.Visibility = Visibility.Visible;
            bGoGenerate.Visibility = Visibility.Visible;
            tbCheckRareResult.Visibility = Visibility.Visible;
            tbCheckResultText.Visibility = Visibility.Visible;
        }
    }
}
