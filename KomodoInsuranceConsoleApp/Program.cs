using KomodoInsuranceClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // this will end up in the ProgramUI for a way to store new developers by taking in user input via the console
            /*Developer dev1 = new Developer();

            dev1.FirstName = "Danny";
            dev1.LastName = "Redden";
            dev1.DevID = 123;*/

            ProgramUI ui = new ProgramUI();
            ui.RunMenu();
            Console.ReadKey();
        }
    }
}
