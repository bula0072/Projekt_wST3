using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_w58954
{
    public class Przedmiot
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa_przedmiotu { get; set; }
        [Required]
        public int Ilosc_godzin { get; set; }
        [Required]
        [StringLength(255)]
        public string Forma_przedmiotu { get; set; }
        [Required]
        [StringLength(255)]
        public string Prowadzacy { get; set; }
        public List<Student_Przedmiot> Student_Przedmiots { get; set; }
    }
}
