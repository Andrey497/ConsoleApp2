using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class Place
    {
        private List<string> Parametrs = new List<string>() { "Place_name", "latitude", "longitude", "address_places" };
        private List<string> Words { get; set; }
        public string Answer { get; }
        public Place(List<string> words)
        {
            Words = words;
            Answer = BaseMethod.CheckContext(Words, "place_name", "dbo.place", Parametrs);


        }



    }
}