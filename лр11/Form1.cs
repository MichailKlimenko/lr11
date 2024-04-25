using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр11
{
    public partial class Form1 : Form
    {
        // Объявляем поле arrayProcessor, представляющее объект класса ArrayProcessor<int>.
        private ArrayProcessor<int> arrayProcessor;

        // Конструктор класса Form1.
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки button2.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // Пытаемся получить количество элементов из текстового поля textBox1.
                    int count = int.Parse(textBox1.Text);
                    string fileName = "File.txt"; // Имя файла
                    // Проверяем существование файла.
                    if (File.Exists(fileName))
                    {
                        // Создаем экземпляр класса ArrayProcessor и заполняем массив из файла.
                        arrayProcessor = new ArrayProcessor<int>(count, fileName);
                        MessageBox.Show($"Массив успешно заполнен из файла {fileName}.");
                    }
                    else
                    {
                        MessageBox.Show($"Файл {fileName} не найден.");
                    }
                }
                catch (Exception ex)
                {
                    // Выводим сообщение об ошибке в случае исключения при заполнении массива из файла.
                    MessageBox.Show($"Ошибка при заполнении массива из файла: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке в случае исключения.
                MessageBox.Show($"Ошибка при заполнении массива из файла: {ex.Message}");
            }
        }

        // Свойство ArrayLength для получения количества элементов массива.
        private int ArrayLength => arrayProcessor?.Length ?? 0;

        // Обработчик события нажатия кнопки button4.
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (arrayProcessor == null || arrayProcessor.Length == 0)
            {
                listBox1.Items.Add("Массив не заполнен.");
            }
            else
            {
                listBox1.Items.Add("Элементы массива:");
                // Выводим элементы массива в ListBox.
                foreach (var num in arrayProcessor.array)
                {
                    listBox1.Items.Add(num);
                }
            }
        }

        // Обработчик события нажатия кнопки button3.
        private void button3_Click(object sender, EventArgs e)
        {
            // Проверяем, что массив не пустой.
            if (arrayProcessor == null || arrayProcessor.Length == 0)
            {
                MessageBox.Show("Массив не заполнен.");
                return;
            }

            try
            {
                // Вычисляем сумму между отрицательными элементами с использованием метода из ArrayProcessor.
                int sum = arrayProcessor.SumBetweenNegatives();
                listBox1.Items.Add($"Сумма элементов между первым и вторым отрицательными: {sum}");
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке в случае исключения при вычислении суммы.
                MessageBox.Show($"Ошибка при вычислении суммы: {ex.Message}");
            }
        }

        // Обработчик события нажатия пункта меню задание2ToolStripMenuItem.
        private void задание2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы Form2 и отображаем её.
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
