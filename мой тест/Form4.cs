using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace мой_тест
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //для чтения вопросов из файла questions.txt:
        string s;
        const int n = 16;
        int numb = 0;
        string[] bufq = new string[n];
        //для чтения ответов из файла points.txt и записи ответов в массивы yes и no, nes, otkaz:
        const int m = 16;
        int[] yes = new int[m];
        int[] no = new int[m];
        int[] nes = new int[m];
        int[] otkaz = new int[m];
        string[] buf;
        int ball = 0;//баллы
        string t1, t2, t3;
        //результаты

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //чтение из points.txt в массивы yes и no, nes, otkazpoints.txt
            try
            {
                StreamReader fp = new StreamReader(@"/home/kababik/Рабочий стол/мой тест/bin/Debug/points.txt");
                while (fp.Peek() > -1)
                {
                    buf = fp.ReadLine().Split(',');
                    if (buf[0].ToString() == "yes")
                        for (int i = 1; i < buf.Length ; ++i)
                            yes[i] = int.Parse(buf[i]);
                                        else if (buf[0].ToString() == "no")
                        for (int i = 1; i < buf.Length ; ++i)
                            no[i] = int.Parse(buf[i]);
                    else if (buf[0].ToString() == "nes")
                        for (int i = 1; i < buf.Length; ++i)
                            nes[i] = int.Parse(buf[i]);
                    else if (buf[0].ToString() == "otkaz")
                        for (int i = 1; i < buf.Length; ++i)
                            nes[i] = int.Parse(buf[i]);
                }
                fp.Close();
                StreamReader fq = new StreamReader("questions.txt", System.Text.Encoding.Default);
                while ((s = fq.ReadLine()) != null)
                {
                    bufq[numb] = s;
                    numb++;
                }
                numb = 0;
                fq.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Проверьте правильность имени файла!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            //отображение первого вопроса при запуске формы:
            textBox1.Text = (numb + 1).ToString();
            richTextBox1.Text = bufq[numb];
            numb++;
            //При загрузке формы выбран один из вариантов ответа:
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           switch (Convert.ToInt32(textBox1.Text))
            {
                case 4:
                    {
                        checkBox1.Visible = true;
                        break;
                    }
                default:
                    {
                        checkBox1.Visible = false;
                        break;
                    }
            }
            //Показываем результаты тестирования в зависимости от набранных баллов
            if (button1.Text == "Результаты")
            {
               if (ball >= 0 && ball <= 95)
                {
                    t1 = "От 0 до 95";//результат
                    t2 = "Вы привыкли плыть по течению. Быть руководителем - не ваша стезя. Гораздо проще выполнять чьи-то приказы, чем брать инициативу в свои руки и нести за это ответственность, однако каждый выбирает свой путь, ведь. если есть начальники, должны быть и подчиненные.";
                    t3 = "b.jpg";
                   // Указывается путь и имя картинки, соответствующей набранному колличеству баллов.                                  
                }
                if (ball >= 96 && ball <= 115)
                {
                    t1 = "От 96 до 115";
                    t2 = "Начальник вы или подчиненный? Все завист от ситуации. Вы можете и руководить, если видите в этом какую-либо выгоду,и подчиняться, если считаете, что лучше для вас будет на время спрятаться в тень.";
                    t3 = "f.jpg";
                }
                if (ball >= 116 )
                {
                   t1 = "Более 116";
                   t2 = "Безусловно вы начальник. Если вы все еще не занимаете ответственного поста, это большая ошибка со стороны вашего босса. Вы обладаете такими качествами, как честность, независимость, принципиальность, трудолюбие и решительность. Вам свойственны профессионализм, умение находить подход к людям и организаторские способности."; 
                   t3 = "c.jpg";
                }
                Form5 f5 = new Form5();
                f5.label1.Text = t1;
                f5.richTextBox1.Text = t2;
                f5.pictureBox1.Text = t3;
                f5.Show();
                this.Close();

            }
            //считываем из буфера bufq, в котором находятся вопросы:
            if (numb < n - 1)
            {
                textBox1.Text = (numb + 1).ToString();
                richTextBox1.Text = bufq[numb];
                numb++;
            }
            else
            {
                textBox1.Text = "0";
                richTextBox1.Text = "Тестирование завершено.";
                button1.Text = "Результаты";
            }
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            radioButton1.Enabled = true;
            radioButton3.Enabled = true;
            radioButton2.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ball += yes[numb];
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                ball += no[numb];
                radioButton1.Enabled = false;
                radioButton3.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                ball += nes[numb];
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ball += otkaz[numb];
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

    }
}
