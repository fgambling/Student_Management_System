using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student.Model
{
    public class Menu
    {
        private int id;
        private string title;

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
    }
}
