using System.Collections.Generic;
using TrainingService.Models;


namespace TrainingService.DBRepository.Interfaces
{
	public interface INoteRepository //: IDisposable
	{
		List<Note> GetUserNotes(string userId);
		void AddNote(string userId, string text);
	}
}
