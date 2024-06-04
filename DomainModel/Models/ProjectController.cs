using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ProjectController
    {
        public int ProjectControllerId { get; set; }
        public string ProjectControllerName { get; set; }
        public string PersianTitle { get; set; }
        public ProjectArea ProjectArea { get; set; }
        public ICollection<ProjectAction> ProjectActions { get; set; }

        public ProjectController()
        {
            this.ProjectActions = new List<ProjectAction>();
            this.ProjectArea = new ProjectArea();
        }
    }
}
