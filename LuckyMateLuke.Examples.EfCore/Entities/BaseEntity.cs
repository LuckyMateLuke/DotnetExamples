namespace LuckyMateLuke.Examples.EfCore.Entities;

public class BaseEntity 
{
    public BaseEntity(DefaultInformation information)
    {
        if (information is null)
            throw new ArgumentNullException(nameof(information));
        if (MetaData is null)
            MetaData = new MetaData();
        if (MetaData.CreatedBy == null || MetaData.CreatedBy <= 0)
        {
            MetaData.CreatedBy = information.UserId;
            MetaData.CreatedOnUTC = DateTime.UtcNow;
        }
        else
        {
            MetaData.LastUpdatedBy = information.UserId;
            MetaData.LastUpdatedOnUTC = DateTime.UtcNow;
        }
    } 
    
    internal BaseEntity()
    {
    }
    
    public int Id { get; set; }
    
    public int SchoolId { get; set; }
    
    public MetaData MetaData { get; set; }
    
    public int GroupId { get; set; }
}

public class MetaData
{
    public int? CreatedBy { get; set; }
    
    public DateTime CreatedOnUTC { get; set; }

    public int LastUpdatedBy { get; set; }
    
    public DateTime LastUpdatedOnUTC { get; set; }

}

public class DefaultInformation
{
    public int SchoolId { get; set; }
    
    public int GroupId { get; set; }
    
    public int UserId { get; set; }
}

public record DefaultIds(int schoolId, int groupId, int userId);
