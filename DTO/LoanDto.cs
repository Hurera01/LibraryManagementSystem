using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO
{
    public class LoanDto
    {
        [Required]
        public int book_id { get; set; }
        [Required]
        public int member_id { get; set; }
        [Required]
        public DateOnly loan_date { get; set; }
        [Required]
        public DateOnly due_date { get; set; }
        public DateOnly return_date { get; set; }
    }
}
