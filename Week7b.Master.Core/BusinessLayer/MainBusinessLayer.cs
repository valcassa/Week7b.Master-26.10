﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7b.Master.Core.BusinessLayer;
using Week7b.Master.Core.Entities;
using Week7b.Master.Core.InterfaceRepositories;

namespace Week7b.Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;

        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryDocenti docenti, IRepositoryLezioni lezioni, IRepositoryStudenti studenti)
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
        }



        #region Funzionalità Corsi
        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {

            Corso corsoEsistente = corsiRepo.GetByCode(newCorso.CorsoCodice);
            if (corsoEsistente != null)
            {
                return "Errore: Codice corso già presente";
            }
            corsiRepo.Add(newCorso);
            return "Corso aggiunto correttamente";
        }

    

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {

            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }

        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }


            var lezioneAssociataAlCorso = GetAllLezioni().FirstOrDefault(l => l.CorsoCodice == corsoEsistente.CorsoCodice);
            if (lezioneAssociataAlCorso != null)
            {
                return "Impossibile cancellare il corso perchè risulta associato ad almeno una lezione";
            }

            var studenteAssociataAlCorso = GetAllStudenti().FirstOrDefault(s => s.CorsoCodice == corsoEsistente.CorsoCodice);
            if (studenteAssociataAlCorso != null)
            {
                return "Impossibile cancellare il corso perchè risulta associato ad almeno uno studente";
            }
            corsiRepo.Delete(corsoEsistente);
            return "Corso eliminato correttamente";

        }

        #endregion


        #region funzionalità Studenti
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {

            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            studentiRepo.Add(nuovoStudente);
            return "studente inserito correttamente";
        }
 
    public string ModificaStudente(int iD, string email)
    {


        var studente = studentiRepo.GetById(iD);
            if (studente == null)
            {
                return "Id Studente errato o inesistente";
            }
            studentiRepo.Update(studente);
            return "Email Studente aggiornata correttamente";
        }
        public string EliminaStudente(int idStudenteDaEliminare)
        {


            var studente = studentiRepo.GetById(idStudenteDaEliminare);
            if (studente == null)
            {
                return "Id Studente errato o inesistente";
            }
            studentiRepo.Delete(studente);
            return "Studente eliminato correttamente";
        }

        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso)
        {
            var corso = corsiRepo.GetByCode(codiceCorso);
            if (corso == null)
            {
                return null;
            }
            return studentiRepo.GetAll().Where(s => s.CorsoCodice == corso.CorsoCodice).ToList();
        }
        #endregion


        #region funzionalità Docenti
        public IList<Docente> GetAllDocenti()
        {
            return docentiRepo.GetAll().ToList();
        }
        public string InserisciNuovoDocente(Docente nuovoDocente)
        {
          
            var docenteEsistente = GetAllDocenti().FirstOrDefault(d => d.Nome == nuovoDocente.Nome && d.Cognome == nuovoDocente.Cognome && d.Email == nuovoDocente.Email);

            if (docenteEsistente != null)
            {
                return "Docente già esistente";
            }
            docentiRepo.Add(nuovoDocente);
            return "Docente Aggiunto con successo";
        }
        public string ModificaDocente(int iD, string email, string telefono){
        
            var docenteDaModificare = docentiRepo.GetAll().FirstOrDefault(d => d.ID == iD);
            if (docenteDaModificare == null)
            {
                return "Id non valido/ non presente";
            }
            docenteDaModificare.Telefono = telefono;
            docenteDaModificare.Email = email;
            docentiRepo.Update(docenteDaModificare);
            return "Modifica effettuata";
        }

        public string EliminaDocente(int idDocenteDaEliminare)
        {
         
            var docenteEsistente = docentiRepo.GetById(idDocenteDaEliminare);
            if (docenteEsistente == null)
            {
                return "Id non valido.Impossibile eliminare.";
            }
            var docenteAssociatoALezione = GetAllLezioni().FirstOrDefault(l => l.DocenteID == idDocenteDaEliminare);
            if (docenteAssociatoALezione != null)
            {
                return "Impossibile cancellare il docente perchè risulta associato ad almeno una lezione";
            }
            docentiRepo.Delete(docenteEsistente);
            return "Docente eliminato con successo";
        }
        #endregion


        #region Funzionalità Lezioni
        public IList<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll().ToList();
        }

        public string AggiungiLezione(Lezione lezione)
        {
           
            var corso = corsiRepo.GetByCode(lezione.CorsoCodice);
            if (corso == null)
            {
                return "Codice Corso errato o inesistente";
            }

          
            var docente = docentiRepo.GetById(lezione.DocenteID);
            if (docente == null)
            {
                return "Codice docente inesistente";
            }
          

            lezioniRepo.Add(lezione);
            return "Aggiunta correttamente";
        }

        public string ModificaLezione(int id, string nuovaAula)
        {
         
            var lezioneDaModificare = lezioniRepo.GetAll().FirstOrDefault(l => l.LezioneID == id);
            if (lezioneDaModificare == null)
            {
                return "Id non valido/ non presente";
            }
          
            lezioneDaModificare.Aula = nuovaAula;
        
            lezioniRepo.Update(lezioneDaModificare);
            return "Modifica effettuata";
        }

        public string EliminaLezione(int idLezioneDaEliminare)
        {
          
            var lezioneEsistente = lezioniRepo.GetById(idLezioneDaEliminare);
            if (lezioneEsistente == null)
            {
                return "Id non valido.Impossibile eliminare.";
            }
            lezioniRepo.Delete(lezioneEsistente);
            return "Lezione eliminata con successo";
        }

        public IList<Lezione> GetLezioniByCodiceCorso(string codiceCorso)
        {
         
            if (string.IsNullOrEmpty(codiceCorso) == true)
            {
                return null;
            }
            var lezioni = new List<Lezione>();
            lezioni = lezioniRepo.GetAll().Where(l => l.CorsoCodice == codiceCorso).ToList();
            return lezioni;
        }

        public IList<Lezione> GetLezioniByNomeCorso(string nomeCorso)
        {
            var corso = corsiRepo.GetAll().FirstOrDefault(c => c.Nome == nomeCorso);

            if (corso == null)
            {
                return null;
            }

            var lezioni = new List<Lezione>();
            lezioni = lezioniRepo.GetAll().Where(l => l.CorsoCodice == corso.CorsoCodice).ToList();
            return lezioni;
        }


          #endregion
    }
}
