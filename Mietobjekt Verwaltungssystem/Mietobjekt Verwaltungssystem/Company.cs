using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;


namespace Mietobjekt_Verwaltungssystem
{
    public class Company
    {
        private List<Customer> customers;

        //XML Einlesen
        public void ReadList()
        {
            if (File.Exists(Settings.xmlFile))
            {
                // Generiert Backup
                if (File.Exists(Settings.backupFile))
                {
                    File.Delete(Settings.backupFile);
                    File.Copy(Settings.xmlFile, Settings.backupFile);
                }
                else
                {
                    File.Copy(Settings.xmlFile, Settings.backupFile);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                List<Customer> dezerializedList;

                using (FileStream stream = File.OpenRead(Settings.xmlFile))
                {
                    dezerializedList = (List<Customer>)serializer.Deserialize(stream);
                }
                customers = dezerializedList;

                foreach (Customer customer in customers)
                {
                    foreach (RentalObject rentalObject in customer.RentalObjects)
                    {
                        rentalObject.CalculateRent(rentalObject);
                        rentalObject.CalculateEnhancement(rentalObject);
                    }
                }
            }
            else
            {
                // Keine XML Datei vorhanden, neue Liste wird erstellt
                Write(Settings.xmlNotFound);

                ReadKey();

                customers = new List<Customer>();
                if (customers.Count == 0)
                {
                    AddNewCustomer();
                }
            }
        }


        //XML Schreiben und Speichern
        public void TextWriter()
        {
            if (File.Exists(Settings.xmlFile))
            {
                File.Delete(Settings.xmlFile);
                XmlSerializer writer = new XmlSerializer(typeof(List<Customer>));

                using (FileStream file = File.OpenWrite(Settings.xmlFile))
                {
                    writer.Serialize(file, customers);
                }
            }
            else
            {
                XmlSerializer writer = new XmlSerializer(typeof(List<Customer>));

                using (FileStream file = File.OpenWrite(Settings.xmlFile))
                {
                    writer.Serialize(file, customers);
                }
            }
        }


        //Kunden über ID herausziehen
        public Customer CheckID()
        {
            while (true)
            {
                CursorVisible = true;
                Service.WriteAt(Settings.inputField, 4, 27);

                int.TryParse(ReadLine(), out int userinput);
                Customer findCustomer = customers.FirstOrDefault(customer => customer.Id == userinput);

                if (findCustomer == null)
                {
                    CursorVisible = false;
                    Service.WriteAt(Settings.idNotFound, 4, 27);
                    Thread.Sleep(3000);
                    Clear();
                    View.IDCheckScreen();

                }
                else if (findCustomer != null)
                {
                    CursorVisible = false;
                    Service.WriteAt(Settings.idFound, 4, 27);
                    Thread.Sleep(3000);
                    Clear();
                    return findCustomer;
                }
            }
        }


        //Neuen Kunden hinzufügen
        public void AddNewCustomer()
        {
            Clear();
            Customer newcustomer = new Customer();
            customers.Add(newcustomer.InsertCustomerValue());
        }


        //Kunden entfernen
        public void DeleteCustomer()
        {
            Clear();
            View.DeleteScreenCustomer();

            while (true)
            {
                Customer customer = CheckID();
                View.DeleteScreenCustomer();
                ForegroundColor = ConsoleColor.Red;
                Service.WriteAt(string.Format(Settings.askIfSureCustomer, customer.Id), 22, 15);
                ResetColor();
                Service.WriteAt(Settings.confirmDelete, 4, 27);
                Settings.confirmInput = ReadLine();

                if (Settings.confirmInput == Settings.yesDelete)
                {
                    Clear();
                    View.DeleteScreenCustomer();

                    customers.Remove(customer);
                    Service.WriteAt(Settings.customerRemoved, 4, 27);

                    CursorVisible = false; Thread.Sleep(3000);
                    Clear();
                }
                else
                {
                    Clear();
                    View.DeleteScreenCustomer();
                    CursorVisible = false;

                    Service.WriteAt(Settings.cancelDelete, 4, 27);

                    Thread.Sleep(3000); Clear();
                }
                return;
            }
        }

        //Alle Kunden Anzeigen
        public void PrintAllCustomers()
        {
            Clear();
            int position = 0;
            foreach (Customer customer in customers)
            {
                View.EmptyScreen();
                customer.TextPrinterCustomers(position++);
            }
            SetCursorPosition(0, 0);
            PrintDetailsOfCustomers();
            Clear();
        }


        //Kundendetails Anzeigen
        public void PrintDetailsOfCustomers()
        {
            Customer customer = SearchCustomer();
            View.EmptyScreen();
            customer.TextPrinterDetails();
            ReadKey();
            Clear();
        }


        public void PrintAllRentalObjects()
        {
            Clear();
            int position = 0;
            foreach (Customer customer in customers)
            {
                customer.PrintAllObjects(position++);      
            }
            SetCursorPosition(0, 0);
            ReadKey();
            Clear();
        }


        public void PrintDetailsofRentalObjects()
        {
            Clear();
            View.IDCheckScreen();
            Customer customer = CheckID();

            foreach (RentalObject rentalObject in customer.RentalObjects)
            {
                View.EmptyScreen();

                rentalObject.TextPrinterObjectDetails(customer);
                customer.PrintDetailsOfObjects();
            }
        }


        //Neues Objekt hinzufügen
        public void AddNewObject()
        {
            Clear();
            View.IDCheckScreen();
            Customer customer = CheckID();
            customer.AddRentalObject();
        }


        //Objekt entfernen
        public void DeleteRentalObject()
        {
            Clear();
            View.DeleteScreenFindObject();
            Customer customer = CheckID();
            customer.DeleteObject();
        }

        public void CustomerCounts()
        {
            ForegroundColor = ConsoleColor.Green;
            int count = 0;
            foreach (Customer customer in customers)
            {
                count++;
            }
            Service.WriteAt($"{count}", 10, 25);
            ResetColor();
        }

        public void RentObjectsCounts()
        {
            ForegroundColor = ConsoleColor.Green;
            int counts = 0;
            foreach (Customer customer in customers)
            {
                foreach (RentalObject rentalObject in customer.RentalObjects)
                {
                    counts++;
                }
            }
            Service.WriteAt($"{counts}", 11, 26);
            ResetColor();
        }

        public Customer SearchCustomer()
        {
            while (true)
            {
                CursorVisible = true;
                Service.WriteAt("[Suche]  Abbrechen[0]: ", 47, 26);
                string userinput = ReadLine();

                Customer findCustomer = customers.FirstOrDefault(customer => customer.Name == userinput);

                if (userinput == "0")
                {
                    var mainmenu = new Prozessor();
                    mainmenu.MainMenu(this);
                }
                else if (findCustomer == null)
                {
                    CursorVisible = false;
                    Service.WriteAt("Kunde konnte nicht gefunden werden, bitte erneut versuchen. ", 4, 27);
                    Thread.Sleep(2000);
                    Clear();
                    View.EmptyScreen();
                }
                else if (findCustomer != null)
                {
                    CursorVisible = false;
                    Clear();
                    return findCustomer;
                }
            }
        }

        public void GetStatistics()
        {
            Clear();
            View.StatisticsScreen();
            int position = 0;
            var lastThreeCustomers = customers.Skip(Math.Max(0, customers.Count() - 3)).Take(3);
            foreach (var item in lastThreeCustomers)
            {
                item.PrintLastCustomers(position++);

            }
            foreach (Customer customer in customers)
            {
                var lastThreeObjects = customer.RentalObjects.Skip(Math.Max(0, customer.RentalObjects.Count() - 1)).Take(1);
                
                foreach (var rentalObject in lastThreeObjects)
                {
                    rentalObject.PrintLastObjects(position++, customer);
                }
            }

            foreach (Customer customer in customers)
            {
                customer.HighestLowestRent();
                customer.MostLucrative();
                break;
            }

            Customer lucrativesince = (from i in customers
                                           let maxIncomesince = customers.Max(m => m.TotalincomeSince)
                                           where i.TotalincomeSince == maxIncomesince
                                           select i).FirstOrDefault();

            Service.WriteAt($"{lucrativesince.Name} [{lucrativesince.TotalincomeSince}$]", 35, 26);
            ReadKey();
            Clear();
        }

        public void Statistics()
        {
            Clear();
            GetStatistics();        
        }           
    }
}
