using AspNetCoreKanbanBoard.Models;
using AspNetCoreKanbanBoard.Services;
using AspNetCoreKanbanBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreKanbanBoard.Controllers
{
    public class UserStoryController : Controller
    {

        private readonly IFakeUserStoriesRepository _fakeUserStoriesRepository;
        public UserStoryController(IFakeUserStoriesRepository fakeUserStoriesRepository)
        {
            _fakeUserStoriesRepository = fakeUserStoriesRepository;
        }

        public IActionResult Index()
        {
            var stories = _fakeUserStoriesRepository.GetAllStories();
            return View(stories);
        }

        [HttpPost]
        public IActionResult CreateUserStory(UserStory story)
        {
            _fakeUserStoriesRepository.AddStory(story);
            var stories = _fakeUserStoriesRepository.GetAllStories();

            return View(nameof(Index), stories);
        }
    }
}
