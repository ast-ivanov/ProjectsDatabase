using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASILab6
{
    public class Group
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public int Year { get; set; }
        public virtual List<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
