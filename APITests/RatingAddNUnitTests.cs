﻿namespace APITests
{
    using API.Data;
    using API.DTOs;
    using API.Entity;
    using API.Helpers;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestFixture]
    public class RatingAddNUnitTests
    {
        private Rating rating1;

        private Rating rating2;

        private Media movie1;

        private IMapper _mapper;

        private DataContext context;

        [SetUp]
        public void SetUp()
        {
            movie1 = new Media
            {
                Id = 1,
                MediaType = MediaType.Movie,
                Title = "SING",
                ReleaseDate = new DateTime(2021, 01, 01),
                CoverUrl = "https://media-cache.cinematerial.com/p/500x/fntb61gp/sing-movie-cover.jpg?v=1486583799",
                Description = "Cartoon about singing animals",
                Ratings = new List<Rating>()
            };

            rating1 = new Rating
            {
                Id = 1,
                MediaId = 1,
                Media = movie1,
                Value = 5
            };

            rating2 = new Rating
            {
                Id = 2,
                MediaId = 1,
                Media = movie1,
                Value = 4
            };

            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mappingConfig.CreateMapper();

            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "temp-movieapp").Options;
            context = new DataContext(options);
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task RatingAddChecker_Rating_One_CheckValuesFromDB()
        {
            //arrange
            context.Database.EnsureDeleted();
            context.Media.Add(movie1);
            context.Ratings.Add(rating1);
            context.SaveChanges();

            //act
            var movieRepository = new MovieRepository(context, _mapper);
            RatingDto r1 = new RatingDto
            {
                Value = rating1.Value,
                MediaId = movie1.Id
            };
            await movieRepository.RateMovieAsync(r1);

            //assert
            var movieFromDB = context.Media.FirstOrDefault(x => x.Title == "SING");

            Assert.That(movieFromDB.Ratings.Count() == 2);
        }

        [Test]
        public async Task RatingAddChecker_NewRatingInput_CheckNewAvgRating()
        {
            //arrange
            context.Database.EnsureDeleted();
            context.Media.Add(movie1);
            context.SaveChanges();

            //act
            RatingDto r2 = new RatingDto
            {
                Value = rating1.Value,
                MediaId = movie1.Id
            };
            var movieRepository = new MovieRepository(context, _mapper);
            await movieRepository.RateMovieAsync(r2);

            //assert
            var movieFromDB = context.Media.FirstOrDefault(x => x.Title == "SING");
            var ratingFromDB = context.Ratings.FirstOrDefault(x => x.MediaId == movieFromDB.Id && x.Value == 5);
            Assert.Multiple(() =>
            {
                Assert.That(rating1.Value, Is.EqualTo(ratingFromDB.Value));
                Assert.That(rating1.MediaId, Is.EqualTo(ratingFromDB.MediaId));
            });
        }

        // [Test]
        // public async Task RatingAddChecker_Rating_AddTwo_RatingsDBWithTwoEntries()
        // {
        //     //arrange
        //     context.Database.EnsureDeleted();
        //     context.Media.Add(movie1);
        //     context.SaveChanges();

        //     //act
        //     var movieRepository = new MovieRepository(context, _mapper);
        //     await movieRepository.RateMovieAsync(rating2);
        //     await movieRepository.RateMovieAsync(rating1);

        //     //assert
        //     Assert.That(context.Ratings.Count() == 2);
        // }
    }
}
