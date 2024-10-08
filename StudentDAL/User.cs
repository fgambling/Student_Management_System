using Student.MsSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{

    public class User
    {

        public static List<Student.Model.User> List()
        {
            string strsql = "select * from t_user order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        private static List<Student.Model.User> DtToList(DataTable dt)
        {
            List<Student.Model.User> list = new List<Student.Model.User>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student.Model.User user = new Student.Model.User();
                user = Student.DAL.User.Getuser(int.Parse(dt.Rows[i]["id"].ToString()));

                list.Add(user);
            }
            return list;
        }

        public static Model.User Getuser(int id)
        {
            Model.User user = new Model.User();

            string strsql = "select * from t_user where id='" + id + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                user.Id = int.Parse(dataTable.Rows[0]["id"].ToString());
                user.Username = dataTable.Rows[0]["username"].ToString();
                user.Password = dataTable.Rows[0]["password"].ToString();
                user.Name = dataTable.Rows[0]["name"].ToString();
                user.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["menu"].ToString()));
                user.State = int.Parse(dataTable.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return user;

        }

        public static bool Login(string username, string password)
        {
            if (Search(username))
            {
                string strsql = "select * from t_user where username='" + username + "'";
                DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];
                if (dataTable.Rows[0]["password"].ToString().Trim() == password)
                {
                    return true;
                }
                else
                { 
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Search(string username)
        {
            bool result = false;
            string strsql = "select * from t_user where username='" + username + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];
            if (dataTable.Rows.Count != 0)
            {
                result = true;
            }

            return result;
        }

        public static bool add(Student.Model.User user)
        {
            bool result = false;

            string strsql = "insert into t_user (username,password,name,menu,state,adddate) values ('" + user.Username + "','" + user.Password + "','" + user.Name + "'," + user.Menu.Id + "," + user.State + ",'" + user.Adddate + "')";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool update(Student.Model.User user)
        {
            bool result = false;

            string strsql = "update t_user set password='" + user.Password + "',name='" + user.Name + "',state=" + user.State + " where id=" + user.Id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static Model.User Getuser(string username)
        {
            Model.User user = new Model.User();

            string strsql = "select * from t_user where username='" + username + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                user.Id = int.Parse(dataTable.Rows[0]["iD"].ToString());
                user.Username = dataTable.Rows[0]["username"].ToString();
                user.Password = dataTable.Rows[0]["password"].ToString();
                user.Name = dataTable.Rows[0]["name"].ToString();
                user.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["menu"].ToString()));
                user.State = int.Parse(dataTable.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return user;

        }

        public static bool del(int id)
        {
            bool result = false;

            string strsql = "delete t_user where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
