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
        private List<string> Parametrs = new List<string>() { "Context" };
        public string Answer { get; }
        public Message(string stringOfMessage)
        {

            var clearString = Regex.Replace(stringOfMessage, "[-.?!)(,:]", " ");
            Words = (clearString.Split(' ')).ToList();
            Words.RemoveAll(x => (x.Trim().Length == 0));
            var key_words = BaseMethod.CheckContext(Words, "word", "dbo.key_words", Parametrs);
            if (key_words == "")
            {
                Answer = "Вы ввели неправильный запрос, я  всеголишь бот.";
            }
            else
            {

                switch (key_words)
                {
                    case "Place":
                        var answerPlace = new Place();
                        Answer = answerPlace.Answer;
                        break;
                }
            }

        }





    }
}
