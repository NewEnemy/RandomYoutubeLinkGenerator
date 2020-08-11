using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RandomYoutubeLinkGenerator
{
    class BrutalForceString
    {
        string AvaibleChars = "QWERTYUIOPASDFGHJKLZXCVBNMzxcvbnmlkjhgfdsaqwertyuiop1234567890_-";
        string EndingChars = "048AEIMQUYcgkosw";

        Random rand;
        
        public BrutalForceString()
        {
            rand = new Random();

        }
        public string Next() 
        {
            string ID = "";
            for (int i = 0; i < 10; i++)
            {
                ID += AvaibleChars.ToArray().GetValue(rand.Next(AvaibleChars.Length-1));

            }
            //ID += "w";
            ID += EndingChars.ToArray().GetValue(rand.Next(EndingChars.Length - 1));
            return ID;
        }
    }
}
