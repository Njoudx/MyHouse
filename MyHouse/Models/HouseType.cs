using System.ComponentModel.DataAnnotations;

namespace MyHouse.Models
{
    public class HouseType
    {
        public int Id { get; set; }
        [Display(Name = "House Type")]
        public string Name { get; set; }
    }
}