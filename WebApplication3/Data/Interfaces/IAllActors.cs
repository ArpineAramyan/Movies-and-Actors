using WebApplication3.Data.Models;
using System.Collections.Generic;

namespace WebApplication3.Data.Interfaces
{
    public interface IAllActors
    {
        IEnumerable<Actor> AllActors { get; } // spisok

        Actor GetObjectActor(int ActorId);
    }
}
