using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using Codes.Repositories;

namespace Codes.Models
{
    public class Measurement
    {
        public virtual Station Station { get; set; }
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual int DD { get; set; }
        public virtual int MM { get; set; }
        public virtual int YYYY { get; set; }
        public virtual int GG { get; set; }

        public virtual int f0F2{ get; set;  }
        public virtual int hF2{ get; set; }
        public virtual int M3000F2{ get; set; }
        public virtual int fmin{ get; set; }
        public virtual int f0Es{ get; set; }
        public virtual int hEs{ get; set; }
        public virtual int f0F1{ get; set; }
        public virtual int hF1{ get; set; }
        public virtual int M3000F1{ get; set; }
        public virtual int hMF2{ get; set; }
        public virtual int f0E{ get; set; }
        public virtual int hE{ get; set; }
        public virtual int fbEs{ get; set; }
        public virtual int Es{ get; set; }
        public virtual int fx1{ get; set; }

        public Measurement()
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
        }
        public Measurement(string strParser)
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            MM = ParserIonka.Parser.ParserIonka.Ionka_Group05_MM(strParser);
            DD = ParserIonka.Parser.ParserIonka.Ionka_Group05_MM(strParser);
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

        public virtual void ConsoleWrite()
        {
            Console.WriteLine("HH:{0} DD:{1} f0F2:{2} hF2:{3} M3000F2:{4} fmin:{5} f0Es:{6} hEs:{7} f0F1:{8} hF1:{9} M3000F1:{10} hMF2:{11} f0E:{12} hE:{13} fbEs:{14} Es:{15} fx1:{16}", 
                    MM, DD,
                    f0F2, hF2,
                    M3000F2, fmin,
                    f0Es, hEs,
                    f0F1, hF1,
                    M3000F1, hMF2,
                    f0E, hE,
                    fbEs, Es,
                    fx1);
        }

        public virtual void Save()
        {
            IRepository<Measurement> repo = new MeasurementRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Measurement> repo = new MeasurementRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

    }
}
