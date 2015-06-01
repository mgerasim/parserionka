using Codes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka.Model
{
    class Ionka
    {
        public int Station;
        public DateTime Created_At;
        public List<IonkaSession> theList;
        protected string strRaw;
        public Ionka(string strIonka)
        {
            strRaw = strIonka;
            theList = new List<IonkaSession>();
            strIonka = this.Prepare(strIonka);
            this.CheckIonka(strIonka);
            Station = this.Ionka_Group02_Station(strIonka);
            Created_At = this.Ionka_Group03_DateCreate(strIonka);
            int sessionCount = Ionka_Group04_Count(strIonka);
            
            for (int i = 0; i < sessionCount; i++)
            {
                string strSession = Ionka_GroupData_Get(i, strIonka);
                // Письма к Незнакомке Андреа Мареа
                ParserIonka.Model.IonkaSession theIonka = new ParserIonka.Model.IonkaSession(strSession);
                theList.Add(theIonka);
            }
        }
        public void Print()
        {
            Console.WriteLine("Станция: {0}", this.Station);
            Console.WriteLine("Дата измерения: {0}", this.Created_At);
            foreach (var item in this.theList)
            {
                item.ConsoleWrite();
            }
        }

        public string Prepare(string strPrepare)
        {
            strPrepare = strPrepare.Replace("\"", "");
            return strPrepare;
        }
        public int CheckIonka(string strIonka)
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

        public int Ionka_Group02_Station(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string strStation = arrayString[1];
            int numberStation = Convert.ToInt32(strStation);
            return numberStation;
        }

        public DateTime Ionka_Group03_DateCreate(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[2];
            int month = Convert.ToInt32(token.Substring(1, 2));
            int day = Convert.ToInt32(token.Substring(3, 2));
            int year = DateTime.Now.Year;
            DateTime dateCreate = new DateTime(year, month, day);
            return dateCreate;
        }

        public int Ionka_Group04_Count(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[3];
            int sessionCount = Convert.ToInt32(token.Substring(2, 1));
            return sessionCount;
        }

        public string Ionka_GroupData_Get(int sessionNumber, string strIonka)
        {
            string stringGroupData = strIonka.Substring(24 + 54 * sessionNumber, 53);
            return stringGroupData;
        }

        public void Save()
        {
            SqlConnection Connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=DatabaseIonka;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            Connection.Close();
        }
    }
    class IonkaSession
    {
        public virtual Station Station { get; set; }
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual int DD { get; set; }
        public virtual int MM { get; set; }
        public virtual int YYYY { get; set; }
        public virtual int GG { get; set; }

        public int f0F2;
        public int hF2;
        public int M3000F2;
        public int fmin;
        public int f0Es;
        public int hEs;
        public int f0F1;
        public int hF1;
        public int M3000F1;
        public int hMF2;
        public int f0E;
        public int hE;
        public int fbEs;
        public int Es;
        public int fx1;
        public IonkaSession(string strParser)
        {
            MM = ParserIonka.Parser.ParserIonka.Ionka_Group05_MM(strParser);
            DD = ParserIonka.Parser.ParserIonka.Ionka_Group05_DD(strParser);
            f0F2 = ParserIonka.Parser.ParserIonka.Ionka_Group06_f0F2(strParser);
            hF2 = ParserIonka.Parser.ParserIonka.Ionka_Group06_hF2(strParser);
            M3000F2 = ParserIonka.Parser.ParserIonka.Ionka_Group07_M3000F2(strParser);
            fmin = ParserIonka.Parser.ParserIonka.Ionka_Group07_fmin(strParser);
            f0Es = ParserIonka.Parser.ParserIonka.Ionka_Group08_f0Es(strParser);
            hEs = ParserIonka.Parser.ParserIonka.Ionka_Group08_hEs(strParser);
            f0F1 = ParserIonka.Parser.ParserIonka.Ionka_Group09_f0F1(strParser);
            hF1 = ParserIonka.Parser.ParserIonka.Ionka_Group09_hF1(strParser);
            M3000F1 = ParserIonka.Parser.ParserIonka.Ionka_Group10_M3000F1(strParser);
            hMF2 = ParserIonka.Parser.ParserIonka.Ionka_Group10_hMF2(strParser);
            f0E = ParserIonka.Parser.ParserIonka.Ionka_Group11_f0E(strParser);
            hE = ParserIonka.Parser.ParserIonka.Ionka_Group11_hE(strParser);
            fbEs = ParserIonka.Parser.ParserIonka.Ionka_Group12_fbEs(strParser);
            Es = ParserIonka.Parser.ParserIonka.Ionka_Group12_Es(strParser);
            fx1 = ParserIonka.Parser.ParserIonka.Ionka_Group13_fx1(strParser);
        }

        public void ConsoleWrite()
        {
            Console.WriteLine("HH:{0} DD:{1} f0F2:{2} hF2:{3} M3000F2:{4} fmin:{5} f0Es:{6} hEs:{7} f0F1:{8} hF1:{9} M3000F1:{10} hMF2:{11} f0E:{12} hE:{13} fbEs:{14} Es:{15} fx1:{16}", MM, DD,
                    f0F2, hF2,
                    M3000F2, fmin,
                    f0Es, hEs,
                    f0F1, hF1,
                    M3000F1, hMF2,
                    f0E, hE,
                    fbEs, Es,
                    fx1);
        }
    }
}
