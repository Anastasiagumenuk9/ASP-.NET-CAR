using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MODELS.Migrations
{
    public partial class ko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
           
            migrationBuilder.CreateIndex(
                name: "IX_Cars_PhotoCarId",
                table: "Cars",
                column: "PhotoCarId");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "PhotosCar");

          
        }
    }
}
