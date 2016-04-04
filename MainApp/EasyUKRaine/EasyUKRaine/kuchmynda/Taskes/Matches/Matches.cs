using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;

namespace WebApplication1.Taskes.Matches
{
    public class MatchesTask : ITask
    {
        public string Header { get; set; }
        public string Sence { get; set; }
        public LevelUA Level { get; set; }
        public int PointsOfTask { get; set; }
        public KeyValuePair<int, int>[] CorrectPair { get; set; } = new KeyValuePair<int, int>[5];
        public KeyValuePair<int, int>[] PairRight { get; set; } = new KeyValuePair<int, int>[5];
        public string[] ContentLeft { get; set; } = new string[5];
        public object ContentRight { get; set; }
    }

    public class MatchesWord : MatchesTask
    {
        public MatchesWord() : base()
        {
            ContentRight = new string[5];
            Header = "Match \"UKR word-ENG translate\"";
            Sence = "It is necessary to practice memory and vocabulary.";
        }

        public MatchesWord(Random task, Random word, Repo repo) : this()
        {
            string current;
            int tagInd, wordInd;
            for (var i = 0; i < ContentLeft.Length; i++)
            {
                Again:
                tagInd = task.Next(repo.topics.Count);
                wordInd = word.Next(repo.topics[tagInd].words.Count);
                current = repo.topics[tagInd].words[wordInd].word;
                if (ContentLeft.Contains(current))
                    goto Again;
                CorrectPair[i] = new KeyValuePair<int, int>(tagInd, wordInd);
                ContentLeft[i] = current.Replace('\"', '\'');
            }

            //права частина
            var forbiddenIndexes = new List<int>();
            var randInd = new Random(Environment.TickCount);
            int index = 0;
            int I;
            while (((string[]) ContentRight).Any(x => x == null))
            {
                I = randInd.Next(5);
                if (!forbiddenIndexes.Contains(I))
                {
                    forbiddenIndexes.Add(I);
                    ((string[]) ContentRight)[index] =
                        repo.topics[CorrectPair[I].Key].words[CorrectPair[I].Value].translates[0].translate;
                    PairRight[index] = CorrectPair[I];
                    index++;
                }
            }
        }
    }

    public class MatchesImage : MatchesTask
    {
        public MatchesImage() : base()
        {
            ContentRight = new Image[5];
            Header = "Match \"UKR word-Picture\"";
            Sence = "It is necessary to practice memory and vocabulary.";
        }

        public MatchesImage(Random task, Random word, Repo repo) : this()
        {
            string current;
            int tagInd, wordInd;
            for (var i = 0; i < ContentLeft.Length; i++)
            {
                Again:
                tagInd = task.Next(repo.topics.Count);
                wordInd = word.Next(repo.topics[tagInd].words.Count);
                current = repo.topics[tagInd].words[wordInd].word;
                if (ContentLeft.Contains(current))
                    goto Again;
                CorrectPair[i] = new KeyValuePair<int, int>(tagInd, wordInd);
                ContentLeft[i] = current.Replace('\"', '\'');
            }

            //права частина
            var forbiddenIndexes = new List<int>();
            var randInd = new Random(Environment.TickCount);
            int index = 0;
            int I;
            while (((Image[]) ContentRight).Any(x => x == null))
            {
                I = randInd.Next(5);
                if (!forbiddenIndexes.Contains(I))
                {
                    forbiddenIndexes.Add(I);
                    ((Image[]) ContentRight)[index] =
                        repo.topics[CorrectPair[I].Key].words[CorrectPair[I].Value].translates[0].image;
                    ((Image[]) ContentRight)[index].Width = 64;
                    ((Image[]) ContentRight)[index].Height = 64;
                    PairRight[index] = CorrectPair[I];
                    index++;
                }
            }
        }
    }

    public class MatchesHard : MatchesTask
    {
        public MatchesHard() : base()
        {
            ContentRight = new string[5];
            Header = "Match \"UKR anagram- translate Eng\"";
            Sence = "It is necessary to practice memory and vocabulary.";
        }
        public MatchesHard(Random task, Random word, Repo repo) : this()
        {
            string current;
            int tagInd, wordInd;
            for (var i = 0 ; i < ContentLeft.Length ; i++)
            {
                Again:
                tagInd = task.Next(repo.topics.Count);
                wordInd = word.Next(repo.topics[tagInd].words.Count);
                current = repo.topics[tagInd].words[wordInd].word;
                if (ContentLeft.Contains(current))
                    goto Again;
                CorrectPair[i] = new KeyValuePair<int, int>(tagInd, wordInd);

                var AnagramWord = new char?[current.Length];
                var forbiddenLiter = new List<int>();
                int iter = 0;
                Random rand = new Random((int)DateTime.Now.Ticks);
                while (!AnagramWord.All(x => x.HasValue))
                {
                    int _index = rand.Next(current.Length);
                    if (!forbiddenLiter.Contains(_index))
                    {
                        AnagramWord[iter] = current[_index];
                        iter++;
                        forbiddenLiter.Add(_index);
                    }
                }

                ContentLeft[i] = (new string(AnagramWord.Select(x=>x.Value).ToArray())).Replace('\"', '\'');
            }     
            //права частина
            var forbiddenIndexes = new List<int>();
            var randInd = new Random(Environment.TickCount);
            int index = 0;
            int I;
            while (((string[]) ContentRight).Any(x => x == null))
            {
                I = randInd.Next(5);
                if (!forbiddenIndexes.Contains(I))
                {
                    forbiddenIndexes.Add(I);
                    ((string[]) ContentRight)[index] =
                        repo.topics[CorrectPair[I].Key].words[CorrectPair[I].Value].translates[0].translate;
                    PairRight[index] = CorrectPair[I];
                    index++;
                }
            }
        }
    }
}