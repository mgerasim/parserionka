using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka.Model
{
    class Ionka
    {
        public int HH;
        public int DD;
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
        public Ionka(string strParser)
        {
            HH = ParserIonka.Parser.ParserIonka.Ionka_Group05_HH(strParser);
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

        public void ConsoleWrite()
        {
            Console.WriteLine("HH:{0} DD:{1} f0F2:{2} hF2:{3} M3000F2:{4} fmin:{5} f0Es:{6} hEs:{7} f0F1:{8} hF1:{9} M3000F1:{10} hMF2:{11} f0E:{12} hE:{13} fbEs:{14} Es:{15} fx1:{16}", HH, DD,
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
