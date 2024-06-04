using System.Collections.Generic;

namespace DomainModel.Models
{
  public  class ProjectArea
    {
        public int ProjectAreaId { get; set; }
        public string AreaName { get; set; }
        public string PersianTitle { get; set; }
        public ICollection<ProjectController> ProjectControllers { get; set; }

        public ProjectArea()
        {
            this.ProjectControllers = new List<ProjectController>();
        }
    }
}
