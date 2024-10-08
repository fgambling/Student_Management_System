using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    public class Course
    {

        private int id;

        private string title;

        private string professor;

        private Student.Model.Menu menu;

        private int num;

        //private string startdate;

        private string detail;

        private int state;

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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Professor
        {
            get
            {
                return professor;
            }

            set
            {
                professor = value;
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

        //public string Startdate
        //{
        //    get
        //    {
        //        return startdate;
        //    }

        //    set
        //    {
        //        startdate = value;
        //    }
        //}

        public string Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
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
