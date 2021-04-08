using AspNetCoreKanbanBoard.Models;
using AspNetCoreKanbanBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Services
{
    public class FakeUserStoriesRepository : IFakeUserStoriesRepository
    {
        public static List<UserStory> UserStories { get; set; }
        //public UserStoryViewModel UserStoryViewModel { get; }

        public FakeUserStoriesRepository()
        {
            //UserStoryViewModel = userStoryViewModel;
            //UserStoryViewModel = userStoryViewModel;

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

        public void MoveUserStoryForward(UserStory story)
        {
            switch (story.CurrentState)
            {
                case UserstoryState.ToDo:
                    story.CurrentState = UserstoryState.Doing;
                    break;
                case UserstoryState.Doing:
                    story.CurrentState = UserstoryState.CodeReview;
                    break;
                case UserstoryState.CodeReview:
                    story.CurrentState = UserstoryState.Done;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// NOT DRY ;(
        /// </summary>
        /// <param name="story"></param>
        public void MoveUserStoryBackward(UserStory story)
        {
            switch (story.CurrentState)
            {
                case UserstoryState.Done:
                    story.CurrentState = UserstoryState.CodeReview;
                    break;
                case UserstoryState.CodeReview:
                    story.CurrentState = UserstoryState.Doing;
                    break;
                case UserstoryState.Doing:
                    story.CurrentState = UserstoryState.ToDo;
                    break;
                default:
                    break;
            }
        }

        public UserStory GetUserStoryById(int id)
        {
            return UserStories.Find(i => i.Id == id);
        }

    }
}
