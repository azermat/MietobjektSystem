using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;



namespace Mietobjekt_Verwaltungssystem
{
    [XmlRoot("Customer")]
    public class Customer
    {
        /// <summary>
        /// 
        /// Klasse Customer (enthält XML Attribute und Methoden)
        /// 
        /// </summary>

        [XmlAttribute("ID", DataType = "int")]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }


        [XmlElement("Name", DataType = "string")]
        public string Name { get; set; }

        [XmlElement("TotalincomeFirst", DataType = "double")]
        public double TotalincomeFirst { get; set; }

        [XmlElement("TotalincomeCurrent", DataType = "double")]
        public double TotalincomeCurrent { get; set; }

        [XmlElement("TotalincomeSince", DataType = "double")]
        public double TotalincomeSince { get; set; }

        [XmlElement("ManagementcostsCurrent", DataType = "double")]
        public double ManagementcostsCurrent { get; set; }

        [XmlElement("ManagementcostsSince", DataType = "double")]
        public double ManagementcostsSince { get; set; }


        public List<RentalObject> RentalObjects = new List<RentalObject>();


        public Customer()
        {

        }

        /// <summary>
        /// Methode wird verwendet um einen Neuen Kunden hinzuzufügen
        /// </summary>
        public Customer InsertCustomerValue()
        {
            Customer newCustomer = new Customer();
            View.EmptyScreen();

            CursorVisible = true;

            Service.WriteAt(Settings.Name, 7, 7);
            newCustomer.Name = ReadLine();


            Service.WriteAt(Settings.InputID, 7, 9);
            newCustomer.Id = Convert.ToInt32(ReadLine());


            Service.WriteAt(Settings.TotalIncomeFirst, 7, 11);
            newCustomer.TotalincomeFirst = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.TotalIncomeCurrent, 7, 13);
            newCustomer.TotalincomeCurrent = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.TotalIncomeSince, 7, 15);
            newCustomer.TotalincomeSince = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.ManagementCostsCurrent, 7, 17);
            newCustomer.ManagementcostsCurrent = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.ManagementCostsSince, 7, 19);
            newCustomer.ManagementcostsSince = Convert.ToDouble(ReadLine());

            newCustomer.CreationDate = DateTime.Now;

            CursorVisible = false;
            Clear();

            return newCustomer;
        }

        //Objekt über ID herausziehen
        public RentalObject CheckObjectID()
        {
            while (true)
            {
                CursorVisible = true;
                Service.WriteAt(Settings.inputField, 4, 27);

                int.TryParse(ReadLine(), out int userinput);
                RentalObject findObject = RentalObjects.FirstOrDefault(rentalobject => rentalobject.Id == userinput);

                if (findObject == null)
                {
                    CursorVisible = false;
                    Service.WriteAt(Settings.idNotFound, 4, 27);
                    Thread.Sleep(3000);
                    Clear();
                    View.IDCheckScreen();

                }
                else if (findObject != null)
                {
                    CursorVisible = false;
                    Service.WriteAt(Settings.idFound, 4, 27);
                    Thread.Sleep(3000);
                    Clear();
                    return findObject;
                }
            }
        }


        //Objekt Hinzufügen
        public void AddRentalObject()
        {
            Clear();
            View.EmptyScreen();
            CursorVisible = true;
            RentalObject newobject = null;
            Service.WriteAt("Wählen Sie ein Mietobjekt (Lagerhaus, Wohnung, Wohnhaus, Laden): ", 7, 7);
            string rentaltype = ReadLine();

            switch (rentaltype)
            {
                case "Lagerhaus":
                    newobject = new RentObjectWarehouse();
                    break;

                case "Wohnung":
                    newobject = new RentObjectFlat();
                    break;

                case "Wohnhaus":
                    newobject = new RentObjectResidence();
                    break;

                case "Laden":
                    newobject = new RentObjectShop();
                    break;

                default:
                    Service.WriteAt("Bitte Eingabe Prüfen! ", 72, 7);
                    Thread.Sleep(2000);
                    newobject.InsertObjectValue(newobject);
                    break;
            }
            RentalObjects.Add(newobject.InsertObjectValue(newobject));
        }


        //Mietobjekt entfernen
        public void DeleteObject()
        {
            while (true)
            {
                View.DeleteScreenObject();
                RentalObject rentalObject = CheckObjectID();
                View.DeleteScreenObject();
                ForegroundColor = ConsoleColor.Red;
                Service.WriteAt(string.Format(Settings.askIfSureObject, rentalObject.Id), 22, 15);
                ResetColor();
                Service.WriteAt(Settings.confirmDelete, 4, 27);
                Settings.confirmInput = ReadLine();

                if (Settings.confirmInput == Settings.yesDelete)
                {
                    Clear();
                    View.DeleteScreenObject();

                    RentalObjects.Remove(rentalObject);

                    Service.WriteAt(Settings.objectRemoved, 4, 27);

                    CursorVisible = false; Thread.Sleep(3000);
                    Clear();
                }
                else
                {
                    Clear();
                    View.DeleteScreenObject();
                    CursorVisible = false;

                    Service.WriteAt(Settings.cancelDelete, 4, 27);

                    Thread.Sleep(3000); Clear();
                }
                return;
            }
        }



        //Kundendetails Anzeigen
        public void TextPrinterDetails()
        {
            Service.WriteAt("[Kundendetails]", 52, 3);
            Service.WriteAt($"  ID: {Id} ", 3, 8);
            Service.WriteAt($"  Name: {Name} ", 3, 10);
            Service.WriteAt($"  Gesamtmieteinnahmen im ersten Jahr: ${TotalincomeFirst}", 3, 12);
            Service.WriteAt($"  Gesamtmieteinnahmen aktuelles Jahr: ${TotalincomeCurrent}", 3, 14);
            Service.WriteAt($"  Gesamtmieteinnahmen seit (Jahr): ${TotalincomeSince}", 3, 16);
            Service.WriteAt($"  Verwaltungskosten aktuelles Jahr: ${ManagementcostsCurrent}", 3, 18);
            Service.WriteAt($"  Verwaltungskosten seit (Jahr): ${ManagementcostsSince}", 3, 20);
            Service.WriteAt($"  {Settings.backButton}", 3, 25);
        }

        //Alle Kunden Anzeigen
        public void TextPrinterCustomers(int position)
        {
            Service.WriteAt("[Alle Kunden]", 53, 3 + (position * 30));
            Service.WriteAt($"  ID: {Id} ", 3, 6 + (position * 10));
            Service.WriteAt($"  Name: {Name} ", 3, 7 + (position * 10));
            SetCursorPosition(0, 30 + (position * 30));
        }

        //Alle Mietobjekte Anzeigen
        public void PrintAllObjects(int position)
        {


            
            foreach (RentalObject rentalObject in RentalObjects)
            {
                View.EmptyScreen();
                
                rentalObject.TextPrinterObjects(position++, this);
                
            }
            
            
            
        }

        //Mietobjektdetails Anzeigen
        public void PrintDetailsOfObjects()
        {
            foreach (RentalObject rentalObject in RentalObjects)
            {
                rentalObject.PrintMenu();
            }

            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.NumPad1:
                    foreach (RentalObject rentalObject in RentalObjects)
                    {
                        rentalObject.PrintExtraDetails();
                    }
                    break;

                case ConsoleKey.NumPad2:
                    foreach (RentalObject rentalObject in RentalObjects)
                    {
                        rentalObject.NewEntryDetails();
                    }
                    break;

                case ConsoleKey.NumPad3:
                    var rentObjectSafetyInspections = new RentObjectSafetyInspections();

                    foreach (IndustrialRentals rentalObject in RentalObjects)
                    {
                        rentObjectSafetyInspections.RentSafetyInspection(rentalObject);
                    }
                    break;
            }
            SetCursorPosition(0, 0);
            ReadKey();
            Clear();
        }

        public void PrintLastCustomers(int position)
        {
            Service.WriteAt(Name, 35, 6 + (position * 1));
        }

        public void HighestLowestRent()
        {

            RentalObject rentMax = (from i in RentalObjects
                            let maxId = RentalObjects.Max(m => m.Rent)
                            where i.Rent == maxId
                            select i).FirstOrDefault();

            RentalObject rentMin = (from i in RentalObjects
                                    let minId = RentalObjects.Min(m => m.Rent)
                                    where i.Rent == minId
                                    select i).FirstOrDefault();


            Service.WriteAt($"{rentMax.Rentalobjecttype} [{rentMax.Rent}$]", 35, 14);
            Service.WriteAt($"{rentMin.Rentalobjecttype} [{rentMin.Rent}$]", 37, 17);
        }

        public void MostLucrative()
        {
            RentalObject lucrativecurrent = (from i in RentalObjects
                                    let maxIncomecurrent = RentalObjects.Max(m => m.TotalincomeCurrent)
                                    where i.TotalincomeCurrent == maxIncomecurrent
                                    select i).FirstOrDefault();

            RentalObject lucrativesince = (from i in RentalObjects
                                             let maxIncomesince = RentalObjects.Max(m => m.TotalincomeSince)
                                             where i.TotalincomeSince == maxIncomesince
                                             select i).FirstOrDefault();

            Service.WriteAt($"{lucrativecurrent.Rentalobjecttype} [{lucrativecurrent.TotalincomeCurrent}$]", 36, 20);
            Service.WriteAt($"{lucrativesince.Rentalobjecttype} [{lucrativesince.TotalincomeSince}$]", 40, 23);
        }
    }
}
