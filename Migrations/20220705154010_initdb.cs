using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Title", "Created", "Content" },
                values: new object[]{
                    "Bai viet 1",
                    new DateTime(2021,08,20),
                    "Noi dung 1"
                }
            );
            Randomizer.Seed = new Random(8675309);
            var fakerAricle = new Faker<Article>();
            fakerAricle.RuleFor(a => a.Title, f =>
            {
                return f.Lorem.Sentence(5, 5);
            });

            fakerAricle.RuleFor(a => a.Created, f =>
            {
                return f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 07, 30));
            });
            fakerAricle.RuleFor(a => a.Content, f =>
            {
                return f.Lorem.Paragraphs(1, 4);
            });

            for (int i = 0; i < 150; i++)
            {
                var article = fakerAricle.Generate();

                migrationBuilder.InsertData(
                    table: "Article",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[]{
                   article.Title,
                   article.Created,
                   article.Content
                    }
                );
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
