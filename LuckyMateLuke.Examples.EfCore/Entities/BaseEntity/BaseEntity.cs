namespace LuckyMateLuke.Examples.EfCore.Entities.BaseEntity;

public class BaseEntity
{
    public BaseEntity(DefaultInformation information)
    {
        if (information is null)
            throw new ArgumentNullException(nameof(information));
        MetaData = new Meta
        {
            CreatedBy = information.UserId,
            CreatedOnUtc = DateTime.UtcNow
        };
    }

    internal BaseEntity()
    {
    }

    public int Id { get; set; }

    public int SchoolId { get; set; }

    public Meta MetaData { get; set; }

    public class Meta
    {
        public int? CreatedBy { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOnUtc { get; set; }
    }
}