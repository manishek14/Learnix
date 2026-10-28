using Common.Domain;
using System.ComponentModel.DataAnnotations;

namespace UserModules.Data.Entities
{
    public class Role : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; } 
    }
}