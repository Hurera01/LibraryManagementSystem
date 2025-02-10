namespace LibraryManagementSystem.DTO.Author
{
    public class GetAuthorDto
    {
        public int author_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime dob { get; set; }
        public string nationality { get; set; }
    }
}
