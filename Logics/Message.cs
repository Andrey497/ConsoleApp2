using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logics
{
    public class Message
    {

        private List<string> Words { get; set; }
        private readonly  List<string> Parametrs = new List<string>() { "Context" };
        private  readonly List<string> ContextLabel = new List<string>() { "word" };
        public string[] ParametersReturn = new string[4];
        public string KeyWords { get; }
        public string Answer { get; }
        public Message(string stringOfMessage)
        {

            var clearString = Regex.Replace(stringOfMessage, "[-.?!)(,:]", " ");
            Words = (clearString.Split(' ')).ToList();
            Words.RemoveAll(x => (x.Trim().Length == 0));
            KeyWords = BaseMethod.CheckContext(Words, ContextLabel, "dbo.key_words", Parametrs);
            if (KeyWords == "")
            {
                Answer = "Вы ввели неправильный запрос, я  всеголишь бот.";
            }
            else
            {

                switch (KeyWords)
                {
                    case "Place":
                        var answerPlace = new Place(Words);
                        Answer = answerPlace.Answer;
                        ParametersReturn = Answer.Split(',');
                        break;
                   case "Person":
                        var answerPerson = new Person(Words);
                        Answer = answerPerson.Answer;
                        ParametersReturn = Answer.Split(',');
                        break;
                }
                   
            }

        }





    }
}
