using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using Codes.Repositories;
using System.Web;

namespace Codes.Models
{
    public class Station
    {
        public Station()
        {
            this._Measurements = new System.Collections.Generic.HashSet<Measurement>();
        }

        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string Name { get; set; }
        public virtual int Code { get; set; }

        public Station(string strIonka)
        {
            this._Measurements = new System.Collections.Generic.HashSet<Measurement>();
            strIonka = this.Prepare(strIonka);
            this.CheckIonka(strIonka);
            Code = this.Ionka_Group02_Station(strIonka);
            DateTime Created_At = this.Ionka_Group03_DateCreate(strIonka);
            int sessionCount = Ionka_Group04_Count(strIonka);
            
            for (int i = 0; i < sessionCount; i++)
            {
                string strSession = Ionka_GroupData_Get(i, strIonka);
                Measurement theIonka = new Measurement(strSession);
                theIonka.DD = Created_At.Day;
                theIonka.MM = Created_At.Month;
                theIonka.YYYY = Created_At.Year;
                theIonka.Station = this;
                this._Measurements.Add(theIonka);
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("Станция: {0}", this.Code);
            foreach (var item in this._Measurements)
            {
                item.ConsoleWrite();
            }
        }

        public virtual string Prepare(string strPrepare)
        {
            strPrepare = strPrepare.Replace("\"", "");
            return strPrepare;
        }
        public virtual int CheckIonka(string strIonka)
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

        public virtual int Ionka_Group02_Station(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string strStation = arrayString[1];
            int numberStation = Convert.ToInt32(strStation);
            return numberStation;
        }

        public virtual DateTime Ionka_Group03_DateCreate(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[2];
            int month = Convert.ToInt32(token.Substring(1, 2));
            int day = Convert.ToInt32(token.Substring(3, 2));
            int year = DateTime.Now.Year;
            DateTime dateCreate = new DateTime(year, month, day);
            return dateCreate;
        }

        public virtual int Ionka_Group04_Count(string strIonka)
        {
            string[] arrayString = strIonka.Split(' ');
            string token = arrayString[3];
            int sessionCount = Convert.ToInt32(token.Substring(2, 1));
            return sessionCount;
        }

        public virtual string Ionka_GroupData_Get(int sessionNumber, string strIonka)
        {
            string stringGroupData = strIonka.Substring(24 + 54 * sessionNumber, 53);
            return stringGroupData;
        }

        public virtual void Save()
        {
            IRepository<Station> repo = new StationRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Station> repo = new StationRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        private ICollection<Measurement> _Measurements;
        public virtual ICollection<Measurement> Measurements
        {
            get
            {
                return this._Measurements;
            }
            set
            {
                this._Measurements = value;
            }
        }
    }
}
