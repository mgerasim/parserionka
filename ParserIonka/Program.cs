using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka
{
    class Program
    {
        static string Prepare(string strPrepare)
        {
            strPrepare = strPrepare.Replace("\"", "");
            return strPrepare;
        }
        static int CheckIonka(string strIonka)
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

        static int Ionka_Group02_Station(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string strStation = arrayString[1];
            int numberStation = Convert.ToInt32(strStation);
            return numberStation;
        }

        static DateTime Ionka_Group03_DateCreate(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[2];
            int month = Convert.ToInt32(token.Substring(1, 2));
            int day = Convert.ToInt32(token.Substring(3, 2));
            int year = DateTime.Now.Year;
            DateTime dateCreate = new DateTime(year, month, day);
            return dateCreate;
        }

        static int Ionka_Group04_Count(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[3];
            int sessionCount = Convert.ToInt32(token.Substring(2, 1));
            return sessionCount;
        }

        static string Ionka_GroupData_Get(int sessionNumber, string strIonka)
        {
            string stringGroupData = strIonka.Substring(24 + 54 * sessionNumber, 53);
            return stringGroupData;
        }
        static void Ionka_GroupData_Parse(string strGroupData)
        {

        }

        static int Ionka_Group05_HH(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[0];
            int HH = Convert.ToInt32(token.Substring(1,2));
            return HH;
        }

        static int Ionka_Group05_MM(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[0];
            int MM = Convert.ToInt32(token.Substring(3, 2));
            return MM;
        }

        static int Ionka_Group06_f0F2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[1];
            int f0F2 = Convert.ToInt32(token.Substring(0, 3));
            return f0F2;
        }

        static int Ionka_Group06_hF2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[1];
            int hF2 = Convert.ToInt32(token.Substring(3, 2));
            return hF2;
        }

        static int Ionka_Group07_M3000F2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[2];
            int M3000F2 = Convert.ToInt32(token.Substring(0, 2));
            return M3000F2;
        }

        static int Ionka_Group07_fmin(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[2];
            int fmin = Convert.ToInt32(token.Substring(3, 2));
            return fmin;
        }

        static int Ionka_Group08_f0Es(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[3];
            int f0Es = Convert.ToInt32(token.Substring(0, 3));
            return f0Es;
        }

        static int Ionka_Group08_hEs(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[3];
            int hEs = Convert.ToInt32(token.Substring(3, 2));
            return hEs;
        }

        static int Ionka_Group09_f0F1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[4];
            token = token.Substring(0, 3);
            if (token == "//7")
            {
                return 999;
            }
            int f0F1 = Convert.ToInt32(token);
            return f0F1;
        }

        static int Ionka_Group09_hF1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[4];
            int hF1 = Convert.ToInt32(token.Substring(3, 2));
            return hF1;
        }

        static int Ionka_Group10_M3000F1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[5];
            token = token.Substring(0, 2);
            if (token == "/7") {
                return 999;
            }
            int M3000F1 = Convert.ToInt32(token);
            return M3000F1;
        }

        static int Ionka_Group10_hMF2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[5];
            int hMF2 = Convert.ToInt32(token.Substring(3, 2));
            return hMF2;
        }

        static int Ionka_Group11_f0E(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[6];
            token = token.Substring(0, 3);
            if (token == "//1")
            {
                return 999;
            }
            int f0E = Convert.ToInt32(token);
            return f0E;
        }

        static int Ionka_Group11_hE(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[6];
            int hE = Convert.ToInt32(token.Substring(3, 2));
            return hE;
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
                int HH = Ionka_Group05_HH(strSession);
                int DD = Ionka_Group05_MM(strSession);                
                int f0F2 = Ionka_Group06_f0F2(strSession);                
                int hF2 = Ionka_Group06_hF2(strSession);
                int M3000F2 = Ionka_Group07_M3000F2(strSession);
                int fmin = Ionka_Group07_fmin(strSession);
                int f0Es = Ionka_Group08_f0Es(strSession);                
                int hEs = Ionka_Group08_hEs(strSession);
                int f0F1 = Ionka_Group09_f0F1(strSession);
                int hF1 = Ionka_Group09_hF1(strSession);
                int M3000F1 = Ionka_Group10_M3000F1(strSession);
                int hMF2 = Ionka_Group10_hMF2(strSession);
                int f0E = Ionka_Group11_f0E(strSession);
                int hE = Ionka_Group11_hE(strSession);

                Console.WriteLine("HH:{0} DD:{1} f0F2:{2} hF2:{3} M3000F2:{4} fmin:{5} f0Es:{6} hEs:{7} f0F1:{8} hF1:{9} M3000F1:{10} hMF2:{11} f0E:{12} hE:{13}", HH, DD, 
                    f0F2, hF2, 
                    M3000F2, fmin, 
                    f0Es, hEs,
                    f0F1, hF1,
                    M3000F1, hMF2,
                    f0E, hE);
            }

                Console.ReadKey();
        }
    }
}
