namespace TinyCrm.Core.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal VatNumber { get; set; }
        public int Age { get; set; }
    }
}
