﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO.Author
{
    public class UpdateAuthorDto
    {
        [Required]
        public int author_id { get; set; }
        [Required]
        public string? first_name { get; set; }
        [Required]
        public string? last_name { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public string? nationality { get; set; }
    }
}
