using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopRatedMovies",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    MediaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    TotalRatings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TopScreenedMovies",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    MediaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalScreenings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TopSoldMovies",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    MediaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketsSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorMedia",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMedia", x => new { x.CastId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_ActorMedia_Actors_CastId",
                        column: x => x.CastId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxSeatsNumber = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMedia_MediaId",
                table: "ActorMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MediaId",
                table: "Ratings",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MediaId",
                table: "Screenings",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScreeningId",
                table: "Tickets",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            //STORED PROCEDURES
            var procedureTopRated = @"CREATE PROCEDURE spGet_Top10_RatedMovies
                                        AS
                                        BEGIN
                                            SELECT TOP(10) m.Id as MediaId, m.Title as MediaTitle, Count(r.Value) as TotalRatings, AVG(r.Value) as AverageRating
                                            FROM Media m
                                            INNER JOIN dbo.Ratings r
                                            ON m.Id = r.MediaId
                                            GROUP BY m.Id, Title
                                            HAVING Count(r.Value) >= (SELECT COUNT(rr.Value)
                                                        FROM dbo.Ratings rr
                                                        INNER JOIN dbo.Media mm
                                                        ON mm.Id = rr.MediaId
                                                        GROUP BY mm.Id
                                                        ORDER BY COUNT(r.Value) DESC
                                                        OFFSET 10 ROWS
                                                        FETCH NEXT 1 ROWS ONLY)
                                            ORDER BY AVG(r.Value) DESC
                                        END";
            migrationBuilder.Sql(procedureTopRated);

            var procedureTopScreened = @"CREATE PROCEDURE spGet_Top10_ScreenedMovies
                                                           @StartDate date,
                                                           @EndDate date
                                        AS
                                        BEGIN
                                                SELECT TOP(10) m.Id as MediaId, m.Title as MediaTitle, COUNT(s.Id) AS TotalScreenings
	                                            FROM Media m, Screenings s
	                                            WHERE m.Id = s.MediaId AND m.MediaType = 0
	                                            AND @StartDate <=  s.StartTime
	                                            AND s.StartTime  <= @EndDate
	                                            GROUP BY m.Id ,m.Title
	                                            ORDER BY COUNT(s.Id) DESC
                                        END";
            migrationBuilder.Sql(procedureTopScreened);

            var procedureTopSold = @"CREATE PROCEDURE spGet_Top_Sold_Movies
                                    AS
                                    BEGIN
                                            SELECT m.Id as MediaId, m.Title as MediaTitle, t.ScreeningId AS ScreeningId, COUNT(t.Id) as TicketsSold
                                            FROM Media m, Tickets t
                                            GROUP BY m.Id, t.MediaId, m.Title, t.ScreeningId
                                            HAVING (SELECT COUNT(*) FROM Ratings r WHERE r.MediaId = m.Id) = 0 AND m.Id = t.MediaId
                                            ORDER BY COUNT(t.Id) DESC
                                    END";
            migrationBuilder.Sql(procedureTopSold);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMedia");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TopRatedMovies");

            migrationBuilder.DropTable(
                name: "TopScreenedMovies");

            migrationBuilder.DropTable(
                name: "TopSoldMovies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
