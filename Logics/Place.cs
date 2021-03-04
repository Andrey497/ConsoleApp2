using System;
using System.Collections.Generic;
using System.Text;

namespace Logics
{
    public class Place
    {
        private List<string> Parametrs = new List<string>() { "Place_name" };
        private List<string> Words { get; set; }
        public string Answer { get; }
        public Place()
        {
            Answer = BaseMethod.CheckContext(Words, "place", "dbo.key_words", Parametrs);
        }



    }
}
