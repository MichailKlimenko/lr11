using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace лр11
{
    // Объявляем обобщенный класс ArrayProcessor с ограничением на тип T, который должен реализовывать интерфейс IComparable.
    public class ArrayProcessor<T> where T : IComparable
    {
        // Объявляем открытое поле array для хранения элементов массива.
        public T[] array;

        // Конструктор класса ArrayProcessor, принимающий произвольное количество элементов массива.
        public ArrayProcessor(params T[] elements)
        {
            // Присваиваем полю array переданные элементы.
            array = elements;
        }

        // Конструктор класса ArrayProcessor, заполняющий массив заданным количеством элементов из файла с указанным именем.
        public ArrayProcessor(int count, string fileName)
        {
            try
            {
                // Считываем все строки из файла.
                string[] lines = File.ReadAllLines(fileName);
                // Инициализируем массив array указанным количеством элементов.
                array = new T[count];
                // Заполняем массив элементами, преобразуя строки из файла в тип T.
                for (int i = 0; i < count; i++)
                {
                    array[i] = (T)Convert.ChangeType(lines[i], typeof(T));
                }
            }
            catch (Exception ex)
            {
                // В случае возникновения исключения при чтении файла, выбрасываем исключение с сообщением об ошибке.
                throw new Exception($"Ошибка при заполнении массива из файла: {ex.Message}");
            }
        }

        // Свойство Length для получения количества элементов в массиве.
        public int Length => array.Length;

        // Метод SumBetweenNegatives для вычисления суммы элементов массива, расположенных между первым и вторым отрицательными элементами.
        public T SumBetweenNegatives()
        {
            try
            {
                // Находим индекс первого отрицательного элемента в массиве.
                int firstNegativeIndex = Array.FindIndex(array, x => x.CompareTo(default(T)) < 0);
                // Находим индекс второго отрицательного элемента, начиная поиск с индекса после первого отрицательного элемента.
                int secondNegativeIndex = Array.FindIndex(array, firstNegativeIndex + 1, x => x.CompareTo(default(T)) < 0);

                // Если не найдены оба отрицательных элемента, выбрасываем исключение.
                if (firstNegativeIndex == -1 || secondNegativeIndex == -1)
                {
                    throw new Exception("В массиве нет отрицательных элементов.");
                }

                // Инициализируем переменную sum с типом T для хранения суммы.
                dynamic sum = default(T);
                // Суммируем элементы массива между первым и вторым отрицательными элементами.
                for (int i = Math.Min(firstNegativeIndex, secondNegativeIndex) + 1; i < Math.Max(firstNegativeIndex, secondNegativeIndex); i++)
                {
                    sum += array[i];
                }

                // Возвращаем сумму.
                return sum;
            }
            catch (Exception ex)
            {
                // В случае возникновения исключения при вычислении суммы, выбрасываем исключение с сообщением об ошибке.
                throw new Exception($"Ошибка при вычислении суммы: {ex.Message}");
            }
        }
    }
}
