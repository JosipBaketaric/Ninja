
using System;
namespace Ninja.View
{
    //Author: josipba
    //Machine: P004794
    //Created: 10/2/2017 10:30:08 AM
    public class EquipmentView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }






    public enum EquipmentType
    {
        Weapon = 1,
        Armor = 2,
        Consumable = 3
    }





}
