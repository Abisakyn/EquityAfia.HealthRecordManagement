namespace EquityAfia.SharedContracts
{
    public class UserExistsResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public bool Exists { get; set; }
    }
}
