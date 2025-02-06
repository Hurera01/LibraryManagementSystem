using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Loans
    {
        [Key]
        public int loan_id { get; set; }
        [Required]
        [ForeignKey("Book")]
        public int book_id { get; set; }
        [Required]
        [ForeignKey("Member")]
        public int member_id { get; set; }
        //[Required]
        public DateOnly? loan_date { get; set; }
        public DateOnly? due_date { get; set; }
        public DateOnly? return_date { get; set; }
        public Books Books { get; set; }
        public Members Members { get; set; }
    }
}
