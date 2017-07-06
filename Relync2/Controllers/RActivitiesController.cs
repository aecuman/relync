using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Relync2.Data;
using Relync2.Models;

namespace Relync2.Controllers
{
    public class RActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public RActivitiesController(ApplicationDbContext context,ApplicationDbContext context2)
        {
            _context = context;
           
        }

        // GET: RActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activity.ToListAsync());
        }

        // GET: RActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: RActivities/Create
       /* public IActionResult Create()
        {
            List<Property> ppty = new List<Property>();
            ppty = (from p in _context.Property select p).ToList();
            ViewBag.ListOfProperties = ppty;
            List<Request> req = new List<Models.Request>();
            req = (from r in _context.Request select r).ToList();
            ViewBag.ListOfRequests = req;
            return View();
        }*/

        // POST: RActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        /* public async Task<IActionResult> Create([Bind("Id,Type,UserID,PropertyID,RequestID,On")] Activity activity)
         {
             if (ModelState.IsValid)
             {
                 activity.UserID = User.Identity.Name;
                 activity.On = DateTime.Now;
                 _context.Add(activity);
                 await _context.SaveChangesAsync();
                 return RedirectToAction("Index");
             }
             return View(activity);
         }*/
        public async Task<IActionResult> Create(string type, int propertyID, int requestID)
        {

            var activity = new Activity()
            {
                Type = type,
                PropertyID = propertyID,
                RequestID = requestID,
                UserID = User.Identity.Name,
                On = DateTime.Now
            };
            if (type == "TAKE")
            {
                var ppty = _context.Property.Where(x => x.Id == propertyID).FirstOrDefault();
                ppty.Available = false;
               /* var editedppty = new Property() {
                    Available = false,
                    Currency = ppty.Currency,
                    Description = ppty.Description,
                    Id = ppty.Id,
                    Images=ppty.Images,
                    Price=ppty.Price,
                    Terms=ppty.Terms,
                    Title=ppty.Title,
                    UserID=ppty.UserID
                };*/
                
                    //_context.Property.Attach(editedppty).Property(x => x.Available).IsModified = true;                
                   
                
            }
            _context.Add(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Requester),"Home");

            //return View(activity);
        }
        // GET: RActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: RActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,UserID,PropertyID,RequestID,On")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: RActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .SingleOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: RActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.Id == id);
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}
