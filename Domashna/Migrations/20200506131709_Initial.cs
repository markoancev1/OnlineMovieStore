using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domashna.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    Popularity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingMovies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentingMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentingMovies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    YearOfRelease = table.Column<DateTime>(nullable: false),
                    DirectorID = table.Column<int>(nullable: false),
                    DirectorName = table.Column<string>(nullable: true),
                    GenreID = table.Column<int>(nullable: false),
                    GenreName = table.Column<string>(nullable: true),
                    IMBDScore = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    SoldItems = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    MovieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e74", "4a8b4a38-559b-4afe-a406-167773e3c3bf", "editor", "EDITOR" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "3b3a676a-e333-4e2b-a3f6-2dfab788ac81", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "c2ff1e45-dfe2-4ff4-b56c-34f62d35e079", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "admin@onlinemoviestore.com", true, false, null, "ADMIN@ONLINEMOVIESTORE.COM", "ADMIN@ONLINEMOVIESTORE.COM", "AQAAAAEAACcQAAAAEJZ67j2KyZEUwQX+E64YQC8w8SuvwnhGJ8nQiZSoBrUtRuWWKyHgOSkEFzuiJ/EWVg==", null, false, "", false, "admin@onlinemoviestore.com" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "Name", "Popularity" },
                values: new object[,]
                {
                    { 10, "Japan", "Akira Kurosawa", false },
                    { 9, "England", "Ridley Scott", true },
                    { 8, "USA", "Francis Ford Coppola", false },
                    { 1, "USA", "Steven Spielberg", true },
                    { 6, "Yugoslavia", "Krsto Papic", true },
                    { 5, "USA", "Quentin Tarantino", false },
                    { 4, "USA", "Stanley Kubrick", false },
                    { 3, "England", "Alfred Hitchcock ", true },
                    { 2, "USA", "Martin Scorsese", false },
                    { 7, "USA", "Orson Welles", true }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 3, "Crime" },
                    { 4, "Adventure" },
                    { 5, "Drama" },
                    { 6, "Fantasy" },
                    { 7, "Thrillers" },
                    { 8, "General" },
                    { 9, "Horror" },
                    { 10, "Sci-fi" },
                    { 2, "Action" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Country", "Description", "DirectorID", "DirectorName", "GenreID", "GenreName", "IMBDScore", "Language", "PhotoURL", "Price", "SoldItems", "Title", "UserId", "YearOfRelease" },
                values: new object[,]
                {
                    { 2, "USA", "Opening with the Allied invasion of Normandy on 6 June 1944, members of the 2nd Ranger Battalion under Cpt.Miller fight ashore to secure a beachhead. Amidst the fighting, two brothers are killed in action. Earlier in New Guinea, a third brother is KIA.Their mother, Mrs. Ryan, is to receive all three of the grave telegrams on the same day. The United States Army Chief of Staff, George C. Marshall,is given an opportunity to alleviate some of her grief when he learns of a fourth brother, Private James Ryan, and decides to send out 8 men(Cpt. Miller and select members from 2nd Rangers) to find him and bring him back home to his mother... Written by J.Zelman", 1, "Steven Spielberg", 2, "Action", 8.0999999999999996, "English", "Saving_Private_Ryan_poster.jpg", 14.99, 0, "Saving Private Ryan", 0, new DateTime(1981, 7, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "USA", "JHenry Hill might be a small time gangster, who may have taken part in a robbery with Jimmy Conway and Tommy De Vito,two other gangsters who might have set their sights a bit higher. His two partners could kill off everyone else involved in the robbery,and slowly start to think about climbing up through the hierarchy of the Mob. Henry, however, might be badly affected by his partners' success,but will he consider stooping low enough to bring about the downfall of Jimmy and Tommy? Written by Colin Tinto", 2, "Martin Scorsese", 3, "Crime", 8.6999999999999993, "English", "Goodfellas.jpg", 9.9900000000000002, 0, "Goodfellas", 0, new DateTime(1990, 5, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "USA", "Jules Winnfield (Samuel L. Jackson) and Vincent Vega (John Travolta) are two hit men who are out to retrieve a suitcase stolen from their employer,mob boss Marsellus Wallace (Ving Rhames). Wallace has also asked Vincent to take his wife Mia (Uma Thurman) out a few days later when Wallace himself will be out of town.Butch Coolidge (Bruce Willis) is an aging boxer who is paid by Wallace to lose his fight. The lives of these seemingly unrelated people are woven together comprising of aseries of funny, bizarre and uncalled-for incidents. Written by Soumitra", 5, "Quentin Tarantino", 3, "Crime", 8.9000000000000004, "English", "Pulp_Fiction_(1994)_poster.jpg", 19.989999999999998, 0, "Pulp Fiction", 0, new DateTime(1994, 10, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "USA", "Maximus is a powerful Roman general, loved by the people and the aging Emperor, Marcus Aurelius. Before his death,the Emperor chooses Maximus to be his heir over his own son, Commodus, and a power struggle leaves Maximus and his family condemned to death.The powerful general is unable to save his family, and his loss of will allows him to get captured and put into the Gladiator games until he dies.The only desire that fuels him now is the chance to rise to the top so that he will be able to look into the eyes of the man who will feel his revenge.Written by Chris Terry", 9, "Ridley Scott", 4, "Adventure", 8.5, "English", "Gladiator_(2000_film_poster).png", 9.9900000000000002, 0, "Gladiator", 0, new DateTime(2000, 5, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Yugoslavia", "Life and times of Nikola Tesla, famous scientist whose inventions were stolen,but whose greatest contribution to mankind remain a mystery to this day. Written by Dragan Antulov", 6, "Krsto Papic", 5, "Drama", 7.4000000000000004, "English", "AL.jpg", 9.9900000000000002, 0, "The Secret Life of Nikola Tesla", 0, new DateTime(1980, 2, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Japan", "When a powerful warlord in medieval Japan dies, a poor thief recruited to impersonate him finds difficulty living up to his role and clashes with the spirit of the warlord during turbulent times in the kingdom. Written by Keith Loh", 10, "Akira Kurosawa ", 5, "Drama", 8.0, "Japanese", "Kagemusha_poster.jpg", 4.9900000000000002, 0, "Kagemusha", 0, new DateTime(1980, 10, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "USA", "Jurassic Park is a 1993 American science fiction adventure film directed by Steven Spielberg and produced by Kathleen Kennedy and Gerald R.Molen. It is the first installment in the Jurassic Park franchise, and is based on the 1990 novel of the same name by Michael Crichton and a screenplay written byCrichton and David Koepp. The film is set on the fictional island of Isla Nublar, located off Central America's Pacific Coast near Costa Rica.There, wealthy businessman John Hammond and a team of genetic scientists have created a wildlife park of de-extinct dinosaurs.When industrial sabotage leads to a catastrophic shutdown of the park's power facilities and security precautions, a small group of visitors andHammond's grandchildren struggle to survive and escape the perilous island.", 1, "Steven Spielberg", 6, "Fantasy", 8.0999999999999996, "English", "Jurassic_Park_poster.jpg", 9.9900000000000002, 0, "Jurassic Park", 0, new DateTime(1993, 6, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "USA", "After a gentle alien becomes stranded on Earth, the being is discovered and befriended by a young boy named Elliott.Bringing the extraterrestrial into his suburban California house, Elliott introduces E.T., as the alien is dubbed, to his brother and his little sister, Gertie,and the children decide to keep its existence a secret. Soon, however, E.T. falls ill, resulting in government intervention and a dire situation for both Elliott and the alien.Written by Jwelch5742", 1, "Steven Spielberg", 6, "Fantasy", 7.7999999999999998, "English", "V1.jpg", 11.99, 0, "E.T. the Extra-Terrestria", 0, new DateTime(1982, 6, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "USA", "Phoenix office worker Marion Crane is fed up with the way life has treated her. She has to meet her lover Sam in lunch breaks,and they cannot get married because Sam has to give most of his money away in alimony. One Friday, Marion is trusted to bank forty thousand dollars by her employer.Seeing the opportunity to take the money and start a new life, Marion leaves town and heads towards Sam's California store.Tired after the long drive and caught in a storm, she gets off the main highway and pulls into the Bates Motel.The motel is managed by a quiet young man called Norman who seems to be dominated by his mother. Written by Col Needham", 3, "Alfred Hitchcock", 7, "Thriller", 8.5, "English", "Psycho_(1960)_theatrical_poster.jpg", 4.9900000000000002, 0, "Psycho", 0, new DateTime(1960, 9, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "USA", "A young family are visited by ghosts in their home. At first the ghosts appear friendly, moving objects around the house to the amusement of everyone,then they turn nasty and start to terrorise the family before they kidnap the youngest daughter. Written by Rob Hartill", 1, "Steven Spielberg", 9, "Horror", 7.2999999999999998, "English", "Poltergeist_(1982).png", 14.99, 0, "Poltergeist", 0, new DateTime(1982, 6, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "USA", "It's a hot summer on Amity Island, a small community whose main business is its beaches. When new Sheriff Martin Brody discovers the remains of a shark attackvictim, his first inclination is to close the beaches to swimmers. This doesn't sit well with Mayor Larry Vaughn and several of the local businessmen.Brody backs down to his regret as that weekend a young boy is killed by the predator. The dead boy's mother puts out a bounty on the shark and Amity is soon swamped withamateur hunters and fisherman hoping to cash in on the reward. A local fisherman with much experience hunting sharks, Quint, offers to hunt down the creature for a hefty fee.Soon Quint, Brody and Matt Hooper from the Oceanographic Institute are at sea hunting the Great White shark. As Brody succinctly surmises after their first encounter with thecreature, they're going to need a bigger boat. Written by garykmcd", 1, "Steven Spielberg", 9, "Adventure", 8.4000000000000004, "English", "AL_.jpg", 7.9900000000000002, 0, "Jaws", 0, new DateTime(1975, 6, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "USA", "2001 is a story of evolution. Sometime in the distant past, someone or something nudged evolution by placing a monolith on Earth (presumably elsewhere throughout the universe as well). Evolution then enabled humankind to reach the moon's surface, where yet another monolith is found,one that signals the monolith placers that humankind has evolved that far. Now a race begins between computers (HAL) and human (Bowman) to reach the monolith placers.The winner will achieve the next step in evolution, whatever that may be. Written by Larry Cousins", 4, "Stanley Kubrick", 10, "Sci-fi", 8.3000000000000007, "English", "2001_A_Space_Odyssey_(1968).png", 9.9900000000000002, 0, "2001: A Space Odyssey", 0, new DateTime(1968, 5, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "USA", "Two parallel stories are told. In the first, a group of research scientists from a variety of backgrounds are investigating the strange appearance of items inremote locations, primarily desert regions. In continuing their investigation, one of the lead scientists, a Frenchman named Claude Lacombe,incorporates the Kodály method of music education as a means of communication in their work. The response, in turn, at first baffles the researchers,until American cartographer David Laughlin deciphers the meaning of the response. In the second, electric company lineman and family man Roy Neary and single motherJillian Guiler are among some individuals in Muncie, Indiana who experience some paranormal activity before some flashes of bright lights in the sky, which theybelieve to be a UFO. Roy becomes obsessed with what he saw, unlike some others, especially in some form of authority, who refuse to acknowledge their belief thatit was a UFO in not wanting to appear crazy.", 1, "Steven Spielberg", 10, "Sci-fi", 7.5999999999999996, "English", "99.jpg", 13.99, 0, "Close Encounters of the Third Kind", 0, new DateTime(1977, 11, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorID",
                table: "Movies",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                table: "Movies",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MovieId",
                table: "Photos",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ListingMovies");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RentingMovies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
