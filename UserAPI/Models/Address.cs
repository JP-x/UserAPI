namespace UserAPI.Models
{
    public class UserAddress
    {
        public string Street {  get; set; } = string.Empty;
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Suite { get; set; }
    }
}
