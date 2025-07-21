using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interpol
{
    class InterpolDatabase
    {
        private List<Criminal> criminals = new List<Criminal>(); // список злочинців
        public void AddCriminal(Criminal criminal) // додавання злочинця до бази даних
        {
            criminals.Add(criminal);
            Console.ForegroundColor = ConsoleColor.Green; // встановлюємо колір тексту на зелений
            Console.WriteLine("Злочинець доданий до бази даних.");
            Console.ResetColor(); // скидаємо колір тексту до стандартного
        }

        public void ShowCriminals(bool archived = false) // показати злочинців з можливістю фільтрації за архівним статусом
        {
            var list = criminals.Where(c => c.IsArchived == archived).ToList(); // показати злочинців, які відповідають архівному статусу
            if (list.Count == 0)
            {
                Console.WriteLine("Немає записiв.");
                return;
            }
            foreach (var c in list) // перебір злочинців у списку та виведення їх інформації на консоль
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // встановлюємо колір тексту на магенту
                Console.WriteLine("===========================================");
                Console.WriteLine($"Кличка: {c.NickName}");
                Console.WriteLine($"Iм'я: {c.FirstName} {c.LastName}");
                Console.WriteLine($"Вiк: {(DateTime.Now.Year - c.DateOfBirth.Year)}");
                Console.WriteLine($"Зрiст: {c.Height} см");
                Console.WriteLine($"Колiр очей: {c.EyeColor}");
                Console.WriteLine($"Колiр волосся: {c.HairColor}");
                Console.WriteLine($"Особливi прикмети: {c.SpecialMarks}");
                Console.WriteLine($"Громадянство: {c.Citizenship}");
                Console.WriteLine($"Мiсце народження: {c.PlaceOfBirth}");
                Console.WriteLine($"Останнє мiсце проживання: {c.LastResidence}");
                Console.WriteLine($"Кримiнальна професiя: {c.CriminalProf}");
                Console.WriteLine($"Останнiй злочин: {c.LastCrime}");
                Console.WriteLine($"Спiльники: {string.Join(", ", c.Accomplices)}");
                Console.WriteLine($"Архiвний статус: {(c.IsArchived ? "Так" : "Нi")}");
                Console.WriteLine($"Статус смертi: {(c.IsDeceased ? "Так" : "Нi")}");
                Console.WriteLine("===========================================");
                Console.ResetColor();
            }
        }
        public void ArchiveCriminal(string nickname) // архівувати злочинця за кличкою
        {
            var criminal = criminals.FirstOrDefault(c => c.NickName.Equals(nickname, StringComparison.OrdinalIgnoreCase)); // пошук злочинця за кличкою
            if (criminal != null)
            {
                criminal.IsArchived = true; // встановлюємо архівний статус
                Console.WriteLine($"Злочинець {criminal.NickName} доданий до архiву.");
            }
            else
            {
                Console.WriteLine("Злочинець не знайдений.");
            }
        }
        public void Delete(string nickname) // метод для видалення злочинця за кличкою
        {
            var criminal = criminals.FirstOrDefault(c => c.NickName.Equals(nickname, StringComparison.OrdinalIgnoreCase));
            if (criminal != null)
            {
                criminals.Remove(criminal); // видаляємо злочинця з бази даних
                Console.WriteLine($"Злочинець {criminal.NickName} видалений з бази даних.");
            }
            else
            {
                Console.WriteLine("Злочинець не знайдений.");
            }
        }
        public void FilterByProf(string prof) // метод для фільтрації злочинців за кримінальною професією
        {
            var filtered = criminals.Where(c => c.CriminalProf.Equals(prof, StringComparison.OrdinalIgnoreCase)).ToList(); // фільтрація злочинців за кримінальною професією
            if (filtered.Count == 0) // перевірка наявності злочинців з вказаною кримінальною професією
            {
                Console.WriteLine("Немає злочинцiв з такою кримiнальною професiєю.");
                return;
            }
            Console.WriteLine($"Злочинцi з кримiнальною професiєю '{prof}':");
            foreach (var criminal in filtered) // перебір злочинців, які відповідають фільтру
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // встановлюємо колір тексту на магенту
                Console.WriteLine($"Iм'я: {criminal.FirstName}\nПрiзвище: {criminal.LastName}\nКличка: {criminal.NickName}\nКримiнальна професiя: {criminal.CriminalProf}\n ");
                Console.ResetColor();
            }
        }
    }
}
