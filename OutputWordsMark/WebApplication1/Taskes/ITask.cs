using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebApplication1.Taskes
{
    enum LevelUA
    {
        Beginner,Intermediate,Pro
    }

    internal interface ITask
    {
        string Header { get; set; }
        string Sence { get; set; }
        LevelUA Level { get; set; }
        int PointsOfTask { get; set; }
    }

    class SingleTask : ITask
    {
        public string Header { get; set; }
        public string Sence { get; set; }
        public LevelUA Level { get; set; } = LevelUA.Beginner;
        public int PointsOfTask { get; set; } = 100;
        public string CorrectWord { get; set; }
        public object Content { get; set; }
    }

    class SingleWord : SingleTask
    {                      
        public SingleWord() : base()
        {
            Content = "";
            Header = "Translate word";
            Sence = "It is necessary to practice memory and vocabulary.";
        }
    }
    class SingleImage : SingleTask
    {                                                
        public SingleImage() : base()
        {
            Content = new Image();
            Header = "What`s it?";
            Sence = "It is necessary to practice memory and vocabulary.";
        }
    }
}
