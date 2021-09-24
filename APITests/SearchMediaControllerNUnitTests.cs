namespace APITests
{
    using API.Controllers;
    using API.DTOs;
    using API.Entity;
    using API.Interfaces;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestFixture]
    public class SearchMediaControllerNUnitTests
    {
        private Mock<IMovieRepository> _movieRepo;

        private MediaController _moviesController;

        private List<MediaDto> MediaDtos;

        [SetUp]
        public void SetUp()
        {
            _movieRepo = new Mock<IMovieRepository>();
            _moviesController = new MediaController(_movieRepo.Object);
            MediaDtos = new List<MediaDto>();

            MediaDto m1 = new MediaDto
            {
                Id = 1,
                Title = "Matrix",
                Description = "Movie about computers SCIFI",
                ReleaseDate = new DateTime(2021, 01, 01),
                CoverUrl = "www.img.com",
                MediaType = MediaType.Movie,
                Ratings = new List<RatingDto>
                {
                    new RatingDto{ Value = 5, MediaId = 1},
                    new RatingDto{ Value = 5, MediaId = 1}
                }

            };
            MediaDto m2 = new MediaDto
            {
                Id = 2,
                Title = "SING",
                Description = "Cartoon",
                ReleaseDate = new DateTime(2021, 01, 01),
                CoverUrl = "www.img.com",
               MediaType = MediaType.Movie,
                Ratings = new List<RatingDto>
                {
                    new RatingDto{ Value = 5, MediaId = 2},
                    new RatingDto{ Value = 5, MediaId = 2}
                }

            };

            MediaDtos.Add(m1);
            MediaDtos.Add(m2);
        }

        [Test]
        public async Task SearchMovieAsyncCheck_StringQueryInput_VerifyCalledMethod()
        {
            await _moviesController.SearchMediaAsync("string");
            _movieRepo.Verify(x => x.SearchMediaAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
