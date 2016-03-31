using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AjaxDemo.Migrations
{
    public partial class DestinationsTableNamePlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");
        }
    }
}
