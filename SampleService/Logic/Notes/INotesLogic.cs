﻿using System.Collections.Generic;
using SampleService.DataAccess;

namespace SampleService.Logic.Notes
{
    public interface INotesLogic
    {
        List<Note> GetAll();
    }
}