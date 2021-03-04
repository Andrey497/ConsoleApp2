using System;
using System.Collections.Generic;
using System.Text;

namespace Logics
{
    public  class Person
    {
        private readonly List<string> Parametrs = new List<string>() {  "person_firstname", "person_middlename", "person_secondname", "person_Telephone", "person_email"};
        private readonly List<string> ContextLabel = new List<string>(){"person_secondname", "person_firstname", "person_middlename", "person_post nvarchar" };
        private List<string> Words { get; set; }
        public string Answer { get; }
        public Person(List<string> words)
        {
            Words = words;
            Answer = BaseMethod.CheckContext(Words, ContextLabel, "dbo.place", Parametrs);


        }
    }
}
