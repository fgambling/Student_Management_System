using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student.Model
{
    /// <summary>
    /// Menu entity class representing a menu/category in the Student Management System.
    /// This class is used for organizing users, courses, and results by categories
    /// such as departments, roles, or academic divisions.
    /// </summary>
    public class Menu
    {
        // Private fields for menu data
        private int id;                    // Unique identifier for the menu
        private string title;              // Title/name of the menu category

        /// <summary>
        /// Gets or sets the unique identifier for the menu
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
        /// Gets or sets the title/name of the menu category
        /// Examples: "Computer Science", "Mathematics", "Administrator", "Student"
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
    }
}
