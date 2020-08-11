using System;
using System.Collections.Generic;
using System.Text;

namespace RandomYoutubeLinkGenerator
{
    class ByRandomNambers
    {
        ulong Number = 012345678901234567890L;
        Random rand = new Random();
        public ByRandomNambers()
        {

        }
        public string Next()
        {
            string Number_String = "";
            for (int i = 0; i < 19; i++)
            {
                Number_String += rand.Next().ToString()[0];
            }
            Number =ulong.Parse(Number_String);

            string Id = Convert.ToBase64String(BitConverter.GetBytes(Number));
            Id = Id.Replace('/', '-');
            Id = Id.Replace('+', '_');
            Id = Id.Remove(11);
            return Id;

        }
    }
}
