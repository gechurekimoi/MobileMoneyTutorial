using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileMoneyTutorial.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmationResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionType = table.Column<string>(nullable: true),
                    TransID = table.Column<string>(nullable: true),
                    TransTime = table.Column<string>(nullable: true),
                    TransAmount = table.Column<string>(nullable: true),
                    BusinessShortCode = table.Column<string>(nullable: true),
                    BillRefNumber = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    OrgAccountBalance = table.Column<string>(nullable: true),
                    ThirdPartyTransID = table.Column<string>(nullable: true),
                    MSISDN = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationResponses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmationResponses");
        }
    }
}
