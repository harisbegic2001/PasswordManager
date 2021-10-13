using System.ComponentModel.DataAnnotations;

namespace AccountManager.Models.AccountModels
{
    public class UpdateAccountModel
    {
        [Required]
        [MaxLength(250)]
        public string AppName { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string AppUsername { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string AppPassword { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string AppDescription { get; set; }
    }
}