using System.Web;

namespace Student
{
    /// <summary>
    /// Session 
    /// 1、GetSession(string name) get session object by session name
    /// 2、SetSession(string name, object val) setsession
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// get session object by session name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }
        /// <summary>
        /// set session
        /// </summary>
        /// <param name="name">session name</param>
        /// <param name="val">session value</param>
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }
    }
}
