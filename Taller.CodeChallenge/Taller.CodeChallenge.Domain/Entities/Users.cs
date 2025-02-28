using System.ComponentModel.DataAnnotations;

namespace Taller.CodeChallenge.Domain.Entities
{
    /// <summary>
    /// If we want to use SQLServer fisical, this class could heritage from Entity class
    /// In our case we are using the database in memory.
    /// </summary>
    public class Users
    {
        public Users() => Id = Guid.NewGuid();

        [Key]
        public virtual Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
