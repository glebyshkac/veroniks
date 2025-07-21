using System.Text;
using Interpol;
internal class Program
{
    static void Main()
    {
        InterpolDatabase form = new InterpolDatabase(); // створення нового об'єкта бази даних Interpol
        Console.Clear(); // очищення консолі
        Console.ForegroundColor = ConsoleColor.Cyan; // встановлюємо колір тексту на блакитний
        Console.WriteLine("===========================================");
        Console.WriteLine("     К А Р Т О Т Е К А   I Н Т Е Р П О Л У  ");
        Console.WriteLine("===========================================");
        Console.ResetColor(); // скидання кольору тексту до стандартного
        Console.WriteLine("Введiть своє iм'я");
        string userName = Console.ReadLine();
        Console.WriteLine($"Вiтаємо, {userName}! Доступ до Картотеки iнтерполу надано. \n");

        bool run = true;
        while (run)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // встановлюємо колір тексту на жовтий
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати злочинця");
            Console.WriteLine("2. Переглянути базу");
            Console.WriteLine("3. Перемiстити в архiв");
            Console.WriteLine("4. Видалити ( за умовою смертi )");
            Console.WriteLine("5. Пошук злочинця за злочинною професiєю");
            Console.WriteLine("6. Вихiд");
            Console.Write("Виберiть опцiю: ");
            Console.ResetColor();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // додавання злочинця
                    Criminal criminal = new Criminal(); // створення нового об'єкта злочинця
                    Console.Write("Введiть прiзвище: ");
                    criminal.LastName = Console.ReadLine();
                    Console.Write("Введiть iм'я: ");
                    criminal.FirstName = Console.ReadLine();
                    Console.Write("Введiть кличку: ");
                    criminal.NickName = Console.ReadLine();
                    Console.Write("Введiть зрiст: ");
                    criminal.Height = int.Parse(Console.ReadLine());
                    Console.Write("Введiть колiр волосся: ");
                    criminal.HairColor = Console.ReadLine();
                    Console.Write("Введiть колiр очей: ");
                    criminal.EyeColor = Console.ReadLine();
                    Console.Write("Введiть особливi прикмети: ");
                    criminal.SpecialMarks = Console.ReadLine();
                    Console.Write("Введiть громадянство: ");
                    criminal.Citizenship = Console.ReadLine();
                    Console.Write("Введiть дату народження (дд.мм.рррр): ");
                    criminal.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введiть мiсце народження: ");
                    criminal.PlaceOfBirth = Console.ReadLine();
                    Console.Write("Введiть останнє мiсце проживання: ");
                    criminal.LastResidence = Console.ReadLine();
                    Console.Write("Введiть кримiнальну професiю: ");
                    criminal.CriminalProf = Console.ReadLine();
                    Console.Write("Введiть останнiй злочин: ");
                    criminal.LastCrime = Console.ReadLine();
                    Console.WriteLine("Введiть iмена спiльникiв (введiть 'стоп' щоб завершити):");
                    while (true) // цикл для введення спiльникiв
                    {
                        Console.Write("Спiльник: ");
                        string accomplice = Console.ReadLine();
                        if (accomplice.Trim().ToLower() == "стоп") break;
                        if (!string.IsNullOrWhiteSpace(accomplice))
                        {
                            criminal.Accomplices.Add(accomplice); // додавання спiльника до списку
                        }
                    }

                    form.AddCriminal(criminal);
                    break;
                case "2": // перегляд бази даних злочинців
                    Console.Write("Показати архiвнi записи? (так/нi): ");
                    string arch = Console.ReadLine();
                    bool showArchived = arch.ToLower() == "так";
                    form.ShowCriminals(showArchived);
                    break;
                case "3": // переміщення злочинця в архів
                    Console.Write("Введiть кличку злочинця для архiвацiї: ");
                    string nicknameToArchive = Console.ReadLine();
                    form.ArchiveCriminal(nicknameToArchive);
                    break;
                case "4": // видалення злочинця за умовою смерті    
                    Console.Write("Введiть кличку злочинця для видалення: ");
                    string nicknameToDelete = Console.ReadLine();
                    form.Delete(nicknameToDelete);
                    break;
                case "5": // пошук за професією
                    Console.Write("Введiть злочинну професiю для пошуку: ");
                    string profession = Console.ReadLine();
                    form.FilterByProf(profession);
                    break;
                case "6":
                    run = false; // вихiд з програми
                    Console.WriteLine("Дякуємо за використання Картотеки iнтерполу!");
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр.");
                    break;

            }
        }    
    }
}