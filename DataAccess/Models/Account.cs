using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.DataAccess.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
