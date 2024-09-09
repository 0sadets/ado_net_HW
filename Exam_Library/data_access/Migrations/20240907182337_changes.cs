using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Library.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Libraries_LibraryId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Books_BookId",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Clients_ClientId",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Books_BookId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Workers_WorkerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Libraries_LibraryId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Neil Josten is the newest addition to the Palmetto State University Exy team.", 5 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "He knew when he came to PSU he wouldn't survive the year, but with his death right around the corner he's got more reasons than ever to live. ", 8 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "It is a truth Jean has built his life around, a reminder this is the best he can hope for and all he deserves.", 4 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "\"I see you are interested in the dark\" is a story about impenetrable human indifference and the darkness within us", 9 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Zachary Ezra Rawlins is an ordinary student living on a university campus in Vermont.", 6 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "The narrator describes his family's trip to the fictional seaside town of Torre di Venere, where he encounters a magician and hypnotist named Cipolla.", 3 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Set in small-town Alabama, the novel is a bildungsroman and chronicles the childhood of Scout and Jem Finch as their father Atticus defends a Black man falsely accused of rape. ", 8 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Jane describes herself as, \"poor, obscure, plain and little.\" Mr. Rochester once compliments Jane's \"hazel eyes and hazel hair\"", 7 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Rating" },
                values: new object[] { "The story tells about the events in the small town of Konotop", 8 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Turner_W", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Lopez", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Wuda", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "Password" },
                values: new object[] { "San_J", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Tom_Z", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Foster", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Pelipe", "132" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Login", "Password" },
                values: new object[] { "J_Isaias", "123" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Login", "Password" },
                values: new object[] { "G_Faris", "123465789" });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClientId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClientId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClientId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClientId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                column: "ClientId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "Password" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Libraries_LibraryId",
                table: "Clients",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Books_BookId",
                table: "Reserveds",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Clients_ClientId",
                table: "Reserveds",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Books_BookId",
                table: "Sales",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Workers_WorkerId",
                table: "Sales",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Libraries_LibraryId",
                table: "Workers",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Libraries_LibraryId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Books_BookId",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Clients_ClientId",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Books_BookId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Workers_WorkerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Libraries_LibraryId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Neil Josten is the newest addition to the Palmetto State University Exy team. He's short, he's fast, he's got a ton of potential — and he's the runaway son of the murderous crime lord known as The Butcher. Signing a contract with the PSU Foxes is the last thing a guy like Neil should do.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Neil Josten is out of time. He knew when he came to PSU he wouldn't survive the year, but with his death right around the corner he's got more reasons than ever to live. Befriending the Foxes was inadvisable. Kissing one is unthinkable. Neil should know better than to get involved with anyone this close to the end, but Andrew's never been the easiest person to walk away from. ");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "It is a truth Jean has built his life around, a reminder this is the best he can hope for and all he deserves. But when he is stolen from Edgar Allan University and sold to a more dangerous master, Jean is forced to contend with a life outside of the Nest for the first time in five years. ");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "\"I see you are interested in the dark\" is a story about impenetrable human indifference and the darkness within us. About being honest with ourselves and the price we are willing to pay for forgetting. About sins that materialize and atonement, more expensive than peace.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Zachary Ezra Rawlins is an ordinary student living on a university campus in Vermont. But somehow he gets his hands on a mysterious book from a dusty library shelf. Holding his breath, Zachary turns page after page, fascinated by the fate of unlucky lovers, when he comes across something completely unexpected - a story from his own childhood.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "The narrator describes his family's trip to the fictional seaside town of Torre di Venere, where he encounters a magician and hypnotist named Cipolla. But the charismatic plasterer uses his own abilities to control the audience in a very brutal and fascist way.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Set in small-town Alabama, the novel is a bildungsroman, or coming-of-age story, and chronicles the childhood of Scout and Jem Finch as their father Atticus defends a Black man falsely accused of rape. ");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Jane describes herself as, \"poor, obscure, plain and little.\" Mr. Rochester once compliments Jane's \"hazel eyes and hazel hair\", but she informs the reader that Mr. Rochester was mistaken, as her eyes are not hazel; they are in fact green.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "The story tells about the events in the small town of Konotopi, where local officials, in particular the centurion Nikita Zabryokha and the clerk Pistryak, dive into the search for a witch. Because of superstitions, ignorance and intrigues, they get into funny situations. The main events revolve around false accusations of witchcraft and the consequences for the local people.");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClientId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                column: "ClientId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Libraries_LibraryId",
                table: "Clients",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Books_BookId",
                table: "Reserveds",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Clients_ClientId",
                table: "Reserveds",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Books_BookId",
                table: "Sales",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Workers_WorkerId",
                table: "Sales",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Libraries_LibraryId",
                table: "Workers",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
