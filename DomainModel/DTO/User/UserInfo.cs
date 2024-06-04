namespace DomainModel.DTO.User
{
  public  class UserInfo
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
