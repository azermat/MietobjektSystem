using System;
using static System.Console;





namespace Mietobjekt_Verwaltungssystem
{
    class Prozessor
    {
        /// <summary>
        /// Hauptmenü:
        /// 
        ///-Enthält verschiedene Cases welche als Eingabe über das NumPad abgerufen werden können
        ///
        ///-Jedes Case bietet die Möglichkeit eine der 8 Optionen des Verwaltungssystems zu benutzen
        ///
        /// </summary>
        /// <param name="customers">Liste mit Objekten welche beim Programmstart eingelesen werden.</param>
        public void MainMenu(Company company)
        {
            Clear();

            while (true)
            {
                View.MainScreen();
                company.CustomerCounts();
                company.RentObjectsCounts();
                ConsoleKeyInfo keyInfo = ReadKey(true); 
                ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                    //Neuen Kunden hinzufügen
                    case ConsoleKey.NumPad1:

                        company.AddNewCustomer();
                        
                        break;
                        

                    //Alle Kunden in der Console anzeigen
                    case ConsoleKey.NumPad2:

                        company.PrintAllCustomers();

                        break;


                    //Alle Kundendetails in der Console anzeigen
                    case ConsoleKey.NumPad3:

                        company.PrintDetailsOfCustomers();
                        break;


                    //Vorhandene Kunden via ID entfernen
                    case ConsoleKey.NumPad4:

                        company.DeleteCustomer();

                        break;

                    //Neues Mietobjekt hinzufügen
                    case ConsoleKey.NumPad5:

                        company.AddNewObject();

                        break;

                    //Alle Mietobjekte in der Console anzeigen
                    case ConsoleKey.NumPad6:

                        company.PrintAllRentalObjects();

                        break;

                    //Alle Mietobjektdetails in der Console anzeigen
                    case ConsoleKey.NumPad7:

                        company.PrintDetailsofRentalObjects();

                        break;

                    //Vorhandene Mietobjekte via ID entfernen
                    case ConsoleKey.NumPad8:

                        company.DeleteRentalObject();

                        break;

                    //Statistiken
                    case ConsoleKey.NumPad9:

                        company.Statistics();

                        break;

                    case ConsoleKey.I:

                        company.Statistics();

                        break;

                    //Vorgenommene Änderungen in einer neuen XML Datei speichern, Programm Beenden
                    case ConsoleKey.NumPad0:

                        company.TextWriter();
                        Environment.Exit(0);

                        break;
                }
            }
        }      
    }
}
