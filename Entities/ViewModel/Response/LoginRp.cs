namespace Entities.ViewModel
{
    public class LoginRp
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public RoleUser Role { get; set; } = RoleUser.None;
    }
}
