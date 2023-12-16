using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleGetter.Migrations
{
    public partial class classesatt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "altura",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Pessoas",
                newName: "tamanho");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Pessoas",
                newName: "cpf");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCraicao",
                table: "Roupas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCriacao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataCraicao",
                table: "Roupas");

            migrationBuilder.DropColumn(
                name: "dataCriacao",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "tamanho",
                table: "Pessoas",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Pessoas",
                newName: "descricao");

            migrationBuilder.AddColumn<double>(
                name: "altura",
                table: "Pessoas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
