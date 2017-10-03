using System;
using System.Collections.Generic;

namespace Ninja.View
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/2/2017 11:23:00 AM
    public class NinjaWithEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


        public List<EquipmentView> Equipment { get; set; }
    }
}
