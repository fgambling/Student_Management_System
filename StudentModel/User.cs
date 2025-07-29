using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    /// <summary>
    /// User entity class representing a user in the Student Management System.
    /// This class contains user information including authentication details,
    /// personal information, and role-based access control.
    /// </summary>
    public class User
    {
        // Private fields for user data
        private int id;                    // Unique identifier for the user
        private string username;           // User's login username
        private string password;           // User's login password (should be hashed in production)
        private string name;               // User's full name
        private Student.Model.Menu menu;   // User's role/permission menu
        private int state;                 // User account status (active/inactive)
        private DateTime adddate;          // Date when the user account was created

        /// <summary>
        /// Gets or sets the unique identifier for the user
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
        /// Gets or sets the user's login username
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's login password
        /// Note: In production, passwords should be hashed and not stored in plain text
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's full name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's role/permission menu
        /// This determines what features and pages the user can access
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
        /// Gets or sets the user account status
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
        /// Gets or sets the date when the user account was created
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
