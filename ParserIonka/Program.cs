using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka
{
    class Program
    {
        static void Main(string[] args)
        {
            string strIonka = "\"IONKA 46501 50331 7/3/7 /0000 01025 32/19 04225 04520 38284 //100 0343/ //7// /0100 01024 32319 04217 //722 /7285 //102 0383/ //7// /0200 09824 32319 04010 //720 /7290 //100 0373/ //7// \"";
            Codes.Models.Station theStation = new Codes.Models.Station(strIonka);
            Codes.Common.NHibernateHelper.UpdateSchema();
            theStation.Save();
            theStation.Print();
            Console.ReadKey();
        }
    }
}
