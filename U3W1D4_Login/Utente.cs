using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3W1D4_Login
{
    internal static class Utente
    {
        //Proprietà
        public static string Username { get; set; }
        public static Boolean IsLogged { get; set; }
        public static DateTime LastLogin { get; set; }
        public static List<DateTime> AccessLog = new List<DateTime>();

        //Metodi

        //Nascondi la digitazione della password
        private static string NascondiPassword()
        {
            StringBuilder input = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (!char.IsControl(key.KeyChar))
                {
                    input.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return input.ToString();
        }

        //Metodo per gestire il login
        public static void Login(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                Console.Write("Inserisci password: ");
                string password = NascondiPassword();
                Console.Write("Conferma password: ");
                string confirm_password = NascondiPassword();

                if (password == confirm_password)
                {
                    Username = username;
                    IsLogged = true;
                    LastLogin = DateTime.Now;
                    AccessLog.Add(LastLogin);
                    Console.WriteLine("Login effettuato con successo");
                }
                else
                {
                    Console.WriteLine("Le password non coincidono");
                }
            }

            else
            {
                Console.WriteLine("Lo username non può essere vuoto");
            }
        }

        // Metodo per gestire il logout
        public static void Logout()
        {
            if(IsLogged)
            {
                Username = null;
                IsLogged = false;
                Console.WriteLine("Logout effetuato con successo");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato");
            }
        }

        //Metodo di verifica data e ora
        public static void VerificaDataOra()
        {
            if (IsLogged)
            {
                Console.WriteLine($"Ultimo login effettuato il {LastLogin}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato");
            }
        }

        public static void ElencoAccessi()
        {
            if(AccessLog.Count > 0)
            {
                Console.WriteLine($"Lista degli accessi: {string.Join(", ", AccessLog)}");
            }

            else
            {
                Console.WriteLine("Questo utente non ha ancora fatto accessi");
            }
        }
    }
}
