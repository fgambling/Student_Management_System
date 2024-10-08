using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    public class Results
    {

        private int id;

        private Student.Model.User student;

        private Student.Model.Course course;

        private int num;

        private Student.Model.Menu menu;

        private DateTime adddate;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public User Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
            }
        }

        public Course Course
        {
            get
            {
                return course;
            }

            set
            {
                course = value;
            }
        }

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public Menu Menu
        {
            get
            {
                return menu;
            }

            set
            {
                menu = value;
            }
        }

        public DateTime Adddate
        {
            get
            {
                return adddate;
            }

            set
            {
                adddate = value;
            }
        }
    }
}
