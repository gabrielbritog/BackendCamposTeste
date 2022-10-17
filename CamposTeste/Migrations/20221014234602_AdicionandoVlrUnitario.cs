using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamposTeste.Migrations
{
    public partial class AdicionandoVlrUnitario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "VlrUnitarioVenda",
                table: "Vendas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlrUnitarioVenda",
                table: "Vendas");
        }
    }
}
