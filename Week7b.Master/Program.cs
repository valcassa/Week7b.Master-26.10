using System;
using Week7b.Master.Core.BusinessLayer;
using Week7b.Master.Core.Entities;
using Week7b.Master.RepositoryEF.RepositoryEF;

namespace Week7b.Master
{
    class Program
    {
         private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiEF(), new RepositoryDocentiEF(), new RepositoryLezioniEF(), new RepositoryStudentiEF());
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
             Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso"); 
            Console.WriteLine("4. Elimina Corso");
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");

            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");

            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;

        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaInfoDocente(); 
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaElencoLezioni();
                    break;
                case 10:
                    InserisciNuovaLezione();
                    break;
                case 11:
                    ModificaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;
                case 13:
                    VisualizzaLezioniByCodiceCorso();
                    break;
                case 14:
                    VisualizzaLezioniByNomeCorso();
                    break;
                case 15:
                    VisualizzaElencoCompletoStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente(); 
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiIscrittiAdUnCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }


        #region Funzionalità Docenti
        private static void InserisciNuovoDocente()
        {

            Console.WriteLine("Inserisci il nome del nuovo Docente");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del nuovo Docente");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'email del nuovo Docente");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di telefono del nuovo Docente");
            string telefono = Console.ReadLine();


            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nome;
            nuovoDocente.Cognome = cognome;
            nuovoDocente.Email = email;
            nuovoDocente.Telefono = telefono;


            string esito = bl.InserisciNuovoDocente(nuovoDocente);

            Console.WriteLine(esito);
        }

        private static void EliminaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti disponibili:");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci l'id");
            int idDocenteDaEliminare = int.Parse(Console.ReadLine());
            string esito = bl.EliminaDocente(idDocenteDaEliminare);
            Console.WriteLine(esito);
        }

        private static void ModificaInfoDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti disponibili:");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi modificare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine()); 


            Console.WriteLine("Inserisci la nuova mail:");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo telefono:");
            string telefono = Console.ReadLine();
            string esito = bl.ModificaDocente(id, email, telefono);
             
            Console.WriteLine(esito);
        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            Console.WriteLine("I docenti disponibili sono:");
            if (docenti.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                foreach (var item in docenti)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion


        #region Funzionalità Lezioni
        private static void InserisciNuovaLezione()
        {


            Console.WriteLine("Inserisci i dati della lezione:");
            Console.Write("Data e ora di inizio (formato gg-mm-aaaa hh:mm): ");
            DateTime dataOraInizio = DateTime.Parse(Console.ReadLine()); 
            Console.Write("\nDurata (in gg): ");
            int durataGG = int.Parse(Console.ReadLine());
            Console.Write("\nAula: ");
            string aula = Console.ReadLine();
            Console.Write("\nCodice Corso a cui si vuole Associare: ");
            VisualizzaCorsi();
            string codiceCorso = Console.ReadLine();
            Console.WriteLine("Elenco docenti disponibili:");
            VisualizzaDocenti();
            Console.Write("\nId Docente che terrà la lezione: ");
            int docenteId = int.Parse(Console.ReadLine());


            Lezione nuovaLezione = new Lezione();
            nuovaLezione.DataOraInizio = dataOraInizio;
            nuovaLezione.Durata = durataGG;
            nuovaLezione.Aula = aula;
            nuovaLezione.CorsoCodice = codiceCorso;
            nuovaLezione.DocenteID = docenteId;


            string esito = bl.AggiungiLezione(nuovaLezione);

            Console.WriteLine(esito);
        }

        private static void EliminaLezione()
        {

            Console.WriteLine("Elenco completo delle lezioni disponibili:");
            VisualizzaElencoLezioni();
            Console.WriteLine("Quale lezione vuoi eliminare? Inserisci l'id");
            int idLezioneDaEliminare = int.Parse(Console.ReadLine());
            string esito = bl.EliminaLezione(idLezioneDaEliminare);
            Console.WriteLine(esito);
        }

        private static void ModificaLezione()
        {

            VisualizzaElencoLezioni();
            Console.WriteLine("Per quale lezione vuoi modificare l'aula? Inserisci l'id della lezione");
            int idLezioneDaModificare = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova Aula:");
            string nuovaAula = Console.ReadLine();
            string esito = bl.ModificaLezione(idLezioneDaModificare, nuovaAula);
            Console.WriteLine(esito);
        }

        private static void VisualizzaElencoLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna Lezione presente");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaLezioniByCodiceCorso()
        {
            Console.WriteLine("Inserisci il codice del corso:");
            string corsoCode = Console.ReadLine();

            var lezioni = bl.GetLezioniByCodiceCorso(corsoCode);
            if (lezioni == null)
            {
                Console.WriteLine("Codice corso errato.");
            }
            else if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota.");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaLezioniByNomeCorso()
        {
            Console.WriteLine("Inserisci il nome del corso:");
            string nomeCorso = Console.ReadLine();

            var lezioni = bl.GetLezioniByNomeCorso(nomeCorso);

            if (lezioni == null)
            {
                Console.WriteLine("Errore. Non esiste nessun corso con questo nome");
            }
            else if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion


        #region Funzionalità Studenti
        private static void VisualizzaStudentiIscrittiAdUnCorso()
        {
            

            Console.WriteLine("Ecco l'elenco dei corsi:");
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso ");
            string codiceCorso = Console.ReadLine();

            var listaStudentiIscrittiAlCorso = bl.GetStudentiByCorsoCodice(codiceCorso);
            if (listaStudentiIscrittiAlCorso == null)
            {
                Console.WriteLine("Codice Corso errato!");
            }
            if (listaStudentiIscrittiAlCorso.Count == 0)
            {
                Console.WriteLine("Nessuno studente iscritto a questo corso!");
            }
            else
            {
                foreach (var item in listaStudentiIscrittiAlCorso)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static void EliminaStudente()
        {
            VisualizzaElencoCompletoStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? Inserisci l'id della lezione");
            int idStudenteDaEliminare = int.Parse(Console.ReadLine());
            string esito = bl.EliminaStudente(idStudenteDaEliminare);
            Console.WriteLine(esito);
        }

        private static void ModificaStudente()
        {
            VisualizzaElencoCompletoStudenti();
            Console.WriteLine("Per quale studente vuoi modificare l'email? Inserisci l'id della lezione");
            int iD = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova email:");
            string email = Console.ReadLine();
            string esito = bl.ModificaStudente(iD, email);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoStudente()
        {

            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci dat di nascita (formato gg-mm-aaaa)");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo studio");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();


            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.TitoloStudio = titoloStudio;
            nuovoStudente.CorsoCodice = codiceCorso;


            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);



        }

        private static void VisualizzaElencoCompletoStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Nessuno Studente presente");
            }
            else
            {
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion


        #region Funzionalità Corsi
        private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili:");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);

        }

        private static void ModificaCorso()
        {
            Console.WriteLine("Ecco l'elenco de i corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo nome del corso");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserisci la nua descrizione del corso");
            string nuovaDescrizione = Console.ReadLine();

            var esito = bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoCorso()
        {

            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();


            Corso nuovoCorso = new Corso();
            nuovoCorso.Nome = nome;
            nuovoCorso.CorsoCodice = codice;
            nuovoCorso.Descrizione = descrizione;


            string esito = bl.InserisciNuovoCorso(nuovoCorso);

            Console.WriteLine(esito);
        }

        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if (corsi.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono corsi!");
            }
            else
            {
                Console.WriteLine("I Corsi disponibili sono:");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        #endregion
    }
}
