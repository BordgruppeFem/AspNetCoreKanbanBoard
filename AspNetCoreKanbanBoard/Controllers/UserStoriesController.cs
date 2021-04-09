using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreKanbanBoard.Data;
using AspNetCoreKanbanBoard.Models;
using Microsoft.AspNetCore.Identity;
using AspNetCoreKanbanBoard.Services;

namespace AspNetCoreKanbanBoard.Controllers
{
    public class UserStoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFakeUserStoriesRepository _fakeUserStoriesRepository;

        public UserStoriesController(ApplicationDbContext context, IFakeUserStoriesRepository fakeUserStoriesRepository)
        {
            _context = context;
            _fakeUserStoriesRepository = fakeUserStoriesRepository;

        }

        // GET: UserStories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserStories.Include(u => u.User)
                .Where(i => i.UserEmail == User.Identity.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title,Description,Estimation,Priority,CurrentState,UserEmail")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                userStory.UserEmail = User.Identity.Name;
                _context.Add(userStory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userStory.UserId);
            return View(userStory);
        }

        // GET: UserStories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStory = await _context.UserStories.FindAsync(id);
            if (userStory == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userStory.UserId);
            return View(userStory);
        }

        // POST: UserStories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title,Description,Estimation,Priority,CurrentState,UserEmail")] UserStory userStory)
        {
            if (id != userStory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userStory.UserEmail = User.Identity.Name;
                    _context.Update(userStory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStoryExists(userStory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userStory.UserId);
            return View(userStory);
        }

        // POST: UserStories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id);
            _context.UserStories.Remove(userStory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserStoryExists(int id)
        {
            return _context.UserStories.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> MoveUserStoryForward(int id)
        {
            UserStory story = _context.UserStories.FirstOrDefault(i => i.Id == id);
            _fakeUserStoriesRepository.MoveUserStoryForward(story);
            _context.Update(story);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MoveUserStoryBackward(int id)
        {
            UserStory story = _context.UserStories.FirstOrDefault(i => i.Id == id);
            _fakeUserStoriesRepository.MoveUserStoryBackward(story);
            _context.Update(story);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
