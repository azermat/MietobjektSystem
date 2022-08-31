using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;

namespace Mietobjekt_Verwaltungssystem
{

    public class RentObjectSafetyInspections
    {
        [XmlIgnore]
        private string safetyinspectiondate;

        [XmlIgnore]
        private string shortcomings;

        public List<string> safetyinspectiondates = new List<string>();

        public void SafetyInspections(IndustrialRentals rentalObject)
        {
            DateTime moment = DateTime.Now;
            int year = moment.Year - rentalObject.RentStart.Year;
            DateTime yearcounter = rentalObject.RentStart;

            if (safetyinspectiondates == null)
            {
                do
                {
                    Write($"Termin Angabe für Jahr {yearcounter:yyyy}: ");
                    safetyinspectiondate = ReadLine();
                    Write("Festgestellte Mängel: ");
                    shortcomings = ReadLine();

                    yearcounter = yearcounter.AddYears(1);

                    year--;
                    safetyinspectiondates.Add(safetyinspectiondate + "Festgestellte Mängel: " + shortcomings);
                }
                while (year != 0);
            }
            else
            {
                Write("Die Sicherheitseintragungen für dieses Mietobjekt sind bereits eingetragen.");
            }
        }

        public void RentSafetyInspection(IndustrialRentals rentalObject)
        {
            SafetyInspections(rentalObject);
        }
    }
}
