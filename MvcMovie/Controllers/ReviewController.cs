using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        MvcMovieContext _context;

        private readonly IMapper _mapper;


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewViewModel>> GetReview(int id)
        {
            try
            {


                var review = _context.Reviews.Include(c => c.MovieId).ToListAsync().Result.FirstOrDefault(c => c.ReviewId == id);
                // var review = await _context.Reviews.Include(r => r.Cake).Where(c => c.CakeId == id).ToListAsync();
                var reviewViewModel = _mapper.Map<ReviewViewModel>(review);


                if (review == null)
                {
                    return NotFound();
                }

                return reviewViewModel;
            }
            catch (Exception)
            {

            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("ReviewId,userName,Comment")] Review movie)
        {
            if (ModelState.IsValid)
            {

               
                _context.Reviews.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult CreateReview()
        {
            return View();
        }
    }
}
