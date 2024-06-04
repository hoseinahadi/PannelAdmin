namespace DomainModel.Models
{
   public class RoleAction
    {
        public int RoleActionId { get; set; }
        public int RoleId { get; set; }
        public int ProjectActionId { get; set; }
        public ProjectAction ProjectAction { get; set; }
        public Role Role { get; set; }
        public bool HasPermission { get; set; }

        public RoleAction()
        {
            this.Role = new Role();
            this.ProjectAction = new ProjectAction();
        }
    }
}
