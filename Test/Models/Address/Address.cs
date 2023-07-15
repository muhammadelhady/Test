using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models.Address
{
    public class Address : BaseEntity
    {
        public string Suite { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Details { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
    public class Location: BaseEntity
    {
        public double Langitude { get; set; }
        public double Latitude { get; set; }
    }

}
