using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class MovieMediaPropRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMedia_Media_MoviesId",
                table: "ActorMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Media_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Media_MediaId",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Screenings");

            migrationBuilder.RenameColumn(
                name: "MovieTitle",
                table: "TopSoldMovies",
                newName: "MediaTitle");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "TopSoldMovies",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "MovieTitle",
                table: "TopScreenedMovies",
                newName: "MediaTitle");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "TopScreenedMovies",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "MovieTitle",
                table: "TopRatedMovies",
                newName: "MediaTitle");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "TopRatedMovies",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Tickets",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Ratings",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                newName: "IX_Ratings_MediaId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "ActorMedia",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMedia_MoviesId",
                table: "ActorMedia",
                newName: "IX_ActorMedia_MediaId");

            migrationBuilder.AlterColumn<int>(
                name: "MediaId",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMedia_Media_MediaId",
                table: "ActorMedia",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Media_MediaId",
                table: "Ratings",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Media_MediaId",
                table: "Screenings",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMedia_Media_MediaId",
                table: "ActorMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Media_MediaId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Media_MediaId",
                table: "Screenings");

            migrationBuilder.RenameColumn(
                name: "MediaTitle",
                table: "TopSoldMovies",
                newName: "MovieTitle");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "TopSoldMovies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MediaTitle",
                table: "TopScreenedMovies",
                newName: "MovieTitle");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "TopScreenedMovies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MediaTitle",
                table: "TopRatedMovies",
                newName: "MovieTitle");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "TopRatedMovies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Tickets",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Ratings",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MediaId",
                table: "Ratings",
                newName: "IX_Ratings_MovieId");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "ActorMedia",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMedia_MediaId",
                table: "ActorMedia",
                newName: "IX_ActorMedia_MoviesId");

            migrationBuilder.AlterColumn<int>(
                name: "MediaId",
                table: "Screenings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMedia_Media_MoviesId",
                table: "ActorMedia",
                column: "MoviesId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Media_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Media_MediaId",
                table: "Screenings",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
