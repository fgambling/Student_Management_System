using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    /// <summary>
    /// Course entity class representing a course in the Student Management System.
    /// This class contains course information including title, professor, capacity,
    /// and administrative details.
    /// </summary>
    public class Course
    {
        // Private fields for course data
        private int id;                    // Unique identifier for the course
        private string title;              // Course title/name
        private string professor;          // Professor teaching the course
        private Student.Model.Menu menu;   // Course category/department
        private int num;                   // Maximum number of students allowed
        //private string startdate;        // Course start date (commented out)
        private string detail;             // Course description/details
        private int state;                 // Course status (active/inactive)
        private DateTime adddate;          // Date when the course was created

        /// <summary>
        /// Gets or sets the unique identifier for the course
        /// </summary>
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

        /// <summary>
        /// Gets or sets the course title/name
        /// </summary>
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

        /// <summary>
        /// Gets or sets the professor teaching the course
        /// </summary>
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

        /// <summary>
        /// Gets or sets the course category/department
        /// This determines which department the course belongs to
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum number of students allowed in the course
        /// </summary>
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

        // Course start date property (currently commented out)
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

        /// <summary>
        /// Gets or sets the course description and details
        /// </summary>
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

        /// <summary>
        /// Gets or sets the course status
        /// 0 = Inactive, 1 = Active
        /// </summary>
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

        /// <summary>
        /// Gets or sets the date when the course was created
        /// </summary>
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
