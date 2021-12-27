using System.ComponentModel.DataAnnotations;

namespace myProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}