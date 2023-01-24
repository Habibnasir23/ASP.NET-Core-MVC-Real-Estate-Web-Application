using System.ComponentModel;

namespace WebApplication1.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        [DisplayName("Property Available")]
        public string propAvailable { get; set; }

        [DisplayName("Rooms Available")]
        public int roomsAvailable { get; set; }

        [DisplayName("Rent")]
        public int rent { get; set; }
        public RealEstate()
        {

        }
    }
}
