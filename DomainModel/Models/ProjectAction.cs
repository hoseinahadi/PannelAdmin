using System.Collections.Generic;

namespace DomainModel.Models
{
   public class ProjectAction
    {
        public int ProjectActionId { get; set; }
        public string ProjectActionName { get; set; }
        public string PersianTitle { get; set; }
        public ProjectController ProjectController { get; set; }
        public ICollection<RoleAction> RoleActions { get; set; }

        public ProjectAction()
        {
            this.RoleActions = new List<RoleAction>();
            this.ProjectController = new ProjectController();
        }
    }
}
