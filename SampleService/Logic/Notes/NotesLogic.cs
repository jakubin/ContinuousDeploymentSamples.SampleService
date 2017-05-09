﻿using System;
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
    }
}