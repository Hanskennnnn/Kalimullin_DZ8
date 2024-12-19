using System;
namespace DZ
{
    public class Task
    {
        public string Description { get; set; }
        public string Assignee { get; private set; }
        public ProjectTaskStatus Status { get; private set; }

        public Task(string description, string assignee)
        {
            Description = description;
            Assignee = assignee;
            Status = ProjectTaskStatus.Назначена;
        }

        public void StartWork()
        {
            if (Status == ProjectTaskStatus.Назначена)
            {
                Status = ProjectTaskStatus.В_работе;
                PrintWithColor($"Задача \"{Description}\" в работе у {Assignee}.", ConsoleColor.Green);
            }
        }

        public void SendForReview()
        {
            if (Status == ProjectTaskStatus.В_работе)
            {
                Status = ProjectTaskStatus.На_проверке;
                PrintWithColor($"Задача \"{Description}\" отправлена на проверку.", ConsoleColor.Green);
            }
        }

        public void CompleteTask()
        {
            if (Status == ProjectTaskStatus.На_проверке)
            {
                Status = ProjectTaskStatus.Выполнена;
                PrintWithColor($"Задача \"{Description}\" выполнена.", ConsoleColor.Green);
            }
        }

        private void PrintWithColor(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor; // Сохранить текущий цвет
            int startIndex = message.IndexOf(Description);
            int endIndex = startIndex + Description.Length;

            // Выводим часть сообщения до названия задачи с обычным цветом
            Console.Write(message.Substring(0, startIndex));

            // Выводим название задачи с нужным цветом
            Console.ForegroundColor = color;
            Console.Write(message.Substring(startIndex, Description.Length));

            // Выводим оставшуюся часть сообщения с обычным цветом
            Console.ForegroundColor = previousColor;
            Console.WriteLine(message.Substring(endIndex));
        }
    }
}
