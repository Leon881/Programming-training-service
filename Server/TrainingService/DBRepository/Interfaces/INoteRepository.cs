using System.Collections.Generic;
using TrainingService.Models;


namespace TrainingService.DBRepository.Interfaces
{
	public interface INoteRepository 
	{
		List<Note> GetUserNotes(string userId);
		void DeleteNote(string userId, int noteId);
		void AddNote(Note newNote);
		int GetNewUserNoteId(string userId);
	}
}
