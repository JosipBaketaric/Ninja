
using System;
using System.Collections.Generic;
namespace Ninja.Domain
{
    public class Ninja : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Auth
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationTime { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Clan Clan { get; set; }
        public virtual List<Equipment> Equipment { get; set; }

    }
}
