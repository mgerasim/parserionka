﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIonka.Parser
{
    public static class ParserIonka
    {
        
        public static void Ionka_GroupData_Parse(string strGroupData)
        {

        }

        public static int Ionka_Group05_HH(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[0];
            int HH = Convert.ToInt32(token.Substring(1, 2));
            return HH;
        }

        public static int Ionka_Group05_MM(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[0];
            int MM = Convert.ToInt32(token.Substring(3, 2));
            return MM;
        }

        public static int Ionka_Group06_f0F2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[1];
            int f0F2 = Convert.ToInt32(token.Substring(0, 3));
            return f0F2;
        }

        public static int Ionka_Group06_hF2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[1];
            int hF2 = Convert.ToInt32(token.Substring(3, 2));
            return hF2;
        }

        public static int Ionka_Group07_M3000F2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[2];
            int M3000F2 = Convert.ToInt32(token.Substring(0, 2));
            return M3000F2;
        }

        public static int Ionka_Group07_fmin(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[2];
            int fmin = Convert.ToInt32(token.Substring(3, 2));
            return fmin;
        }

        public static int Ionka_Group08_f0Es(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[3];
            int f0Es = Convert.ToInt32(token.Substring(0, 3));
            return f0Es;
        }

        public static int Ionka_Group08_hEs(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[3];
            int hEs = Convert.ToInt32(token.Substring(3, 2));
            return hEs;
        }

        public static int Ionka_Group09_f0F1(string strSession)
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

        public static int Ionka_Group09_hF1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[4];
            int hF1 = Convert.ToInt32(token.Substring(3, 2));
            return hF1;
        }

        public static int Ionka_Group10_M3000F1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[5];
            token = token.Substring(0, 2);
            if (token == "/7")
            {
                return 999;
            }
            int M3000F1 = Convert.ToInt32(token);
            return M3000F1;
        }

        public static int Ionka_Group10_hMF2(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[5];
            int hMF2 = Convert.ToInt32(token.Substring(3, 2));
            return hMF2;
        }

        public static int Ionka_Group11_f0E(string strSession)
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

        public static int Ionka_Group11_hE(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[6];
            int hE = Convert.ToInt32(token.Substring(3, 2));
            return hE;
        }

        public static int Ionka_Group12_fbEs(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[7];
            token = token.Substring(0, 3);
            if (token == "//1")
            {
                return 999;
            }
            int fbEs = Convert.ToInt32(token);
            return fbEs;
        }



        public static int Ionka_Group12_Es(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[7];
            token = token.Substring(3, 1);
            int Es = Convert.ToInt32(token);
            return Es;
        }
        public static int Ionka_Group13_fx1(string strSession)
        {
            string[] arrayTokens = strSession.Split(' ');
            string token = arrayTokens[8];
            token = token.Substring(0, 3);
            if (token == "//7")
            {
                return 999;
            }
            int fx1 = Convert.ToInt32(token);
            return fx1;
        }
    }
}
