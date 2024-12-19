using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumakov_DZ;

namespace DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var project = new Project("Разработка игры на Unity");
            Console.WriteLine($"Проект \"{project.Name}\" создан в статусе: {project.Status}");

            // Список исполнителей
            var teamMembers = new Dictionary<string, string>
            {
                { "Иван", "Разработка механики движения персонажа" },
                { "Мария", "Создание главного меню и интерфейса" },
                { "Сергей", "Проектирование уровней" },
                { "Анна", "Анимация персонажей" },
                { "Дмитрий", "Создание искусственного интеллекта противников" },
                { "Елена", "Разработка системы инвентаря" },
                { "Олег", "Оптимизация производительности" },
                { "Светлана", "Добавление визуальных эффектов" },
                { "Андрей", "Сценарий и диалоги" },
                { "Татьяна", "Тестирование и отладка" }
            };

            // Добавление задач
            foreach (var member in teamMembers)
            {
                var task = new Task(member.Value, member.Key);
                project.AddTask(task);
            }
            Console.WriteLine("Все задачи назначены.");

            // Изменение статуса проекта
            project.StartExecution();

            // Выполнение задач
            foreach (var task in project.Tasks)
            {
                task.StartWork();
                task.SendForReview();
                task.CompleteTask();
            }

            // Завершение проекта
            project.CloseProject();
        }
    }
}
