using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUKRaine.Models.Repository
{
    public class Repository
    {
        private Repository() { }

        private static Repository _repositoryIstance = null;

        private static readonly object locker = new object();


        public static Repository GetInstance()
        {
            lock (locker)
            {
                if (_repositoryIstance == null)
                {
                    _repositoryIstance = new Repository();
                }
            }
            return _repositoryIstance;
        }

        public SingIn singIn = new SingIn();


        private EasyUKRainianEntities context = new EasyUKRainianEntities();

        private UserAccount _currentUser = new UserAccount();

        public UserAccount CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }


        public IEnumerable<UserAccount> UsersAccounts
        {
            get { return context.UserAccount; }
        }

        public IEnumerable<UserInfo> UsersInfos
        {
            get { return context.UserInfo; }
        }

        private List<string> _categoryList = new List<string>()
        {
<<<<<<< HEAD
            "Grammar", "Vocabulary", "Test", "Games", "About"
=======
            "Grammar", "Vocabulary","Video",  "Test", "Games", "About"
>>>>>>> origin/Andrew
        };

        public List<string> GetCategoryList
        {
            get { return _categoryList;}
        }

        private List<FTquestion> _FTlist = new List<FTquestion>()
        {
            new FTquestion() {ID= 1, quizz = "How would you write \"a very nice friend\"?", answer = "дуже хороший друг", AnswerList = {"зелене дерево", "висотна будівля", "дуже старий чоловік","дуже хороший друг"}},
            new FTquestion() {ID= 2, quizz = "Which one of the following means \"square\":", answer = "квадратний", AnswerList = { "круглий", "квадратний", "трикутний", "солодкий", "глибокий"}},
            new FTquestion() {ID= 3, quizz = "Which one of the following means \"red\":", answer = "червоний", AnswerList = { "червоний", "білий", "синій", "жовтий", "чорний"}},
            new FTquestion() {ID= 4, quizz = "Which one of the following means \"today\":", answer = "сьогодні", AnswerList = { "сьогодні", "негайно", "вчора", "завтра", "вже"}},
            new FTquestion() {ID= 5, quizz = "How would you write \"quickly\"?", answer = "швидко", AnswerList = { "повільно", "швидко", "майже", "разом", "насправді"}},
            new FTquestion() {ID= 6, quizz = "Which one of the following means the number \"six\"?", answer = "шість", AnswerList = { "три", "дев'ять", "сім", "тринадцять", "шість"}},
            new FTquestion() {ID= 7, quizz = "How would you write \"green car\"?", answer = "зелений автомобіль", AnswerList = { "гараж", "мій автомобіль", "три автомобіля", "зелений автомобіль", "ззовні автомобіля"}},
            new FTquestion() {ID= 8, quizz = "What's \"nose\" in Ukrainian?", answer = "ніс", AnswerList = { "плече", "шия", "серце", "ніс", "вухо"}},
            new FTquestion() {ID= 9, quizz = "How would you write \"we speak\"?", answer = "Ми говоримо", AnswerList = { "Вона говорить", "Ви говорите", "Я говорю", "Ми говоримо", "Він говорить"}},
            new FTquestion() {ID= 10, quizz = "How would you write \"his chickens\"?", answer = "його кури", AnswerList = { "вона американка", "його кури", "він щасливий", "ваша донька", "її кури"}},
        };

        public List<FTquestion> GetFTquestions
        {
            get { return _FTlist; }
        } 





        public void SaveUser(UserInfo userInfo, UserAccount userAccount)
        {
            var maxid = context.UserAccount.Max(u => u.UsID) + 1;
            userAccount.UsID = maxid;
            maxid = context.UserInfo.Max(x => x.InfoID) + 1;
            userInfo.InfoID = maxid;
            userInfo.UsID = userAccount.UsID;

<<<<<<< HEAD
            var queryUserAccount = String.Format("Insert into UserAccount (UsId,UserName,UserPassword,Donut,Level,Score) " +
                                      "Values({0}, '{1}', '{2}', '{3}', {4}, {5})",userAccount.UsID,userAccount.UserName,
                                      userAccount.UserPassword,userAccount.Donut,userAccount.Level,userAccount.Score);
=======
            var queryUserAccount = String.Format("Insert into UserAccount (UsId,UserName,UserPassword,Donut,Level,Score,Check_FirstTest) " +
                                      "Values({0}, '{1}', '{2}', '{3}', {4}, {5}, '{6}')", userAccount.UsID,userAccount.UserName,
                                      userAccount.UserPassword,userAccount.Donut,userAccount.Level,userAccount.Score,userAccount.Check_FirstTest);
>>>>>>> origin/Andrew

            var queryUserInfo = String.Format("Insert into UserInfo (InfoId, UsId, Name, Surname, Country, Location, E_mail)" +
                                              "Values({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}')",
                                              userInfo.InfoID,userInfo.UsID,userInfo.Name,userInfo.Surname,
                                              userInfo.Country,
                                              userInfo.Location, userInfo.E_mail);

            ExecuteQuery(queryUserAccount);
            ExecuteQuery(queryUserInfo);
        }
<<<<<<< HEAD

        public void UpdateUserAccount(UserAccount user)
        {
            try
            {
                var queryUserScore = String.Format("Update UserAccount Set Score = {0}  where UsID = {1}" +
                                                   "  update UserAccount Set Level = Score where UsID = {1}", user.Score, user.UsID);
=======
>>>>>>> origin/Andrew

        public void UpdateUserAccount(UserAccount user)
        {
            try
            {
                var queryUserScore = String.Format("Update UserAccount Set Check_FirstTest='{2}', Score = {0}  where UsID = {1}" +
                                                   "  update UserAccount Set Level = {3} where UsID = {1}", user.Score, user.UsID,1,user.Level);

                ExecuteQuery(queryUserScore);
<<<<<<< HEAD

               // context.SaveChanges();
                //  ExecuteQuery(queryUserLevel);
=======
>>>>>>> origin/Andrew
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ExecuteQuery(string query)
        {
            using (var Context = new EasyUKRainianEntities())
            {
                Context.Database.ExecuteSqlCommand(query);
            }
        }

        public List<int> HelpWithFT_list { get; set; } = new List<int>();

    }
}