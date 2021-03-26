using AspNetCoreKanbanBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Services
{
    public class FakeUserStoriesRepository : IFakeUserStoriesRepository
    {
        public static List<UserStory> UserStories { get; set; }

        public FakeUserStoriesRepository()
        {
            UserStories = new List<UserStory>();
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
            UserStories.Add(new UserStory
            {
                Title = "Fiske",
                Description = "Hammer er en bisse",
                Estimation = 9000,
                Priority = 20,
                UserEmail = "aaaaaaa"
            });
        }

        public List<UserStory> GetAllStories()
        {
            return UserStories;
        }

        public void AddStory(UserStory story)
        {
            UserStories.Add(story);
        }
    }
}
