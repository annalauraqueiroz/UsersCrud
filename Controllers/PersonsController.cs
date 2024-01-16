using CRUDUsuarios.Models;
using CRUDUsuarios.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDUsuarios.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonService _personService;
        public PersonsController(PersonService personService)
        {
            _personService = personService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _personService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Form(int id)
        {
            if(id>0)
            {
                var obj = await _personService.FindByIdAsync(id);
                return View(obj);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado" });
            }
            var obj = await _personService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, PersonModel person)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            if (id == 0)
            {
                await _personService.InsertAsync(person);
                return RedirectToAction(nameof(Index));
            }
            if (id != person.PersonId)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _personService.UpdateAsync(person);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


    }

}
