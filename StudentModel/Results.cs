using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    /// <summary>
    /// Results entity class representing student course results/grades in the Student Management System.
    /// This class contains information about a student's performance in a specific course,
    /// linking students to courses with their respective grades.
    /// </summary>
    public class Results
    {
        // Private fields for results data
        private int id;                    // Unique identifier for the result record
        private Student.Model.User student; // Student who achieved this result
        private Student.Model.Course course; // Course for which this result applies
        private int num;                   // Grade/score achieved by the student
        private Student.Model.Menu menu;   // Category/department of the result
        private DateTime adddate;          // Date when the result was recorded

        /// <summary>
        /// Gets or sets the unique identifier for the result record
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
        /// Gets or sets the student who achieved this result
        /// </summary>
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

        /// <summary>
        /// Gets or sets the course for which this result applies
        /// </summary>
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

        /// <summary>
        /// Gets or sets the grade/score achieved by the student
        /// This represents the numerical grade or score in the course
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

        /// <summary>
        /// Gets or sets the category/department of the result
        /// This helps organize results by academic department or category
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
        /// Gets or sets the date when the result was recorded
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
