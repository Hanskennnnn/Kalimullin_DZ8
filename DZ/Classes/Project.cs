using System;
using Tumakov_DZ;

namespace DZ
{
    public class Project
    {
        public string Name { get; set; }
        public ProjectStatus Status { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Project(string name)
        {
            Name = name;
            Status = ProjectStatus.Проект;
            Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                // Выводим только название задачи с цветом
                PrintWithColor($"Добавлена задача: \"{task.Description}\" для {task.Assignee}.", ConsoleColor.Cyan);
                Tasks.Add(task);
            }
        }

        public void StartExecution()
        {
            if (Status == ProjectStatus.Проект)
            {
                Status = ProjectStatus.Исполнение;
                Console.WriteLine($"Статус проекта \"{Name}\" изменен на: Исполнение.");
            }
        }

        public void CloseProject()
        {
            if (Tasks.All(task => task.Status == ProjectTaskStatus.Выполнена))
            {
                Status = ProjectStatus.Закрыт;
                Console.WriteLine($"Проект \"{Name}\" завершен со статусом: Закрыт.");
            }
        }

        private void PrintWithColor(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor; 
            int startIndex = message.IndexOf("\"") + 1;
            int endIndex = message.LastIndexOf("\"");           
            Console.Write(message.Substring(0, startIndex));       
            Console.ForegroundColor = color;
            Console.Write(message.Substring(startIndex, endIndex - startIndex));     
            Console.ForegroundColor = previousColor;
            Console.WriteLine(message.Substring(endIndex));
        }
    }

}
