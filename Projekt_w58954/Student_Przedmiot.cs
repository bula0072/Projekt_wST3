using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_w58954
{
    public class Student_Przedmiot
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int Student_id { get; set; }
        public Przedmiot Przedmiot { get; set; }
        public int Przedmiot_id { get; set; }
    }
}
