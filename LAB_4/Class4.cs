using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB_4
{
    // Класс для участников олимпиады
    [Serializable] // Сериализация в XML
    public class Participant
    {
        public string LastName { get; set; } // Фамилия
        public string FirstName { get; set; } // Имя
        public int[] Scores { get; set; } // Баллы за задания

        // Метод для подсчёта общего количества баллов
        public int TotalScore()
        {
            return Scores.Sum();
        }

    }

    public static class Olimpiada {

        // Метод для чтения данных об участниках с консоли
        public static List<Participant> ReadParticipants()
        {
            List<Participant> participants = new List<Participant>();

            Console.WriteLine("Введите количество участников:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Participant participant = null;
                bool validInput = false;

                // Запрашиваем данные до тех пор, пока не будет введено корректное значение
                while (!validInput)
                {
                    Console.WriteLine($"Введите данные для участника {i + 1} (Фамилия Имя Баллы):");
                    string[] input = Console.ReadLine().Split();

                    // Создаем участника
                    participant = new Participant
                    {
                        LastName = input[0],
                        FirstName = input[1],
                        Scores = new int[3]
                    };

                    // Проверяем баллы
                    validInput = true;
                    for (int j = 0; j < 3; j++)
                    {
                        if (int.TryParse(input[j + 2], out int score) && score >= 0 && score <= 25)
                        {
                            participant.Scores[j] = score;
                        }
                        else
                        {
                            validInput = false;
                            Console.WriteLine("Ошибка! Все баллы должны быть числами от 0 до 25. Повторите ввод.");
                            break; // Если один из баллов некорректен, прерываем проверку
                        }
                    }
                }
                participants.Add(participant);
            }
            return participants;
        }

        // Метод для сериализации участников в XML файл
        public static void SaveParticipantsToXml(List<Participant> participants, string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Participant>));
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, participants);
                }
                Console.WriteLine("Данные участников успешно сохранены в XML файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в XML файл: {ex.Message}");
            }
        }

        // Метод для десериализации участников из XML файла
        public static List<Participant> LoadParticipantsFromXml(string filePath)
        {
            List<Participant> participants = new List<Participant>();

            try
            {
                var serializer = new XmlSerializer(typeof(List<Participant>));
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    participants = (List<Participant>)serializer.Deserialize(fs);
                }
                Console.WriteLine("Данные успешно загружены из XML файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении из XML файла: {ex.Message}");
            }

            return participants;
        }

        // Метод для отображения участников с максимальным количеством баллов
        public static void DisplayTopScorers(List<Participant> participants)
        {
            int maxScore = participants.Max(p => p.TotalScore());
            var topScorers = participants.Where(p => p.TotalScore() == maxScore);

            Console.WriteLine("Участники с максимальным количеством баллов:");
            foreach (var participant in topScorers)
            {
                Console.WriteLine($"{participant.LastName} {participant.FirstName}");
            }
        }
    }

}
