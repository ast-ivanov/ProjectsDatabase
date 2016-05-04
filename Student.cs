using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASILab6
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Group Group { get; set; }
        public virtual List<Project> Projects { get; set; }

        public Student()
        {
            Projects = new List<Project>();
        }
    }
}
