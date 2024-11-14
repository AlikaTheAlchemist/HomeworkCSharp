using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4
{
    internal class GameAnalysis
    {
        // Метод для определения игр, в которые играют все студенты группы
        public static HashSet<string> AllPlay(HashSet<string> allGames, List<HashSet<string>> studentGames)
        {
            // Начнем с копии множества всех игр, чтобы исключить из него те, в которые не играют все студенты
            HashSet<string> gamesPlayedByAll = new HashSet<string>(allGames);

            foreach (var games in studentGames)
            {
                gamesPlayedByAll.IntersectWith(games); // Оставляем только игры, общие для всех студентов
            }

            return gamesPlayedByAll;
        }


        // Метод для определения игр, в которые играют некоторые студенты группы
        public static HashSet<string> SomePlay(HashSet<string> allGames, List<HashSet<string>> studentGames)
        {
            HashSet<string> gamesPlayedBySome = new HashSet<string>();

            foreach (var games in studentGames)
            {
                gamesPlayedBySome.UnionWith(games); // Объединяем все множества игр, чтобы получить те, в которые играет хотя бы один студент
            }

            return gamesPlayedBySome;
        }


        // Метод для определения игр, в которые не играет ни один студент группы
        public static HashSet<string> NoOnePlay(HashSet<string> allGames, List<HashSet<string>> studentGames)
        {
            // Находим игры, в которые играют некоторые студенты
            HashSet<string> gamesPlayedBySome = SomePlay(allGames, studentGames);

            // Вычитаем их из множества всех игр
            HashSet<string> gamesPlayedByNone = new HashSet<string>(allGames);
            gamesPlayedByNone.ExceptWith(gamesPlayedBySome);

            return gamesPlayedByNone;
        }


        // Метод для получения случайного подмножества игр для студента
        public static HashSet<string> RandomGames(HashSet<string> allGames)
        {
            Random random = new Random();
            HashSet<string> gamesSubset = new HashSet<string>();
            int count = random.Next(1, allGames.Count + 1); // случайное количество игр для студента

            var gamesList = allGames.ToList();
            while (gamesSubset.Count < count)
            {
                string game = gamesList[random.Next(gamesList.Count)];
                gamesSubset.Add(game);
            }

            return gamesSubset;
        }
    }
}
