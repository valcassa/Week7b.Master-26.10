using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7b.Master.MVC.Models;
using Week7b.Master.Core.Entities;

namespace Week7b.Master.MVC.Helper
{
    public static class Mapping
    {
        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {

            return new CorsoViewModel
            {
                CodiceCorso = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {

            return new Corso
            {
                CorsoCodice = corsoViewModel.CodiceCorso,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
            
            };
        }



        public static DocenteViewModel toDocenteViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                IdDocente = docente.ID,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                EMail = docente.Email,
                Telefono = docente.Telefono
            };
        }

        public static Docente ToDocente(this DocenteViewModel docenteViewModel)
        {
            return new Docente
            {
                ID = docenteViewModel.IdDocente,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.EMail,
                Telefono = docenteViewModel.Telefono
            };
        }

        public static StudenteViewModel toStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                IdStudente = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                DataNascita = studente.DataNascita,
                Email = studente.Email,
                Titolo = studente.TitoloStudio 
            };
        }
        public static Studente ToStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {
                ID = studenteViewModel.IdStudente,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                DataNascita = studenteViewModel.DataNascita,
                Email = studenteViewModel.Email,
                TitoloStudio = studenteViewModel.Titolo
            };
        }

        public static LezioneViewModel toLezioneViewModel(this Lezione lezione)
        {
            return new LezioneViewModel
            {
                IdLezione = lezione.LezioneID,
                Aula = lezione.Aula,
                DataInizio = lezione.DataOraInizio,
                Durata = lezione.Durata
            };
        }
    }
}
    