using System;

namespace Teamdare.Database.Base
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}