using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    member_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    membership_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    publish_year = table.Column<int>(type: "int", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_books_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Categories",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Categories", x => new { x.book_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_Book_Categories_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Categories_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    loan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    member_id = table.Column<int>(type: "int", nullable: false),
                    loan_date = table.Column<DateOnly>(type: "date", nullable: true),
                    due_date = table.Column<DateOnly>(type: "date", nullable: true),
                    return_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.loan_id);
                    table.ForeignKey(
                        name: "FK_Loans_Members_member_id",
                        column: x => x.member_id,
                        principalTable: "Members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Categories_category_id",
                table: "Book_Categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_book_id",
                table: "Loans",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_member_id",
                table: "Loans",
                column: "member_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Categories");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
