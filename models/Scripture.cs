using System.ComponentModel.DataAnnotations;

namespace MyScriptureJourney.models
{
    public class Scripture
    {
        public int Id { get; set; }

        //[StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; } = string.Empty;

        // [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //[StringLength(30)]
        //[DataType(DataType.Currency)]
        public int Chapter { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        //[StringLength(5)]
        public int Verses { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        [Required]
        public string Notes { get; set; } = string.Empty;
    }
}
