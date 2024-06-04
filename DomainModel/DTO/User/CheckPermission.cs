namespace DomainModel.DTO.User
{
   public class CheckPermission
    {
        public string ActionName { get; set; }
        public string Controller { get; set; }
        public string UserName { get; set; }
    }
}
