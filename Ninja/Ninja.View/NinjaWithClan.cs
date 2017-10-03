using System;

namespace Ninja.View
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/2/2017 11:21:31 AM
    public class NinjaWithClan
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int ClanId { get; set; }
        public string ClanName { get; set; }
    }
}
