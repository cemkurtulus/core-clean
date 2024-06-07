using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infra.Adapters.Postgres.Entities
{
    [Table("customer")]
    public class CustomerEntity: DbContext
    {
        [Key]
        [Column("id")]

        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("email")]
        public required string Email { get; set; }
    }
}
