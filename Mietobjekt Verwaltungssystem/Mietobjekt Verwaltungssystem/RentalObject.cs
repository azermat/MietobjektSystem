using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;

namespace Mietobjekt_Verwaltungssystem
{
    [XmlInclude(typeof(RentObjectResidence))]
    [XmlInclude(typeof(RentObjectFlat))]
    [XmlInclude(typeof(RentObjectShop))]
    [XmlInclude(typeof(RentObjectWarehouse))]
    
    public abstract class RentalObject
    {
        public abstract double Increase { get; }

        [XmlAttribute("RentalObjectType", DataType = "string")]
        public abstract string Rentalobjecttype { get; }

        [XmlElement("ObjectID", DataType = "int")]
        public int Id { get; set; }

        public DateTime RentStart { get; set; }

        public DateTime CreationDate { get; set; }

        [XmlElement("Rent", DataType = "double")]
        public double Rent { get; set; }

        [XmlElement("ObjectTotalincomeFirst", DataType = "double")]
        public double TotalincomeFirst { get; set; }

        [XmlElement("ObjectTotalincomeCurrent", DataType = "double")]
        public double TotalincomeCurrent { get; set; }

        [XmlElement("ObjectTotalincomeSince", DataType = "double")]
        public double TotalincomeSince { get; set; }

        [XmlElement("ObjectManagementcostsFirst", DataType = "double")]
        public double ManagementcostsFirst { get; set; }

        [XmlElement("ObjectManagementcostsCurrent", DataType = "double")]
        public double ManagementcostsCurrent { get; set; }

        [XmlElement("ObjectManagementcostsSince", DataType = "double")]
        public double ManagementcostsSince { get; set; }


        //Neues Mietobjekt hinzufügen
        /// <summary>
        /// Neues Mietobjekt wird erstellt und in Liste hinzugefügt 
        /// </summary>
        /// <returns></returns>
        public RentalObject InsertObjectValue(RentalObject newobject)
        {

            Service.WriteAt(Settings.InputID, 7, 9);
            newobject.Id = Convert.ToInt32(ReadLine());

           
            Service.WriteAt("Datum: ", 7, 11);
            newobject.RentStart = Convert.ToDateTime(ReadLine());

           
            Service.WriteAt("Miete: ", 7, 13);
            newobject.Rent = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.TotalIncomeFirst, 7, 15);
            newobject.TotalincomeFirst = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.TotalIncomeCurrent, 7, 17);
            newobject.TotalincomeCurrent = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.TotalIncomeSince, 7, 19);
            newobject.TotalincomeSince = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.ManagementCostsCurrent, 7, 21);
            newobject.ManagementcostsCurrent = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.ManagementCostsFirst, 7, 23);
            newobject.ManagementcostsFirst = Convert.ToDouble(ReadLine());


            Service.WriteAt(Settings.ManagementCostsSince, 7, 25);
            newobject.ManagementcostsSince = Convert.ToDouble(ReadLine());

            newobject.CreationDate = DateTime.Now;

            CursorVisible = false;

            Clear();

            return newobject;
        }

        //Mietobjektdetails Anzeigen
        public void TextPrinterObjectDetails(Customer customer)
        {
            Service.WriteAt("[Mietobjekte]", 53, 3);
            Service.WriteAt($"  [{Rentalobjecttype}] ", 3, 8);
            Service.WriteAt($"  Objekt ID: {Id} ", 3, 10);
            Service.WriteAt($"  Eigentümer: {customer.Name} ", 3, 12);
            Service.WriteAt($"  Miete: {Rent} ", 3, 14);
            Service.WriteAt($"  Gesamtmieteinnahmen im ersten Jahr: ${TotalincomeFirst}", 3, 16);
            Service.WriteAt($"  Gesamtmieteinnahmen aktuelles Jahr: ${TotalincomeCurrent}", 3, 18);
            Service.WriteAt($"  Gesamtmieteinnahmen seit ({RentStart:MM/yyyy}): ${TotalincomeSince}", 3, 20);
            Service.WriteAt($"  Verwaltungskosten aktuelles Jahr: ${ManagementcostsCurrent}", 3, 22);
            Service.WriteAt($"  Verwaltungskosten seit ({RentStart:MM/yyyy}): ${ManagementcostsSince}", 3, 24);
        }


        //Alle Mietobjekte Anzeigen
        public void TextPrinterObjects(int position, Customer customer)
        {
            
            Service.WriteAt("[Alle Objekte]", 53, 3 + (position * 30));
            Service.WriteAt($"  Objekttyp  [{Rentalobjecttype}] ", 3, 6 + (position * 15));
            Service.WriteAt($"  Eigentümer: {customer.Name} ", 3, 8 + (position * 15));
            Service.WriteAt($"  Objekt ID: {Id} ", 3, 10 + (position * 15));
            
            
            SetCursorPosition(0, 30 + (position * 30));
    
        }


        public void CalculateRent(RentalObject rentalObject)
        {
            CalculationIncome(rentalObject);
        }


        private void CalculationIncome(RentalObject rentalObject)
        {
            DateTime moment = DateTime.Now;
            int year = moment.Year - rentalObject.RentStart.Year;
            do
            {
                rentalObject.TotalincomeCurrent = (rentalObject.TotalincomeCurrent * rentalObject.Increase / 100) + rentalObject.TotalincomeCurrent;

                rentalObject.TotalincomeCurrent = Math.Round(rentalObject.TotalincomeCurrent);

                year--;
            }
            while (year != 0);
        }


        //Berechnet die Verwaltungsgebühren des Mietobjekts
        public void CalculateEnhancement(RentalObject rentalObject)
        {
            if (rentalObject.Rent <= 10000)
            {
                rentalObject.ManagementcostsCurrent = (rentalObject.ManagementcostsCurrent * 10 / 100) + rentalObject.ManagementcostsCurrent;
                rentalObject.ManagementcostsCurrent = Math.Round(rentalObject.ManagementcostsCurrent);
            }
            else if (rentalObject.Rent <= 20000)
            {
                rentalObject.ManagementcostsCurrent = (rentalObject.ManagementcostsCurrent * 7.5 / 100) + rentalObject.ManagementcostsCurrent;
                rentalObject.ManagementcostsCurrent = Math.Round(rentalObject.ManagementcostsCurrent);
            }
            else if (rentalObject.Rent <= 27000)
            {
                rentalObject.ManagementcostsCurrent = (rentalObject.ManagementcostsCurrent * 5.5 / 100) + rentalObject.ManagementcostsCurrent;
                rentalObject.ManagementcostsCurrent = Math.Round(rentalObject.ManagementcostsCurrent);
            }
            else if (rentalObject.Rent >= 27000)
            {
                rentalObject.ManagementcostsCurrent = (rentalObject.ManagementcostsCurrent * 5 / 100) + rentalObject.ManagementcostsCurrent;
                rentalObject.ManagementcostsCurrent = Math.Round(rentalObject.ManagementcostsCurrent);
            }
        }

        public abstract void PrintMenu();

        public abstract void PrintExtraDetails();

        public abstract void NewEntryDetails();


        public void PrintLastObjects(int position, Customer customer)
        {
            Service.WriteAt($"{Rentalobjecttype} [{customer.Name}]", 35, 7 + (position * 1));
        }


    }

}
 