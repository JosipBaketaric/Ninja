
using System;
namespace Ninja.Domain
{
    public class Equipment : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Ninja Ninja { get; set; }
    }
}
