using System.ComponentModel.DataAnnotations;
using MarsRover.Web.Models.Shared;

namespace MarsRover.Web.Models.MarsRover
{
    public class MarsRoverModel
    {
        public MarsRoverModel()
        {
            this.Commands = string.Empty;
            this.InputLocation = new LocationModel();
            this.OutputLocation = new LocationOutputModel();
        }

        [Display(Name = "Commands")]
        [Required]
        public string Commands { get; set; }

        [Display(Name = "Start Location")]
        [Required]
        public LocationModel InputLocation { get; set; }

        [Display(Name = "Final Location")]
        public LocationOutputModel OutputLocation { get; set; }
    }
}
