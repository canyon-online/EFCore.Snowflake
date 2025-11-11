using EFCore.Snowflake.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EFCore.Snowflake.FunctionalTests;

public class MaterializationInterceptionSnowflakeTest :
    MaterializationInterceptionTestBase<MaterializationInterceptionSnowflakeTest.SnowflakeLibraryContext>
{
    public MaterializationInterceptionSnowflakeTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    public class SnowflakeLibraryContext(DbContextOptions options) : MaterializationInterceptionTestBase<SnowflakeLibraryContext>.LibraryContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestEntity30244>().OwnsMany(e => e.Settings);
        }
    }

    protected override ITestStoreFactory TestStoreFactory
        => SnowflakeTestStoreFactory.Instance;
}
