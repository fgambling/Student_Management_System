using Student.MsSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class Course
    {
        public static bool add(Student.Model.Course course)
        {
            bool result = false;

            string strsql = "insert into t_course (title,professor,major,num,state,detail,adddate) values ('" + course.Title + "','" + course.Professor + "'," + course.Menu.Id + "," + course.Num + "," + course.State + ",'" + course.Detail + "','" + course.Adddate + "')";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static List<Student.Model.Course> List()
        {
            string strsql = "select * from t_course order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        public static List<Student.Model.Course> List(int major)
        {
            string strsql = "select * from t_course where major=" + major + " order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        private static List<Student.Model.Course> DtToList(DataTable dt)
        {
            List<Student.Model.Course> list = new List<Student.Model.Course>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student.Model.Course course = new Student.Model.Course();
                course = Student.DAL.Course.Getcourse(int.Parse(dt.Rows[i]["id"].ToString()));

                list.Add(course);
            }
            return list;
        }

        public static Model.Course Getcourse(int id)
        {
            Model.Course course = new Model.Course();

            string strsql = "select * from t_course where id='" + id + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                course.Id = int.Parse(dataTable.Rows[0]["id"].ToString());
                course.Title = dataTable.Rows[0]["title"].ToString();
                course.Professor = dataTable.Rows[0]["professor"].ToString();
                course.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["major"].ToString()));
                course.Num = int.Parse(dataTable.Rows[0]["num"].ToString());
                //course.Startdate = dataTable.Rows[0]["startdate"].ToString();
                course.Detail = dataTable.Rows[0]["detail"].ToString();
                course.State = int.Parse(dataTable.Rows[0]["state"].ToString());
                course.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return course;

        }

        public static bool update(Student.Model.Course course)
        {
            bool result = false;

            string strsql = "update t_course set title='" + course.Title + "',professor='" + course.Professor + "',major=" + course.Menu.Id + ",num=" + course.Num + ",detail='" + course.Detail + "',state=" + course.State + " where id=" + course.Id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool del(int id)
        {
            bool result = false;

            string strsql = "delete t_course where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
