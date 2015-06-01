using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka
{
    class Program
    {
        public static string Prepare(string strPrepare)
        {
            strPrepare = strPrepare.Replace("\"", "");
            return strPrepare;
        }
        public static int CheckIonka(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            if (arrayString[0] != "ionka" && arrayString[0] != "IONKA")
            {
                // ("Не явлейтсе строкой с кодом Ionka");
                return 1;
            }

            string tokenGroup04 = arrayString[3];
            int numberControl = Convert.ToInt32(tokenGroup04.Substring(0, 1));
            if (numberControl != 7)
            {
                // В коде {0} служебная группа {1} не имеет служебную цифру = 7
                return 2;
            }

            if (tokenGroup04.Substring(1, 1) != "/")
            {
                // В коде {0} служебная группа {1} не соответствует формату Н/М/К
                return 3;
            }


            if (tokenGroup04.Substring(3, 1) != "/")
            {
                // В коде {0} служебная группа {1} не соответствует формату Н/М/К
                return 4;
            }
            return 0;
        }

        public static int Ionka_Group02_Station(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string strStation = arrayString[1];
            int numberStation = Convert.ToInt32(strStation);
            return numberStation;
        }

        public static DateTime Ionka_Group03_DateCreate(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[2];
            int month = Convert.ToInt32(token.Substring(1, 2));
            int day = Convert.ToInt32(token.Substring(3, 2));
            int year = DateTime.Now.Year;
            DateTime dateCreate = new DateTime(year, month, day);
            return dateCreate;
        }

        public static int Ionka_Group04_Count(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[3];
            int sessionCount = Convert.ToInt32(token.Substring(2, 1));
            return sessionCount;
        }

        public static string Ionka_GroupData_Get(int sessionNumber, string strIonka)
        {
            string stringGroupData = strIonka.Substring(24 + 54 * sessionNumber, 53);
            return stringGroupData;
        }

        static void Main(string[] args)
        {
            string strIonka = "\"IONKA 46501 50331 7/3/7 /0000 01025 32/19 04225 04520 38284 //100 0343/ //7// /0100 01024 32319 04217 //722 /7285 //102 0383/ //7// /0200 09824 32319 04010 //720 /7290 //100 0373/ //7// \"";
           
            strIonka = Prepare(strIonka);
            int res = CheckIonka(strIonka);
            if (res != 0)
            {
                Console.WriteLine("Строка {0} не является кодом Ионка. Код ошибки: {1}", strIonka, res);
                Console.ReadKey();
                return ;
            }
            
            Console.WriteLine(strIonka);

            Console.WriteLine("Станция: {0}", Ionka_Group02_Station(strIonka));
            Console.WriteLine("Дата измерения: {0}", Ionka_Group03_DateCreate(strIonka));           

            int sessionCount = Ionka_Group04_Count(strIonka);
            Console.WriteLine("Количество сеансов: {0}", sessionCount);
            
            for (int i = 0; i < sessionCount; i++)
            {
                string strSession = Ionka_GroupData_Get(i, strIonka);
                Console.WriteLine(strSession);
                // Письма к Незнакомке Андреа Мареа
                ParserIonka.Model.Ionka theIonka = new ParserIonka.Model.Ionka(strSession);
                theIonka.ConsoleWrite();
            }

                Console.ReadKey();
        }
    }
}
