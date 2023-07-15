namespace Test.Models.User
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string WebSite { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int AddressId { get; set; }
        public Test.Models.Address.Address Address { get; set; }
    }
    public class Company :BaseEntity
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
