using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4
{
    public static class ListsAndMore
    {

        // ЗАДАНИЕ 1

        public static void Replace(List<string> L, List<string> L1, List<string> L2)
        {
            int index = FindIndex(L, L1);

            if (index != -1)
            {
                // Удаляем элементы L1 начиная с найденного индекса
                L.RemoveRange(index, L1.Count);
                // Вставляем элементы L2 на место удаленного подсписка
                L.InsertRange(index, L2);
            }
        }

        private static int FindIndex(List<string> L, List<string> L1)
        {
            for (int i = 0; i <= L.Count - L1.Count; i++)
            {
                // Получаем подсписок длиной равной длине L1, начиная с индекса i и сравниваем подсписок с L1
                if (L.Skip(i).Take(L1.Count).SequenceEqual(L1))
                {
                    return i;
                }
            }
            return -1;
        }
        public static List<string> ReadList()
        {
            return Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();
        }



        // ЗАДАНИЕ 2

        // Метод сортировки двусвязного списка строк (вставки)
        public static void SortLinkedList(LinkedList<string> list)
        {
            if (list == null || list.Count < 2)
                return;

            var current = list.First.Next;
            while (current != null)
            {
                var next = current.Next;
                var value = current.Value;

                // Определяем, является ли элемент числом
                bool isCurrentNumber = int.TryParse(value, out int numericValue);

                // Находим правильное место для текущего элемента
                var temp = current.Previous;
                while (temp != null)
                {
                    bool isTempNumber = int.TryParse(temp.Value, out int tempNumericValue);

                    // Сравнение как чисел, если оба значения числовые
                    int comparisonResult;
                    if (isCurrentNumber && isTempNumber)
                    {
                        comparisonResult = tempNumericValue.CompareTo(numericValue);
                    }
                    else
                    {
                        // Лексикографическое сравнение, если одно из значений — не число
                        comparisonResult = string.Compare(temp.Value, value, StringComparison.Ordinal);
                    }

                    if (comparisonResult <= 0)
                        break;

                    temp = temp.Previous;
                }

                // Удаляем и вставляем элемент в нужное место
                list.Remove(current);
                if (temp == null)
                {
                    list.AddFirst(value);
                }
                else
                {
                    list.AddAfter(temp, value);
                }

                current = next;
            }
        }

        // Метод для печати списка
        public static void PrintLinkedList(LinkedList<string> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Метод для ввода списка строк из консоли
        public static LinkedList<string> ReadLinkedList()
        {
            LinkedList<string> list = new LinkedList<string>();

            Console.WriteLine("Введите элементы списка через пробел:");
            string input = Console.ReadLine();
            string[] elements = input.Split(' ');

            foreach (string element in elements)
            {
                list.AddLast(element);  // Добавляем строку в список
            }

            return list;
        }


        // ЗАДАНИЕ 4

        public static IEnumerable<char> Letters(string filePath)
        {
            // Глухие согласные
            HashSet<char> Letters = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'ч', 'ц' };

            // Множество для отсутствующих глухих согласных
            HashSet<char> missingLetters = new HashSet<char>(Letters);

            try
            {
                // Читаем текст из файла
                string text = File.ReadAllText(filePath).ToLower();

                // Разделяем текст на слова
                string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '-', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Проверяем каждое слово
                foreach (string word in words)
                {
                    foreach (char letter in Letters)
                    {
                        if (word.Contains(letter))
                        {
                            missingLetters.Remove(letter);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                missingLetters.Clear();
                return missingLetters;
            }

            // Возвращаем отсортированные отсутствующие глухие согласные
            return missingLetters.OrderBy(c => c);
        }
    }
}

