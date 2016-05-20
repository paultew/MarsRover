using System.ComponentModel.DataAnnotations;

namespace MarsRover.Web.Models.Shared
{
    public class LocationModel
    {
        [Display(Name = "Direction")]
        [Required]
        public Orientation Orientation { get; set; }

        [Display(Name = "X Axis")]
        [Required]
        public int? X { get; set; }

        [Display(Name = "Y Axis")]
        [Required]
        public int? Y { get; set; }

        #region Overrides of Object

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.X, this.Y, this.Orientation.ToString("G"));
        }

        #endregion
    }
}
