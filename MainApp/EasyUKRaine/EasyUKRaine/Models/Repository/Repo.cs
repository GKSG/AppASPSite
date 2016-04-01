using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EasyUKRaine.Models;


namespace EasyUKRaine.Models.Repo
{
    public class Repo
    {
        public List<TopicR> topics { get; set; } = new List<TopicR>();

        public Repo()
        {
            var DBData = new EasyUKRainianEntities();
            topics =
                DBData.Topic.Select(
                    c =>
                        new TopicR
                        {
                            header = c.Header.Trim(' ').Replace(" ", " & "),
                            capacity = c.Capacity,
                            image = new ImageButton {ImageUrl = c.Image, Width = 256, Height = 256},
                            words =
                                DBData.Word.Where(w => w.TopicID == c.TopicID)
                                    .Select(
                                        w =>
                                            new WordR
                                            {
                                                word = w.Word1,
                                                translates =
                                                    DBData.Translate.Where(t => t.WID == w.WID)
                                                        .Select(
                                                            t =>
                                                                new TranslateR
                                                                {
                                                                    image = new Image {ImageUrl = t.ImageLink},
                                                                    translate = t.Translate1
                                                                })
                                                        .ToList()
                                            })
                                    .ToList()
                        }).ToList();
        }
    }

    public class TopicR
    {
        public string header { get; set; } = null;
        public int? capacity { get; set; } = null;
        public ImageButton image { get; set; } = null;
        public List<WordR> words { get; set; } = null;
    }

    public class WordR
    {
        public string word { get; set; } = null;
        public List<TranslateR> translates { get; set; } = null;
    }

    public class TranslateR
    {
        public string translate { get; set; } = null;
        public Image image { get; set; } = null;
    }

}