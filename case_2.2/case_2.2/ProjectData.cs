using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace case_2._2
{
    public class ProjectData
    {
        public string Name { get; set; }
        public TimeSpan[] TimerValues { get; set; } = new TimeSpan[5];
        public bool[] TimerStates { get; set; } = new bool[5];
        public string[] TaskNames { get; set; } = new string[5];

        public async Task SaveToDatabase(int projectId, AppDbContext db)
        {
            var project = await db.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project != null)
            {
                var existingTasks = project.Tasks.ToList();
                foreach (var task in existingTasks)
                {
                    if (!TaskNames.Contains(task.Name))
                    {
                        db.Tasks.Remove(task);
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (!string.IsNullOrEmpty(TaskNames[i]))
                    {
                        var existingTask = project.Tasks.FirstOrDefault(t => t.Name == TaskNames[i]);
                        if (existingTask != null)
                        {
                            existingTask.TimeSpent = TimerValues[i];
                            existingTask.IsRunning = TimerStates[i];
                        }
                        else
                        {
                            project.Tasks.Add(new ProjectTask
                            {
                                Name = TaskNames[i],
                                TimeSpent = TimerValues[i],
                                IsRunning = TimerStates[i]
                            });
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

    }
}
