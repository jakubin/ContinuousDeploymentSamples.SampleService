using System.Collections.Generic;
using System.Linq;
using SampleService.DataAccess;

namespace SampleService.Logic.Notes
{
    public class NotesLogic : INotesLogic
    {
        public List<Note> GetAll()
        {
            using (var db = new SampleServiceEntities())
            {
                return db.Notes.ToList();
            }
        }
    }
}