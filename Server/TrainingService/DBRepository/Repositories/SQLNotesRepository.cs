using System;
using System.Collections.Generic;
using System.Linq;
using TrainingService.Models;
using TrainingService.DBRepository.Interfaces;

namespace TrainingService.DBRepository.Repositories
{
    public class SQLNotesRepository : INoteRepository
    {
        private TrainingServiceContext context;

        public SQLNotesRepository(TrainingServiceContext _db)
        {
            context = _db;
        }

        public List<Note> GetUserNotes(string userId)
        {
            return context.Notes.Where(note => note.UserId==userId).ToList();
        }

        public void AddNote(string userId,string text)
        {

            context.Notes.Add(new Note {UserId=userId,Text=text } );
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
