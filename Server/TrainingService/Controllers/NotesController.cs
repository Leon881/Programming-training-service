using Microsoft.AspNetCore.Mvc;
using TrainingService.DBRepository.Interfaces;
using TrainingService.DBRepository.Repositories;
using Microsoft.AspNetCore.Hosting;
using TrainingService.DBRepository;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        INoteRepository _noteRepository;

        public NotesController(TrainingServiceContext dbcontext)
        {
            _noteRepository = new SQLNotesRepository(dbcontext);      
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetUserNotes()
        {
                return new JsonResult(_noteRepository.GetUserNotes(User.Identity.Name));
        }

    }
}
