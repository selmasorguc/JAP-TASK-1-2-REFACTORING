namespace MovieApp.Core.Services
{
    using AutoMapper;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;

        private readonly IMediaRepository _mediaRepository;

        private readonly IRatingRepository _ratingRepository;

        public RatingService(IMapper mapper, IMediaRepository mediaRepository, IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets average rating of a media by id
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns>Average rating as double</returns>
        public async Task<ServiceResponse<double>> GetAverageRatingAsync(int mediaId)
        {
            var serviceResponse = new ServiceResponse<double>();
            try
            {
                var media = await _mediaRepository.GetSingleMediaAync(mediaId);
                if (media == null) throw new ArgumentException("Media does not exist");

                //Check if movie has any ratings
                if (media.Ratings.Count() == 0)
                {
                    serviceResponse.Data = 0;
                    serviceResponse.Message = "Movie has no ratings yet";
                }
                else
                {
                    serviceResponse.Data = media.Ratings.Select(x => x.Value).Average();
                    serviceResponse.Message = "Average rating of movie found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Rates media  - adding a new rating to the DB
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>New average rating of that media</returns>
        public async Task<ServiceResponse<double>> RateMovieAsync(RatingDto rating)
        {
            var serviceResponse = new ServiceResponse<double>();
            try
            {
                //Find the media by id and check if it exists
                var media = await _mediaRepository.GetSingleMediaAync(rating.MediaId);
                if (media == null) throw new ArgumentException("Media does not exist");

                //Add new rating to the DB and update the rated media wih this new rating
                await _ratingRepository.AddRating(_mapper.Map<Rating>(rating));
                await _mediaRepository.UpdateAfterRating(rating.MediaId);
                serviceResponse.Data = media.Ratings.Select(x => x.Value).Average();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
