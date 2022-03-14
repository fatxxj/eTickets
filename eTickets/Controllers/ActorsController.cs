using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
            
        }

        // Get: Actors / create
        public  IActionResult Create()
        {
            return View(); 
        }

        [HttpPost] //sending post request to create.chtml
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                //IsValid checkes if we didnt provide data to required input the model state would not be valid
                return View(actor);
            }
            await _service.AddAsync(actor); //add actor to database
            return RedirectToAction(nameof(Index));
        }



        // Get: Actors/Details/1
        public async Task<IActionResult> Details (int id)
        {
            var actorDetails = await _service.GetByIdAsync(id); // check if actor with this id exists
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        // Get: Actors / Edit /1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id); // check if actor with this id exists
            if (actorDetails == null) return View("NotFound");        
            return View(actorDetails);
        }

        [HttpPost] //sending post request to create.chtml
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName, ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                //IsValid checkes if we didnt provide data to required input the model state would not be valid
                return View(actor);
            }
            await _service.UpdateAsync(id,actor); //add actor to database
            return RedirectToAction(nameof(Index));
        }



        // Get: Actors / Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id); // check if actor with this id exists
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")] //sending post request to create.chtml
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id); // check if actor with this id exists
            if (actorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));
        }



    }
}
