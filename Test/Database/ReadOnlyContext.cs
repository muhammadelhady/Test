using Microsoft.EntityFrameworkCore;

namespace Test.Database;

public sealed class ReadOnlyContext : EventContext
{
    public ReadOnlyContext(DbContextOptions<EventContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    [Obsolete("This context is read-only", true)]
    public new int SaveChanges()
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new int SaveChanges(bool acceptAll)
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
    {
        throw new InvalidOperationException("This context is read-only.");
    }
}