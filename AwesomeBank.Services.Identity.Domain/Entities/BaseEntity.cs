namespace AwesomeBank.Services.Identity.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Active = true;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
