using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Задача на копейки"; // заголовок формы

            nameKopeiki.Text = Properties.Settings.Default.n.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)  // кнопка "посчитать"
        {

            var n = int.Parse(this.nameKopeiki.Text);

            if (1 <= n && n <= 9999)
            {
                MessageBox.Show(Logic.MainLogic(n));
            }
            else MessageBox.Show("Неверно введена стоимость товара ");
            Properties.Settings.Default.n = n;
            Properties.Settings.Default.Save();   // автосохранение
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nameKopeiki_TextChanged(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)  // кнопка очистить
        {
            nameKopeiki.Text = "";
        }

        
    }
    public class Logic
    {
        public static string MainLogic(int n)
        {
            int rubles = n / 100, copeys = n % 100;
            string OutMessage = "";                           // Создаём переменную для вывода сообщения
            string OutRubles = "";                            // Создаём переменную для хранения рублей 
            string OutCopeys = "";                            // Создаём переменную для хранения копеек
            if (rubles > 0)
            {
                OutRubles = Convert.ToString(rubles);        // преобразование в строковое представление
                if (5 <= rubles && rubles <= 20) OutRubles = OutRubles + " рублей "; 
                else if (rubles % 10 == 1) OutRubles = OutRubles + " рубль ";
                else if (rubles % 10 == 2 || rubles % 10 == 3 || rubles % 10 == 4) OutRubles = OutRubles + " рубля";
                else OutRubles = OutRubles + " рублей ";
            }
            if (copeys > 0)
            {
                OutCopeys = Convert.ToString(copeys);
                if (5 <= copeys && copeys <= 20) OutCopeys = OutCopeys + " копеек";
                else if (copeys % 10 == 1) OutCopeys = OutCopeys + " копейка";
                else if (copeys % 10 == 2 || copeys % 10 == 3 || copeys % 10 == 4) OutCopeys = OutCopeys + " копейки";
                else OutCopeys = OutCopeys + " копеек";        
            }
            OutMessage = OutRubles + "" + OutCopeys;
            return OutMessage;
        }
    }

}
