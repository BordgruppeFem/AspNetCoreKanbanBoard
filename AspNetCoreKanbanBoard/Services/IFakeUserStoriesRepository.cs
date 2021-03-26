using AspNetCoreKanbanBoard.Models;
using System.Collections.Generic;

namespace AspNetCoreKanbanBoard.Services
{
    public interface IFakeUserStoriesRepository
    {
        void AddStory(UserStory story);
        List<UserStory> GetAllStories();
    }
}