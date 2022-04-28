using System.Collections.Generic;
using System.Linq;
using WebApplication3.Data.Interfaces;
using WebApplication3.Data.Models;

namespace WebApplication3.Data.Repository
{
    public class ActorsRepository : IAllActors
    {
        private readonly AppDBContent appDBContent;
        public ActorsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Actor> AllActors => appDBContent.Actors;

        public Actor GetObjectActor(int ActorId) => appDBContent.Actors.FirstOrDefault(p => p.Id == ActorId);
    }
}
