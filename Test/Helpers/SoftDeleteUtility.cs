
namespace Test.Helpers;

public class SoftDeleteUtility
{
    public static void FillSoftDelete(BaseEntity baseEntity, string deletedBy)
    {
        baseEntity.IsDeleted = true;
        baseEntity.DeletedOn = DateTime.UtcNow;
        baseEntity.DeletedBy = deletedBy;
    }
}