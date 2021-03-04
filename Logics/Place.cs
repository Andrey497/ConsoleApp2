using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class Place
    {

        private readonly List<string> Parametrs = new List<string>() { "Place_name", "latitude", "longitude", "address_places" };
        private readonly List<string> ContextLabel = new List<string>() { "place_name" };

        private List<string> Words { get; set; }
        public string Answer { get; }
        public Place(List<string> words)
        {
            Words = words;

            Answer = BaseMethod.CheckContext(Words, ContextLabel, "dbo.place", Parametrs);



        }



    }
}