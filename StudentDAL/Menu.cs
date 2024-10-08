using Student.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class Menu
    {

        public static bool add(Student.Model.Menu menu)
        {
            bool result = false;

            string strsql = "insert into t_menu (title) values ('"+ menu.Title +"')";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static List<Student.Model.Menu> List()
        {
            string strsql = "select * from t_menu order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        private static List<Student.Model.Menu> DtToList(DataTable dt)
        {
            List<Student.Model.Menu> list = new List<Student.Model.Menu>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student.Model.Menu menu = new Student.Model.Menu();
                menu = Student.DAL.Menu.GetMenu(int.Parse(dt.Rows[i]["id"].ToString()));

                list.Add(menu);
            }
            return list;
        }

        public static Student.Model.Menu GetMenu(int id)
        {
            Student.Model.Menu menu = new Model.Menu();

            string strsql = "select * from t_menu where id=" + id + "";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            if (dt.Rows.Count > 0) 
            {
                menu.Id = int.Parse(dt.Rows[0]["id"].ToString());
                menu.Title = dt.Rows[0]["title"].ToString();
            }

            return menu;
        }

        public static bool del(int id)
        {
            bool result = false;

            string strsql = "delete t_menu where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool update(Student.Model.Menu menu)
        {
            bool result = false;

            string strsql = "update t_menu set title='" + menu.Title + "' where id=" + menu.Id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
