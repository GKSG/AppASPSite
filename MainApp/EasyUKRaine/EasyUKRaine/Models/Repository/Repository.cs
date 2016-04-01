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

       // public Repo.Repo  GroupRepo = new Repo.Repo();


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
            "Grammar", "Test", "Games", "About"
        };

        public List<string> GetCategoryList
        {
            get { return _categoryList;}
        }




        public void SaveUser(UserInfo userInfo, UserAccount userAccount)
        {
            var maxid = context.UserAccount.Max(u => u.UsID) + 1;
            userAccount.UsID = maxid;
            maxid = context.UserInfo.Max(x => x.InfoID) + 1;
            userInfo.InfoID = maxid;
            userInfo.UsID = userAccount.UsID;


            var queryUserAccount = String.Format("Insert into UserAccount (UsId,UserName,UserPassword,Donut,Level,Score) " +
                                      "Values({0}, '{1}', '{2}', '{3}', {4}, {5})",userAccount.UsID,userAccount.UserName,
                                      userAccount.UserPassword,userAccount.Donut,userAccount.Level,userAccount.Score);

            var queryUserInfo = String.Format("Insert into UserInfo (InfoId, UsId, Name, Surname, Country, Location, E_mail)" +
                                              "Values({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}')",
                                              userInfo.InfoID,userInfo.UsID,userInfo.Name,userInfo.Surname,
                                              userInfo.Country,
                                              userInfo.Location, userInfo.E_mail);


            ExecuteQuery(queryUserAccount);
            ExecuteQuery(queryUserInfo);



        }

        private void ExecuteQuery(string query)
        {
            using (var Context = new EasyUKRainianEntities())
            {
                Context.Database.ExecuteSqlCommand(query);
            }
        }

    }
}