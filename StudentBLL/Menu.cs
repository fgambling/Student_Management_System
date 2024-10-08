using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL
{
    public class Menu
    {

        public static bool add(Student.Model.Menu menu)
        {
            return Student.DAL.Menu.add(menu);
        }

        public static List<Student.Model.Menu> List()
        {
            return Student.DAL.Menu.List();
        }

        public static bool del(int id)
        {
            return Student.DAL.Menu.del(id);
        }

        public static bool update(Student.Model.Menu menu)
        {
            return Student.DAL.Menu.update(menu);
        }

        public static Student.Model.Menu GetMenu(int id)
        {
            return Student.DAL.Menu.GetMenu(id);
        }
    }
}
