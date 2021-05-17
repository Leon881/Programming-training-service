using Microsoft.AspNetCore.Mvc;
using TrainingService.DBRepository.Interfaces;
using TrainingService.DBRepository.Repositories;
using TrainingService.DBRepository;
using Microsoft.AspNetCore.Identity;
using TrainingService.Models;
using System.IO;
using Newtonsoft.Json;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        INoteRepository _noteRepository;
        private readonly UserManager<User> _userManager;
        public NotesController(UserManager<User> userManager, TrainingServiceContext dbcontext)
        {
            _userManager = userManager;
            _noteRepository = new SQLNotesRepository(dbcontext);                
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetUserNotes()
        {
            return new JsonResult(_noteRepository.GetUserNotes(_userManager.GetUserId(User)));
        }
        [Route("addnote")]
        public JsonResult AddNote()
        {
            var stream = new StreamReader(Request.Body);
            var body = stream.ReadToEndAsync().Result;
            NewNote newNote;
            try
            {
                newNote = JsonConvert.DeserializeObject<NewNote>(body);
            }
            catch (JsonReaderException e)
            {
                return new JsonResult(e.ToString());
            }
            if (!TryValidateModel(newNote)) return new JsonResult("Note Content Error!");
            string userId = _userManager.GetUserId(User);
            int newId = _noteRepository.GetNewUserNoteId(userId);
            _noteRepository.AddNote(new Note { UserId = userId, Id = newId, Text = newNote.Text, Title = newNote.Title });
            return new JsonResult("success");
        }
        [Route("removenote")]
        public JsonResult DeleteNote(int noteId)
        {
            _noteRepository.DeleteNote(_userManager.GetUserId(User), noteId);
            return new JsonResult("success");
        }
    }
}
