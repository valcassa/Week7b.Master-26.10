using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7b.Master.MVC.Models
{
    public class LezioneViewModel
    {

        public int IdLezione { get; set; }
        public DateTime DataInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }
    }
}
