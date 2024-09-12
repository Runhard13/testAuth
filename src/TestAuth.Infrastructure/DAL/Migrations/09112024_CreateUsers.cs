using FluentMigrator;
using FluentMigrator.Postgres;

namespace TestAuth.Infrastructure.DAL.Migrations;

[Migration(1)]
public class CreateUsers : Migration
{

    public override void Up()
    {
        Create
            .Table("users")
            .WithColumn("id").AsGuid().PrimaryKey().NotNullable().WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
            .WithColumn("username").AsString().NotNullable().Unique()
            .WithColumn("password_salt").AsString().NotNullable()
            .WithColumn("password_hash").AsString().NotNullable()
            .WithColumn("is_active").AsBoolean().NotNullable().WithDefaultValue(true);
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}
