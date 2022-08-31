using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;

namespace Mietobjekt_Verwaltungssystem
{
    public class RentObjectShop : IndustrialRentals
    {
        public override string Rentalobjecttype { get { return "Laden"; } }
        public override double Increase { get { return 3; } }

        [XmlIgnore]
        public string firealarmtest;

        public List<string> firealarmtests = new List<string>();

        public void FireAlarmTestings(RentalObject rentalObject)
        {
            DateTime moment = DateTime.Now;
            int year = moment.Year - rentalObject.RentStart.Year;
            DateTime yearcounter = rentalObject.RentStart;

            if (firealarmtests == null)
            {
                do
                {
                    Write($"Jahr {yearcounter:yyyy}: ");
                    firealarmtest = ReadLine();
                    yearcounter = yearcounter.AddYears(1);

                    year--;
                    firealarmtests.Add(firealarmtest);
                }
                while (year != 0);
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                Service.WriteAt("Die Feuerübungs Termine für dieses Mietobjekt sind bereits eingetragen.", 24 , 6);
                ResetColor();
            }
        }

        public void RentFireAlarmTest(RentalObject rentalObject)
        {
            FireAlarmTestings(rentalObject);
        }

        public override void PrintMenu()
        {
            Service.WriteAt("[1] Renovierungen Anzeigen", 89, 24);
            Service.WriteAt("[2] Renovierungen Eintragen", 89, 25);
            Service.WriteAt("[0] Zurück", 54, 27);
        }

        public override void PrintExtraDetails()
        {
            Clear();
            firealarmtests.ForEach(firealarmtest => WriteLine(firealarmtest));
        }

        public override void NewEntryDetails()
        {
            RentFireAlarmTest(this);
        }
    }
}
