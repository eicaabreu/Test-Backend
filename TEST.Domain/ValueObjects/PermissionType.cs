using TEST.Domain.SeedWork;

namespace TEST.Domain.ValueObjects
{
    public class PermissionType : ValueObject
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Permission> Permission { get; } = new HashSet<Permission>();

        internal PermissionType() { }
        public PermissionType(string description)
        {
            if (string.IsNullOrEmpty(description)) throw new ArgumentException("must be required", nameof(description));


            Description = description;


        }
        public PermissionType(int id, string description)
                      : this(description)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "must be greater than 0");
            Id = id;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Description;

        }

    }
}
