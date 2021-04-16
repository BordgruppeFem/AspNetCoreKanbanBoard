using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Models
{
    public class UserStory
    {
        //private static int counter = 0;
        public UserStory()
        {
        }
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

        
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Input needs to be between 2 and 40 characters.")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Input needs to be between 2 and 255 characters.")]
        public string Description { get; set; }

        [Required]
        public int Estimation { get; set; }

        [Required]
        public int Priority { get; set; }
        public UserstoryState CurrentState { get; set; }
        public string UserEmail { get; set; }
    }
}
