using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Models
{
    public class UserStory
    {
        private static int counter = 0;
        public UserStory()
        {
            Id = counter++;
            CurrentState = UserstoryState.ToDo;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public int Priority { get; set; }
        public UserstoryState CurrentState { get; set; }
        public string UserEmail { get; set; }
    }
}
