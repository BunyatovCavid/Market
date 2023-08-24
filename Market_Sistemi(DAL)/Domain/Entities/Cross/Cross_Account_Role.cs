namespace Market.Domain.Entities.Cross
{
    public class Cross_Account_Role
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
