using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_2._2
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public bool IsRunning { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
