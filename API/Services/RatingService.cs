using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entity;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
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

        public async Task<ServiceResponse<double>> RateMovieAsync(RatingDto rating)
        {
            var serviceResponse = new ServiceResponse<double>();
            try
            {
                var media = await _mediaRepository.GetSingleMediaAync(rating.MediaId);
                if (media == null) throw new ArgumentException("Media does not exist");

                await _ratingRepository.AddRating(_mapper.Map<Rating>(rating));
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