using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarsRover.Web.Attributes;
using MarsRover.Web.Models.Shared;

namespace MarsRover.Web.Models.MarsRover
{
    public class MarsRoverSquadModel
    {
        [Display(Name = "Plateau")]
        [Required]
        public PlateauModel Plateau { get; set; }

        [Display(Name = "Rovers")]
        //[Required]
        [EnsureMinimumElements(1, ErrorMessage = "At least one Rover is required.")]
        public List<MarsRoverModel> Rovers { get; set; }
    }
}
