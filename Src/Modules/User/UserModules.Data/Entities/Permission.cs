using Common.Domain;
using System.ComponentModel.DataAnnotations;

namespace UserModules.Data.Entities
{
    public class Permission : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } 

        public List<RolePermission> Roles { get; set; }
    }
}