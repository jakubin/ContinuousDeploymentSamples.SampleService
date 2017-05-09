using System.Collections.Generic;
using SampleService.DataAccess;

namespace SampleService.Logic.Notes
{
    public interface INotesLogic
    {
        int Add(Note note);

        Note GetById(int id);

        bool Delete(int id);

        bool CheckStatus();
    }
}