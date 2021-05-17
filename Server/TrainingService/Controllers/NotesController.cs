using Microsoft.AspNetCore.Mvc;
using TrainingService.DBRepository.Interfaces;
using TrainingService.DBRepository.Repositories;
using TrainingService.DBRepository;
using Microsoft.AspNetCore.Identity;
using TrainingService.Models;
using TrainingService.Models.RequestsModels;
using System.IO;
using Newtonsoft.Json;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        INoteRepository _notesRepository;
        private readonly UserManager<User> _userManager;
        public NotesController(UserManager<User> userManager, TrainingServiceContext dbcontext)
        {
            _userManager = userManager;
            _notesRepository = new SQLNotesRepository(dbcontext);                
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetUserNotes()
        {
            return new JsonResult(_notesRepository.GetUserNotes(_userManager.GetUserId(User)));
        }

        [Route("addnote")]
        [HttpPost]
        public JsonResult AddNote()
        {
            var stream = new StreamReader(Request.Body);
            var body = stream.ReadToEndAsync().Result;
            NewNoteRequest newNote;
            try
            {
                newNote = JsonConvert.DeserializeObject<NewNoteRequest>(body);
            }
            catch (JsonReaderException e)
            {
                return new JsonResult(e.ToString());
            }
            if (!TryValidateModel(newNote)) return new JsonResult("Note Content Error!");
            string userId = _userManager.GetUserId(User);
            int newId = _notesRepository.GetNewUserNoteId(userId);
            _notesRepository.AddNote(new Note { UserId = userId, Id = newId, Text = newNote.Text, Title = newNote.Title });
            return new JsonResult("success");
        }



        //[Route("removenote")]
        //public JsonResult DeleteNote(int noteId)
        //{
        //    _noteRepository.DeleteNote(_userManager.GetUserId(User), noteId);
        //    return new JsonResult("success");
        //}
    }
}
