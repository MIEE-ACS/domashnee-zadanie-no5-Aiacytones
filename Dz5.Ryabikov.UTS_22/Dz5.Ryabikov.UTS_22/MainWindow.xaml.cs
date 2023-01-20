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

namespace Dz5.Ryabikov.UTS_22
{
    class Tovar
    {
        public double article_number;
        public string name;
        public decimal price;
        public override string ToString()
        {
            return String.Format($"{article_number},{name},{price}");
        }
    }
    class Add_product : Tovar
    {
        public Add_product(double article_number, string name, int price)
        {
            this.article_number = article_number;
            this.name = name;
            this.price = price;

        }
    }
    public partial class MainWindow : Window
    {
        class Tovar
        {
            public double article_number;
            public string name;
            public decimal price;
            public int year_of_release;
            public override string ToString()
            {
                return String.Format($"{article_number},{name},{price}");
            }
        }
        static bool CheckNumber(string s) //Функция для проверки строки на содержание символов(для преобразования в число)
        {
            foreach (char item in s) //Цикл для поочередного обращения к элементам строки
            {
                if (item != ',')
                {
                    if (char.IsDigit(item) == false) // IsDigit функция определяет относится ли символ к категории чисел
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public MainWindow()
        {
            InitializeComponent();
            comboBox_product.Items.Add("");
            button_add.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            textBox2.Visibility = Visibility.Hidden;
            textBox3.Visibility = Visibility.Hidden;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button_add.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
        }
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNumber(textBox1.Text) || (textBox1.Text == "") || (textBox2.Text == "") || CheckNumber(textBox3.Text) || (textBox3.Text == ""))
            {
                MessageBox.Show("Ошибка. Введите все данные о товаре");
            }
            else if (CheckNumber(textBox2.Text) == false)
            {
                MessageBox.Show("Ошибка. Наименование не может включать числа");
            }
            else
            {
                double article_number = double.Parse(textBox1.Text);
                string name = textBox2.Text;
                int price = int.Parse(textBox3.Text);
                Add_product product = new Add_product(article_number, name, price);
                comboBox_product.Items.Add(product);
                MessageBox.Show("Добавлено");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                button_add.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
                label2.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                textBox1.Visibility = Visibility.Hidden;
                textBox2.Visibility = Visibility.Hidden;
                textBox3.Visibility = Visibility.Hidden;
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(comboBox_product.SelectedItem) == "")
            {
                MessageBox.Show("Ошибка. Выберите товар");
            }
            else if (CheckNumber(textBox4.Text) || (textBox4.Text == ""))
            {
                MessageBox.Show("Ошибка. Введите год изготовления");
            }
            else if (CheckNumber(textBox5.Text) || (textBox5.Text == ""))
            {
                MessageBox.Show("Ошибка. Введите срок годности");
            }
            else
            {
                var now = DateTime.Now;
                var year = int.Parse(textBox4.Text);
                var month = int.Parse(textBox5.Text);
                while (month > 12)
                {
                    month = month - 12;
                    year = year + 1;
                }
                var Valid_until = new DateTime(year, month, 1);
                if (Valid_until > now)
                {
                    textBox_l.Text = "Товар годен";
                }
                else textBox_l.Text = "Товар не годен";
            }
        }
    }
}