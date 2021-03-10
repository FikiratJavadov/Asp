using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectasp.DAL;
using FinalProjectasp.Models;
using FinalProjectasp.ViewModels;
using Fiorella.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectasp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class EventController : Controller
    {



        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Events.Where(e => e.IsDeleted == false).ToList());
        }


        public async Task<IActionResult> Create() {
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Speaker = await _context.Speakers.ToListAsync();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventVm e, int eventCategory, int eventSpeaker) // VM => Evenet, Detail, Category, Speaker
        {
            ViewBag.Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Speaker = await _context.Speakers.ToListAsync();

            //if (!e.Photo.IsSelectedType("image/")){
            //    ModelState.AddModelError("Photo", "Not image type");
            //    return View();
            //};


            string path = Path.Combine("img", "event");


            Event newEvent = new Event
            {
                Day = e.Day,
                StartTime = e.StartTime,
                Endtime = e.Endtime,
                Location = e.Location,
                EventName = e.EventName,
                CategoryId = eventCategory,
                IsDeleted = false,
                Image = await e.Photo.SaveImageAsync(_env.WebRootPath, path)

               
            };

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

        }


    }
    } 


