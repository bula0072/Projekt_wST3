using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_w58954
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Imie { get; set; }
        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }
        [Required]
        [StringLength(20)]
        public string Numer_dziennika { get; set; }
        [Required]
        public int Rok_urodzin { get; set; }
        public List<Student_Przedmiot> Student_Przedmiots { get; set; }
    }
}
