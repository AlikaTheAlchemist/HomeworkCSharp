using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_4
{
    class Program
    {
        static void Main()
        {
            // ЗАДАНИЕ 1

            Console.WriteLine("Введите элементы списка L через запятую:");
            List<string> L = ListsAndMore.ReadList();

            Console.WriteLine("Введите элементы списка L1 через запятую:");
            List<string> L1 = ListsAndMore.ReadList();

            Console.WriteLine("Введите элементы списка L2 через запятую:");
            List<string> L2 = ListsAndMore.ReadList();

            ListsAndMore.Replace(L, L1, L2);

            Console.WriteLine("Результат: " + string.Join(", ", L));



            // ЗАДАНИЕ 2

            // Считываем список с клавиатуры
            LinkedList<string> list = ListsAndMore.ReadLinkedList();

            Console.WriteLine("Исходный список:");
            ListsAndMore.PrintLinkedList(list);

            // Сортируем список
            ListsAndMore.SortLinkedList(list);

            Console.WriteLine("Отсортированный список:");
            ListsAndMore.PrintLinkedList(list);



            // ЗАДАНИЕ 3

            // Ввод полного списка игр из файла
            string Games = "Games.txt";
            HashSet<string> allGames;
            try
            {
                allGames = new HashSet<string>(File.ReadAllLines(Games).Where(line => !string.IsNullOrWhiteSpace(line)));
                Console.WriteLine("Перечень игр загружен из файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
                return;
            }

            // Ввод количества студентов
            Console.WriteLine("Введите количество студентов в группе:");
            int studentCount = int.Parse(Console.ReadLine());

            // Генерация случайных игр для каждого студента
            List<HashSet<string>> studentGames = new List<HashSet<string>>();
            foreach (int i in Enumerable.Range(0, studentCount))
            {
                HashSet<string> games = GameAnalysis.RandomGames(allGames);
                studentGames.Add(games);
                Console.WriteLine($"Игры, в которые играет студент {i + 1}: " + string.Join(", ", games));
            }

            // Вывод результатов
            var PlayedByAll = GameAnalysis.AllPlay(allGames, studentGames);
            var PlayedBySome = GameAnalysis.SomePlay(allGames, studentGames);
            var PlayedByNone = GameAnalysis.NoOnePlay(allGames, studentGames);

            Console.WriteLine();
            Console.WriteLine("Игры, в которые играют все студенты: " + string.Join(", ", PlayedByAll));
            Console.WriteLine("Игры, в которые играют некоторые студенты: " + string.Join(", ", PlayedBySome));
            Console.WriteLine("Игры, в которые не играет ни один студент: " + string.Join(", ", PlayedByNone));


            // ЗАДАНИЕ 4

            // string filePath = "rutext.txt"; // детский диктант на 10 предложений
            string filePath = "rutext2.txt"; // детский диктант поменьше без ф, ш
            //string filePath = "rutext3.txt"; // слова без глухих согласных вообще

            // Вызываем метод для получения отсутствующих глухих согласных
            var missingConsonants = ListsAndMore.Letters(filePath);

            // Выводим отсутствующие глухие согласные в алфавитном порядке
            Console.WriteLine("Глухие согласные, которые не входят хотя бы в одно слово:");
            foreach (char letter in missingConsonants)
            {
                Console.WriteLine(letter);
            }


            // ЗАДАНИЕ 5

            List<Participant> participants = Olimpiada.ReadParticipants();
            string xmlFilePath = "participants.xml";

            // Сериализация данных и сохранение в XML
            Olimpiada.SaveParticipantsToXml(participants, xmlFilePath);

            // Десериализация данных из XML и вывод участников с максимальными баллами
            List<Participant> deserializedParticipants = Olimpiada.LoadParticipantsFromXml(xmlFilePath);
            Olimpiada.DisplayTopScorers(deserializedParticipants);

        }
    }
}
