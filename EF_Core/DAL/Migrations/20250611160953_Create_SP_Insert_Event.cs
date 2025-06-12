using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Create_SP_Insert_Event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                CREATE PROCEDURE SP_Insert_Event
                    @EventName NVARCHAR(100),
                    @EventCategory NVARCHAR(100),
                    @EventDate DATE,
                    @Description NVARCHAR(MAX),
                    @Status NVARCHAR(50)
                AS
                BEGIN
                    INSERT INTO EventDetails (EventName, EventCategory, EventDate, Description, Status)
                    VALUES (@EventName, @EventCategory, @EventDate, @Description, @Status)
                END
            ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSp = @"DROP PROCEDURE IF EXISTS SP_Insert_Event";
            migrationBuilder.Sql(dropSp);
        }
    }
}
