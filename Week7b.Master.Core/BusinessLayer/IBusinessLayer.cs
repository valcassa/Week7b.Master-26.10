using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7b.Master.Core.Entities;

namespace Week7b.Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
 
        #region Funzionalità Corsi
         public List<Corso> GetAllCorsi();

         public string InserisciNuovoCorso(Corso newCorso);

         public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
         public string EliminaCorso(string codiceCorsoDaEliminare);

        #endregion

        #region Funzionalità Studenti
         public List<Studente> GetAllStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string ModificaStudente(int iD, string email);
        public string EliminaStudente(int idStudenteDaEliminare);
        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso);

        #endregion

        #region Funzionalità Docenti
         public IList<Docente> GetAllDocenti();

         public string InserisciNuovoDocente(Docente nuovoDocente);

         public string ModificaDocente(int iD, string email, string telefono);

        public string EliminaDocente(int idDocenteDaEliminare);
         #endregion

        #region Funzionalità Lezioni
        public IList<Lezione> GetAllLezioni();


        public string AggiungiLezione(Lezione lezione);


        public string ModificaLezione(int id, string nuovaAula);


        string EliminaLezione(int idLezioneDaEliminare);


        public IList<Lezione> GetLezioniByCodiceCorso(string codiceCorso);


        public IList<Lezione> GetLezioniByNomeCorso(string nomeCorso);
        
        #endregion

    }
}
