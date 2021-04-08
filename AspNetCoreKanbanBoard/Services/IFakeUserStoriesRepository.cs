using AspNetCoreKanbanBoard.Models;
using System.Collections.Generic;

namespace AspNetCoreKanbanBoard.Services
{
    public interface IFakeUserStoriesRepository
    {
        void AddStory(UserStory story);
        List<UserStory> GetAllStories();
        void MoveUserStoryForward(UserStory story);
        void MoveUserStoryBackward(UserStory story);
        UserStory GetUserStoryById(int id);
    }
}