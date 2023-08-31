using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace U3W1D4_Login
{
    internal class Program
    {

        static void MostraMenu()
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l’operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");
            Console.Write("Scelta: ");
        }
        static void Main(string[] args)
        {
            int scelta = 0;

            do
            {
                try
                {
                    MostraMenu();
                    scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            Console.Write("Inserisci username: ");
                            string username = Console.ReadLine();
                            Utente.Login(username);
                            break;
                        case 2:
                            Utente.Logout();
                            break;
                        case 3:
                            Utente.VerificaDataOra();
                            break;
                        case 4:
                            Utente.ElencoAccessi();
                            break;
                        case 5:
                            Console.WriteLine("Uscita dal programma.");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Scelta non valida.");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Si è verificato un errore: " + ex.Message);
                }

            }
            while (scelta != 5);
        }
    }
}
