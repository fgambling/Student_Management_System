using Student.Model;
using Student.MsSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class Result
    {
        public static bool add(Student.Model.Results results)
        {
            bool res = false;

            string strsql = "insert into t_results (student,course,num,menu,adddate) values (" + results.Student.Id + "," + results.Course.Id + "," + results.Num + "," + results.Menu.Id + ",'" + results.Adddate + "')";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                res = true;
            }

            return res;
        }

        public static List<Student.Model.Results> List()
        {
            string strsql = "select * from t_results order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        public static List<Student.Model.Results> List(int userId, int courseId)
        {
            string strsql = "select * from t_results where student=" + userId + " and course=" + courseId + " order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        public static List<Student.Model.Results> List(string str)
        {
            string strsql = "select * from t_results where " + str + " order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        public static List<Student.Model.Results> List(int userId)
        {
            string strsql = "select * from t_results where student=" + userId + " order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        private static List<Student.Model.Results> DtToList(DataTable dt)
        {
            List<Student.Model.Results> list = new List<Student.Model.Results>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student.Model.Results results = new Student.Model.Results();
                results = Student.DAL.Result.Getresult(int.Parse(dt.Rows[i]["id"].ToString()));

                list.Add(results);
            }
            return list;
        }

        public static Model.Results Getresult(int id)
        {
            Model.Results results = new Model.Results();

            string strsql = "select * from t_results where id='" + id + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                results.Id = int.Parse(dataTable.Rows[0]["id"].ToString());
                results.Student = Student.DAL.User.Getuser(int.Parse(dataTable.Rows[0]["student"].ToString()));
                results.Course = Student.DAL.Course.Getcourse(int.Parse(dataTable.Rows[0]["course"].ToString()));
                results.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["menu"].ToString()));
                results.Num = int.Parse(dataTable.Rows[0]["num"].ToString());
                results.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return results;

        }

        public static bool update(int num, int id)
        {
            bool res = false;

            string strsql = "update t_results set num=" + num + " where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                res = true;
            }

            return res;
        }

        public static bool del(int id)
        {
            bool res = false;

            string strsql = "delete t_results where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                res = true;
            }

            return res;
        }
    }
}
