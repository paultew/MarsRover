using System.ComponentModel.DataAnnotations;

namespace MarsRover.Web.Models.Shared
{
    public class LocationOutputModel
    {
        [Display(Name = "Direction")]
        public Orientation Orientation { get; set; }

        [Display(Name = "X Axis")]
        public int? X { get; set; }

        [Display(Name = "Y Axis")]
        public int? Y { get; set; }
    }
}
