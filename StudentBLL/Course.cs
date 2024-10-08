using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL
{
    public class Course
    {

        public static bool add(Student.Model.Course course)
        {
            return Student.DAL.Course.add(course);
        }

        public static List<Student.Model.Course> List()
        {
            return Student.DAL.Course.List();
        }

        public static List<Student.Model.Course> List(int major)
        {
            return Student.DAL.Course.List(major);
        }

        public static Model.Course Getcourse(int id)
        {
            return Student.DAL.Course.Getcourse(id);
        }

        public static bool update(Student.Model.Course course)
        {
            return Student.DAL.Course.update(course);
        }

        public static bool del(int id)
        {
            return Student.DAL.Course.del(id);
        }


    }
}
