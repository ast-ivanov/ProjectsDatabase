using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASILab6
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string Content { get; set; }
        public short Term { get; set; }
        public virtual Student Student { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}
