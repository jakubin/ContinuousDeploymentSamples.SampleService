using System;
using System.Collections.Generic;
using System.Linq;
using SampleService.DataAccess;

namespace SampleService.Logic.Notes
{
    public class NotesLogic : INotesLogic
    {
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
                return db.Notes.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Delete(int id)
        {
            using (var db = new SampleServiceEntities())
            {
                var note = db.Notes.FirstOrDefault(x => x.Id == id);

                if (note == null)
                {
                    return false;
                }

                db.Notes.Remove(note);
                db.SaveChanges();
                return true;
            }
        }

        public bool CheckStatus()
        {
            try
            {
                using (var db = new SampleServiceEntities())
                {
                    db.Database.ExecuteSqlCommand("SELECT 1");
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}