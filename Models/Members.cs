using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Members
    {
        [Key]
        public int member_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? first_name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? last_name { get; set; }
        [Required]
        [EmailAddress]
        public string? email { get; set; }
        [Required]
        [Phone]
        public string? phone_number { get; set; }
        [Required]
        public DateOnly? membership_date { get; set; }
        public ICollection<Loans> Loans { get; set; }
    }
}
