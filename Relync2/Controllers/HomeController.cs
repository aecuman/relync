using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Relync2.Data;
using Relync2.Models;
using Microsoft.AspNetCore.Identity;

namespace Relync2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!HasProfile(User.Identity.Name)) {
                  return  RedirectToAction(nameof(ProfilesController.Create), "Profiles");
                }
                if (!HasRequest(User.Identity.Name)) {
                    return RedirectToAction(nameof(RequestsController.Create), "Requests");
                }
                return RedirectToAction("Requester");
              
            }
            else {return View(); }
            
        }
        public bool HasProfile(string Username) {
            if (_context.Profile.Where(x => x.Username == Username).Count() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasRequest(string Username)
        {
            if (_context.Request.Where(x => x.UserID == Username).Count() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult _Request()
        {

            return View( _context.Request.Where(x => x.UserID == User.Identity.Name && x.Active == true).FirstOrDefault());
        }
        public IActionResult Requester()
        {
                if (!HasProfile(User.Identity.Name))
                {
                    return RedirectToAction(nameof(ProfilesController.Create), "Profiles");
                }
                if (!HasRequest(User.Identity.Name))
                {
                    return RedirectToAction(nameof(RequestsController.Create), "Requests");
                }
                // var _requestID = _context.Activity.Where(x=>x.UserID==User.Identity.Name).FirstOrDefault().RequestID;
                var _request = _context.Request.Where(x => x.UserID == User.Identity.Name && x.Active == true).Last();
            ViewData["req"] = _request;
            ViewData["reqID"] = _request.id;
            var _offers = _context.Activity.Where(x => x.Type == "OFFER" && x.RequestID == _request.id);
            var _offeredProperties = _context.Property.Where(x => _offers.Any(o => o.PropertyID == x.Id && o.RequestID == _request.id));
            return View(_offeredProperties);
            
        }
        public IActionResult Provider()
        {
             
            var _requests = _context.Request.Where(x => x.Active == true);
            ViewData["reqList"] = _requests;
            var _providersPropertys = _context.Property.Where(x => x.UserID == User.Identity.Name);
            ViewData["prov"] = _providersPropertys;
            ViewData["provlist"] = _providersPropertys;
            var _providersPropertiesOffered = _providersPropertys.Where(p => _context.Activity.Any(x => x.PropertyID == p.Id&& x.Type == "ACCEPT" || x.Type == "TAKE"));
           
           // var _providersRequests = _context.Activity.Where(x => x.Type == "ACCEPT" || x.Type == "TAKE"& _providersPropertys.Any(p=>p.Id==x.PropertyID));
            return View(_providersPropertiesOffered);
            
        }
        public IActionResult _RequestList()
        {
            
            return View();
        }
        public IActionResult _ProviderList()
        {
            return View();
        }
        public IActionResult _Offer()
        {
            return View();
        }
        public IActionResult _reqID()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
