using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL
{
    /// <summary>
    /// Business Logic Layer for User entity operations.
    /// This class acts as an intermediary between the presentation layer and data access layer,
    /// providing business logic validation and processing for user-related operations.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Retrieves all users from the system
        /// </summary>
        /// <returns>List of all users in the system</returns>
        public static List<Student.Model.User> List()
        {
            return Student.DAL.User.List();
        }

        /// <summary>
        /// Authenticates a user with the provided credentials
        /// </summary>
        /// <param name="username">User's login username</param>
        /// <param name="password">User's login password</param>
        /// <returns>True if authentication successful, false otherwise</returns>
        public static bool Login(string username, string password)
        {
            return Student.DAL.User.Login(username, password);
        }

        /// <summary>
        /// Adds a new user to the system
        /// </summary>
        /// <param name="user">User object to add</param>
        /// <returns>True if user was added successfully, false otherwise</returns>
        public static bool add(Student.Model.User user)
        {
            return Student.DAL.User.add(user);
        }

        /// <summary>
        /// Updates an existing user's information
        /// </summary>
        /// <param name="user">User object with updated information</param>
        /// <returns>True if user was updated successfully, false otherwise</returns>
        public static bool update(Student.Model.User user)
        {
            return Student.DAL.User.update(user);
        }

        /// <summary>
        /// Checks if a username exists in the system
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>True if username exists, false otherwise</returns>
        public static bool Search(string username)
        {
            return Student.DAL.User.Search(username);
        }

        /// <summary>
        /// Retrieves a user by their username
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>User object if found, otherwise empty user object</returns>
        public static Model.User Getuser(string username)
        {
            return Student.DAL.User.Getuser(username);
        }

        /// <summary>
        /// Retrieves a user by their ID
        /// </summary>
        /// <param name="id">User ID to retrieve</param>
        /// <returns>User object if found, otherwise empty user object</returns>
        public static Model.User Getuser(int id)
        {
            return Student.DAL.User.Getuser(id);
        }

        /// <summary>
        /// Deletes a user from the system by their ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <returns>True if user was deleted successfully, false otherwise</returns>
        public static bool del(int id)
        {
            return Student.DAL.User.del(id);
        }
    }
}
