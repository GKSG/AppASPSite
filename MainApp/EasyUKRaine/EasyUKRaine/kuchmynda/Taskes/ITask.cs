using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebApplication1.Taskes
{
    public enum LevelUA
    {
        Beginner,Intermediate,Pro
    }

    internal interface ITask
    {
        string Header { get; set; }
        string Sence { get; set; }
        object CorrectAnswer { get; set; }
        LevelUA Level { get; set; }
        int PointsOfTask { get; set; }
    }

    

   
}
