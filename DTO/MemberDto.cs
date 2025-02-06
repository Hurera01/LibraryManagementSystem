using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO
{
    public class MemberDto
    {
        [Required]
        public string first_name {  get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone_number { get; set; }
        [Required]
        public DateOnly membership_date { get; set; }
    }
}
