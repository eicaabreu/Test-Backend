
using TEST.Domain.SeedWork;

namespace TEST.Domain.ValueObjects
{
    public class Permission : ValueObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
        public string Date { get; set; }
        internal Permission() { }

        public Permission(string name, string lastName, int permissionTypeId, string date)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("must be required", nameof(name));
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("must be required", nameof(lastName));
            if (string.IsNullOrEmpty(date)) throw new ArgumentException("must be required", nameof(date));
            if (permissionTypeId <= 0) throw new ArgumentOutOfRangeException(nameof(permissionTypeId), "must be greater than 0");

            Name = name;
            LastName = lastName;
            PermissionTypeId = permissionTypeId;
            Date = date;


        }
        public Permission(int id, string name, string lastName, int permissionTypeId, string date)
                      : this(name, lastName, permissionTypeId, date)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "must be greater than 0");
            Id = id;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
            yield return LastName;
            yield return PermissionTypeId;
            yield return Date;

        }
    }
}
