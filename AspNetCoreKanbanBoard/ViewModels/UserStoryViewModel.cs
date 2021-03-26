using AspNetCoreKanbanBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.ViewModels
{
    public class UserStoryViewModel
    {
        public IEnumerable<UserStory> UserStories { get; set; }
    }
}
