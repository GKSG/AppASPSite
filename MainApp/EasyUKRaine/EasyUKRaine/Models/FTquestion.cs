using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUKRaine.Models
{
    public class FTquestion
    {
        public int ID { get; set; }
        public string quizz { get; set; }
        public List<string> AnswerList { get; set; }  = new List<string>();
        public string answer { get; set; }
    }
}