using Microsoft.EntityFrameworkCore.Storage;

namespace EFCore.Snowflake.Storage;

public class SnowflakeRelationalCommandBuilder : RelationalCommandBuilder
{
    public SnowflakeRelationalCommandBuilder(RelationalCommandBuilderDependencies dependencies)
        : base(dependencies)
    {
    }

    public override IRelationalCommand Build()
    {
        var commandText = ToString();
        return new SnowflakeRelationalCommand(Dependencies, commandText, commandText, Parameters);
    }
}
