using AspNetCoreKanbanBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.ViewModels
{
    public class UsersViewModel
    {
        public string Email { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
