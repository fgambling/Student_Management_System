using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    public class User
    {

        private int id;
        private string username;
        private string password;
        private string name;
        private Student.Model.Menu menu;
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
