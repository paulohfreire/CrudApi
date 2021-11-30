using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudApi.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Smartphone','Xiaomi Redmi 10',999.90,50,'xiaomi.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Capa de Celular','Capa para modelos Samsung',5.65,70,'capa.jpg',2)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Echo dot 3','Integrado com alexa',320.25,80,'echo.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Calculadora escolar','Calculadora simples',15.39,20,'calculadora1.jpg',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
