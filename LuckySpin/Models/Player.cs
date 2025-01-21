using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player //Done: Annotate the Player properties as described in section 3.
    {
        [Required(ErrorMessage = "Please provide your First Name.")]
        [StringLength(100, ErrorMessage = "The First Name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [Range(1,9, ErrorMessage = "Choose a number between 1 and 9")]
        public int Luck { get; set; }
    }
}