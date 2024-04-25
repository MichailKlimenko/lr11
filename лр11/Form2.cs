using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр11
{
    public partial class Form2 : Form
    {
        private SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

        public Form2()
        {
            InitializeComponent();

            // Заполнение начальными данными
            sortedDictionary.Add(1, "One");
            sortedDictionary.Add(2, "Two");
            sortedDictionary.Add(3, "Three");

            // Вывод начальной коллекции в ListBox
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            // Очищаем ListBox
            listBox1.Items.Clear();

            // Добавляем элементы из коллекции в ListBox
            foreach (var item in sortedDictionary)
            {
                listBox1.Items.Add(item.Value);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Удаление n последовательных элементов
            int n;
            if (int.TryParse(textBox1.Text, out n))
            {
                // Проверяем, достаточно ли элементов для удаления
                if (n <= sortedDictionary.Count)
                {
                    List<int> keysToRemove = new List<int>(sortedDictionary.Keys);
                    for (int i = 0; i < n; i++)
                    {
                        sortedDictionary.Remove(keysToRemove[i]);
                    }

                    // Обновляем ListBox после удаления элементов
                    UpdateListBox();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить " + n + " элементов, так как коллекция содержит меньшее количество элементов.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для n.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Добавление элемента в коллекцию
            string newItem = textBox2.Text;
            if (!string.IsNullOrEmpty(newItem))
            {
                // Генерируем ключ
                int newKey = sortedDictionary.Count + 1;

                // Добавляем новый элемент в коллекцию
                sortedDictionary.Add(newKey, newItem);

                // Обновляем ListBox после добавления элемента
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите значение для добавления в коллекцию.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Создание второй коллекции и заполнение данными из первой
            List<string> list = new List<string>(sortedDictionary.Values);

            // Вывод второй коллекции на ListBox2
            listBox2.Items.Clear();
            foreach (var item in list)
            {
                listBox2.Items.Add(item);
            }

            // Проверка на совпадение количества параметров
            if (listBox1.Items.Count == listBox2.Items.Count)
            {
                MessageBox.Show("Количество параметров в обеих коллекциях совпадает.");
            }
            else
            {
                MessageBox.Show("Количество параметров в обеих коллекциях не совпадает.");
            }
        }
    }
}
