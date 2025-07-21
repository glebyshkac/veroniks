using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpol
{
    class Criminal
    {
        public string LastName { get; set; } // фамілія
        public string FirstName { get; set; } // ім'я
        public string NickName { get; set; } // кличка
        public int Height { get; set; } // зріст
        public string HairColor { get; set; } // колір волосся
        public string EyeColor { get; set; } // колір очей
        public string SpecialMarks { get; set; } // особливі прикмети
        public string Citizenship { get; set; } // громадянство
        public DateTime DateOfBirth { get; set; } // дата народження
        public string PlaceOfBirth { get; set; } // місце народження
        public string LastResidence { get; set; } // останнє місце проживання
        public string CriminalProf { get; set; } // кримінальна професія
        public string LastCrime { get; set; } // останній злочин
        public List<string> Accomplices { get; set; } = new List<string>(); // спільники
        public bool IsArchived { get; set; } = false; // архівний статус
        public bool IsDeceased { get; set; } = false; // статус смерті
    }
}
