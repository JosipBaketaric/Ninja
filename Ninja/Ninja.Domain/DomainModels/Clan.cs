
using System;
using System.Collections.Generic;
namespace Ninja.Domain
{
    public class Clan : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual List<Ninja> Ninjas { get; set; }

    }
}
