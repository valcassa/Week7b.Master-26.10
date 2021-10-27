using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7b.Master.MVC.Models
{
    public class StudenteViewModel
    {
        [Required]
        public int IdStudente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
      
        public DateTime DataNascita { get; set; }
        public string Titolo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        internal static void Add(StudenteViewModel studenteViewModel)
        {
            throw new NotImplementedException();
        }

        internal static void Add(DocenteViewModel docenteViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
