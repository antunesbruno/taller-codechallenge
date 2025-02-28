using Flunt.Notifications;

namespace Taller.CodeChallenge.Domain.Entities
{
    /// <summary>
    /// This abstract class could be used when we need a fisical database like a sqlserver
    /// In our case we are using the database in memory
    /// </summary>
    public abstract class Entity : Notifiable<Notification>
    {
        public virtual Guid Id { get; set; }
        protected Entity() => Id = Guid.NewGuid();
    }
}
