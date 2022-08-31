using static System.Console;



namespace Mietobjekt_Verwaltungssystem
{
    
    class Service
    {
       //Cursorposition
        public static void WriteAt(string s, int x, int y)
        {
            SetCursorPosition(x, y);
            Write(s);
        }

        //Programmstart
        public static void Bootup()
        {
            Title = Settings.apptitle;
            Prozessor switchcases = new Prozessor();
            Company company = new Company();
            
            company.ReadList();

            View.BootScreen();
            switchcases.MainMenu(company);
        }
    }
}
