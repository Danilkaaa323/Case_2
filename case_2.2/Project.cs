using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_2._2
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
