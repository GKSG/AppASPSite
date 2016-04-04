using System.Web.UI.WebControls;

namespace WebApplication1.Taskes.Single
{
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