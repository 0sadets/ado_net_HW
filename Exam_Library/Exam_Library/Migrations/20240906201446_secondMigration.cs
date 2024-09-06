using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam_Library.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "DataEnd", "DataStart", "DiscountPercentage", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, "Autumn Action" },
                    { 2, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, "After Summer Action" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "Lastname", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "Sakavic", "Nora" },
                    { 2, "Ukraine", "Pavlyuk", "Hilarion" },
                    { 3, "USA", "Morgenstern", "Erin" },
                    { 4, "Ukraine", "Tsybulska", "V." },
                    { 5, "Germany", "Mann", "Thomas" },
                    { 6, "USA", "Bradbury", "Ray" },
                    { 7, "USA", "Lee", "Harper" },
                    { 8, "UK", "Brontë", "Charlotte" },
                    { 9, "Ukraine", "Kvitky-Osnovyanenko", "Grigory" }
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Kyivska street, 44, Rivne, Rivne region", "Central city library named after V. Korolenko" },
                    { 2, "Kyivska street, 18, Rivne, Rivne region", "Rivne regional library for young people" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Cost", "Count", "Description", "Genre", "HasDiscount", "IsSequel", "LibraryId", "Name", "NumberOfPages", "Price", "Publisher", "Status", "Year" },
                values: new object[,]
                {
                    { 1, 1, 520m, 10, "Neil Josten is the newest addition to the Palmetto State University Exy team. He's short, he's fast, he's got a ton of potential — and he's the runaway son of the murderous crime lord known as The Butcher. Signing a contract with the PSU Foxes is the last thing a guy like Neil should do.", "Young Adult", false, false, 1, "The Foxhole Court", 260, 570m, "Nora Sakavic", "Available", 2013 },
                    { 2, 1, 590m, 10, "The Foxes are a fractured mess, but their latest disaster might be the miracle they've always needed to come together as a team. The one person standing in their way is Andrew, and the only one who can break through his personal barriers is Neil.", "Contemporary literature", false, true, 1, "The Raven King", 432, 670m, "Nora Sakavic", "Available", 2013 },
                    { 3, 1, 640m, 1, "Neil Josten is out of time. He knew when he came to PSU he wouldn't survive the year, but with his death right around the corner he's got more reasons than ever to live. Befriending the Foxes was inadvisable. Kissing one is unthinkable. Neil should know better than to get involved with anyone this close to the end, but Andrew's never been the easiest person to walk away from. ", "Contemporary literature", false, true, 1, "The King's Men", 448, 750m, "Nora Sakavic", "Reserved", 2014 },
                    { 4, 1, 630m, 0, "It is a truth Jean has built his life around, a reminder this is the best he can hope for and all he deserves. But when he is stolen from Edgar Allan University and sold to a more dangerous master, Jean is forced to contend with a life outside of the Nest for the first time in five years. ", "Contemporary literature", false, false, 1, "The Sunshine Court", 330, 630m, "Nora Sakavic", "Sold", 2024 },
                    { 5, 2, 550m, 15, "\"I see you are interested in the dark\" is a story about impenetrable human indifference and the darkness within us. About being honest with ourselves and the price we are willing to pay for forgetting. About sins that materialize and atonement, more expensive than peace.", "Fiction", false, false, 1, "I see you are interested in the dark", 664, 550m, "Old Lion Publishing House", "Available", 2022 },
                    { 6, 3, 230m, 8, "Zachary Ezra Rawlins is an ordinary student living on a university campus in Vermont. But somehow he gets his hands on a mysterious book from a dusty library shelf. Holding his breath, Zachary turns page after page, fascinated by the fate of unlucky lovers, when he comes across something completely unexpected - a story from his own childhood.", "Adventure novel", false, false, 1, "Starless sea", 554, 230m, "Vivat", "Available", 2023 },
                    { 7, 4, 250m, 9, "Elena's life has finally become truly happy: the smell of delicious coffee in a cozy house, a beloved husband and a cute dog nearby, soon - a dream wedding...", "Mystical Horror", false, false, 2, "Konotop Witch", 272, 250m, "KSD", "Available", 2024 },
                    { 8, 5, 440m, 10, "The narrator describes his family's trip to the fictional seaside town of Torre di Venere, where he encounters a magician and hypnotist named Cipolla. But the charismatic plasterer uses his own abilities to control the audience in a very brutal and fascist way.", "novel", true, false, 2, "\"Death in Venice\" and other short stories", 312, 440m, "Laboratory", "Available", 1912 },
                    { 9, 6, 200m, 12, "Fahrenheit 451 tells the story of Guy Montag and his transformation from a book-burning fireman to a book-reading rebel. ", "fantasy, horror", false, false, 2, "451° Fahrenheit", 272, 220m, "Educational book - Bohdan", "Available", 1953 },
                    { 10, 7, 400m, 20, "Set in small-town Alabama, the novel is a bildungsroman, or coming-of-age story, and chronicles the childhood of Scout and Jem Finch as their father Atticus defends a Black man falsely accused of rape. ", "Southern Gothic Bildungsroman", true, false, 2, "To kill a mockingbird", 384, 400m, "KM-BUKS", "Available", 1960 },
                    { 11, 8, 460m, 19, "Jane describes herself as, \"poor, obscure, plain and little.\" Mr. Rochester once compliments Jane's \"hazel eyes and hazel hair\", but she informs the reader that Mr. Rochester was mistaken, as her eyes are not hazel; they are in fact green.", "Gothic Bildungsroman Romance", true, false, 2, "Jane Eyre", 728, 460m, "Nebo Booklab Publishing", "Available", 1847 },
                    { 12, 9, 390m, 17, "The story tells about the events in the small town of Konotopi, where local officials, in particular the centurion Nikita Zabryokha and the clerk Pistryak, dive into the search for a witch. Because of superstitions, ignorance and intrigues, they get into funny situations. The main events revolve around false accusations of witchcraft and the consequences for the local people.", "Satirical story", true, false, 2, "Konotop Witch", 524, 390m, "Vivat", "Available", 1833 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "LibraryId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "Turner", "Winifrede" },
                    { 2, 1, "Lopez", "Quintina" },
                    { 3, 1, "White", "Uda" },
                    { 4, 1, "Sanchez", "Jonah" },
                    { 5, 1, "Thomas", "Zachery" },
                    { 6, 2, "Foster", "Quartney" },
                    { 7, 2, "Perez", "Felipe" },
                    { 8, 2, "Jackson", "Isaias" },
                    { 9, 2, "Garcia", "Faris" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "LibraryId", "Name", "Position", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "Sergay", "Seller", 16000m, "Kulumyk" },
                    { 2, 1, "Olena", "Manager", 26000m, "Kvitka" },
                    { 3, 2, "Ivan", "Seller", 20000m, "Symonenko" },
                    { 4, 1, "Petro", "Director", 35000m, "Vunograskiy" },
                    { 5, 2, "Sveta", "Manager", 28000m, "Socol" },
                    { 6, 1, "Andriy", "Director", 37000m, "Petlura" }
                });

            migrationBuilder.InsertData(
                table: "Reserveds",
                columns: new[] { "Id", "BookId", "ClientId", "DateOfReservetion", "Status" },
                values: new object[,]
                {
                    { 1, 4, 5, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 2, 3, 2, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 3, 7, 4, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 4, 11, 8, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 5, 8, 9, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 6, 9, 1, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BookId", "ClientId", "Quantity", "SaleDate", "TotalPrice", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 570m, 1 },
                    { 2, 5, 0, 2, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1140m, 4 },
                    { 3, 4, 0, 1, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 630m, 5 },
                    { 4, 12, 0, 3, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1170m, 1 },
                    { 5, 6, 0, 1, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 230m, 1 },
                    { 6, 9, 0, 1, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 220m, 1 },
                    { 7, 8, 0, 2, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 880m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reserveds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
