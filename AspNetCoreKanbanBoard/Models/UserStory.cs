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
        public string Title { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public int Priority { get; set; }
        public UserstoryState CurrentState { get; set; }
        public string UserEmail { get; set; }
    }
}
