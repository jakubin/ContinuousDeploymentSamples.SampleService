using System;
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
                return db.Notes.Where(x => !x.IsDeleted).ToList();
            }
        }

        public int Add(Note note)
        {
            using (var db = new SampleServiceEntities())
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return note.Id;
            }
        }

        public Note GetById(int id)
        {
            using (var db = new SampleServiceEntities())
            {
                return db.Notes.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            }
        }

        public bool Delete(int id)
        {
            using (var db = new SampleServiceEntities())
            {
                var note = db.Notes.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

                if (note == null)
                {
                    return false;
                }

                note.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }
    }
}