using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models.Address;

namespace Test.ViewModels.Address
{
    public class AddressEditModel
    {
        public int Id { get; set; }
        public string Suite { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? Details { get; set; }
        [Column(TypeName = "jsonb")] public Location Location { get; set; }
    }

}
