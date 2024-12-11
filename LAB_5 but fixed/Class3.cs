using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_5_test
{
    internal class Logger
    {
        private string _logFilePath;

        // Конструктор класса Logger
        public Logger(string filePath, bool append = true)
        {
            // Определяем, будем ли мы добавлять в существующий файл или создавать новый
            _logFilePath = filePath;

            // Если файл не существует, создаем новый
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Close();
            }

            // Если append = true, добавляем к существующему файлу, иначе создаем новый
            if (!append)
            {
                File.WriteAllText(_logFilePath, string.Empty); // Очищаем файл
            }
        }

        // Метод для записи сообщений в лог
        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";

            // Записываем сообщение в файл
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}
