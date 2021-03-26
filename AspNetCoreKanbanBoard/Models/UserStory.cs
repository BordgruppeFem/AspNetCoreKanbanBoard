using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Models
{
    public class UserStory
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public int Priority { get; set; }
        public string UserEmail { get; set; }
    }
}
