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
        public string[] ParametersReturn = new string[4];
        public string KeyWords { get; }
        public string Answer { get; }
        public Message(string stringOfMessage)
        {

            var clearString = Regex.Replace(stringOfMessage, "[-.?!)(,:]", " ");
            Words = (clearString.Split(' ')).ToList();
            Words.RemoveAll(x => (x.Trim().Length == 0));
            KeyWords = BaseMethod.CheckContext(Words, "word", "dbo.key_words", Parametrs);
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
                }
            }

        }





    }
}
