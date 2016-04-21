using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using EasyUKRaine.Models;

namespace EasyUKRaine.Pages.Helpers
{
    public enum SessionKey
    {
        FTquestion,
        RETURN_URL
    }

    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }
        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else {
                return default(T);
            }
        }
        public static FTquestion GetCart(HttpSessionState session)
        {
            FTquestion myCart = Get<FTquestion>(session, SessionKey.FTquestion);
            if (myCart == null)
            {
                myCart = new FTquestion();
                Set(session, SessionKey.FTquestion, myCart);
            }
            return myCart;
        }

        public static void SessionRemove(HttpSessionState session, SessionKey key)
        {
            session.Remove(Enum.GetName(typeof(SessionKey), key));
        }
    }
}