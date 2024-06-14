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
        [MaxLength(255)]
        public required string Name { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        public required string Email { get; set; }
        
        [Required]
        [Column("password_salt")]
        [MaxLength(255)]
        public required string PasswordSalt { get; set; }
        
        [Required]
        [Column("password")]
        [MaxLength(255)]
        public required string Password { get; set; }
    }
}
