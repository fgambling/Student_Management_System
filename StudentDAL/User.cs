using Student.MsSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    /// <summary>
    /// Data Access Layer for User entity operations.
    /// This class handles all database operations related to user management
    /// including CRUD operations, authentication, and user queries.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Retrieves all users from the database ordered by ID in descending order
        /// </summary>
        /// <returns>List of all users in the system</returns>
        public static List<Student.Model.User> List()
        {
            string strsql = "select * from t_user order by id desc";
            DataTable dt = Student.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return DtToList(dt);
        }

        /// <summary>
        /// Converts a DataTable to a List of User objects
        /// </summary>
        /// <param name="dt">DataTable containing user data</param>
        /// <returns>List of User objects</returns>
        private static List<Student.Model.User> DtToList(DataTable dt)
        {
            List<Student.Model.User> list = new List<Student.Model.User>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student.Model.User user = new Student.Model.User();
                user = Student.DAL.User.Getuser(int.Parse(dt.Rows[i]["id"].ToString()));

                list.Add(user);
            }
            return list;
        }

        /// <summary>
        /// Retrieves a specific user by their ID
        /// </summary>
        /// <param name="id">User ID to retrieve</param>
        /// <returns>User object if found, otherwise empty user object</returns>
        public static Model.User Getuser(int id)
        {
            Model.User user = new Model.User();

            string strsql = "select * from t_user where id='" + id + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                user.Id = int.Parse(dataTable.Rows[0]["id"].ToString());
                user.Username = dataTable.Rows[0]["username"].ToString();
                user.Password = dataTable.Rows[0]["password"].ToString();
                user.Name = dataTable.Rows[0]["name"].ToString();
                user.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["menu"].ToString()));
                user.State = int.Parse(dataTable.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return user;

        }

        /// <summary>
        /// Authenticates a user with the provided username and password
        /// </summary>
        /// <param name="username">User's login username</param>
        /// <param name="password">User's login password</param>
        /// <returns>True if authentication successful, false otherwise</returns>
        public static bool Login(string username, string password)
        {
            if (Search(username))
            {
                string strsql = "select * from t_user where username='" + username + "'";
                DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];
                if (dataTable.Rows[0]["password"].ToString().Trim() == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a username exists in the database
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>True if username exists, false otherwise</returns>
        public static bool Search(string username)
        {
            bool result = false;
            string strsql = "select * from t_user where username='" + username + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];
            if (dataTable.Rows.Count != 0)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="user">User object to add</param>
        /// <returns>True if user was added successfully, false otherwise</returns>
        public static bool add(Student.Model.User user)
        {
            bool result = false;

            string strsql = "insert into t_user (username,password,name,menu,state,adddate) values ('" + user.Username + "','" + user.Password + "','" + user.Name + "'," + user.Menu.Id + "," + user.State + ",'" + user.Adddate + "')";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Updates an existing user's information in the database
        /// </summary>
        /// <param name="user">User object with updated information</param>
        /// <returns>True if user was updated successfully, false otherwise</returns>
        public static bool update(Student.Model.User user)
        {
            bool result = false;

            string strsql = "update t_user set password='" + user.Password + "',name='" + user.Name + "',state=" + user.State + " where id=" + user.Id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Retrieves a user by their username
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>User object if found, otherwise empty user object</returns>
        public static Model.User Getuser(string username)
        {
            Model.User user = new Model.User();

            string strsql = "select * from t_user where username='" + username + "'";
            DataTable dataTable = YFMsSqlHelper.Query(strsql).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                user.Id = int.Parse(dataTable.Rows[0]["iD"].ToString());
                user.Username = dataTable.Rows[0]["username"].ToString();
                user.Password = dataTable.Rows[0]["password"].ToString();
                user.Name = dataTable.Rows[0]["name"].ToString();
                user.Menu = Student.DAL.Menu.GetMenu(int.Parse(dataTable.Rows[0]["menu"].ToString()));
                user.State = int.Parse(dataTable.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dataTable.Rows[0]["adddate"].ToString());
            }
            return user;

        }

        /// <summary>
        /// Deletes a user from the database by their ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <returns>True if user was deleted successfully, false otherwise</returns>
        public static bool del(int id)
        {
            bool result = false;

            string strsql = "delete t_user where id=" + id + "";

            int i = Student.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);

            if (i > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
