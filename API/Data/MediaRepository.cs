namespace API.Data
{
    using API.DTOs;
    using API.Entity;
    using API.Helpers;
    using API.Interfaces;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class MediaRepository : IMediaRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private IQueryable<Media> baseQuery;

        public MediaRepository(DataContext context)
        {
            _context = context;
            baseQuery = _context.Media.Include(m => m.Cast)
                                       .Include(m => m.Ratings)
                                       .OrderByDescending(x => x.Ratings
                                       .Select(x => x.Value).Average());
        }

        //Get 1 movie/tvshow from DB by id
        public async Task<Media> GetMediaAync(int id)
        {
            return await _context.Media.Include(m => m.Ratings)
                                       .Include(m => m.Cast)
                                       .Include(x => x.Screenings)
                                       .FirstOrDefaultAsync(m => m.Id == id);
        }

        //Get movies or tv shows paginated
        //Media params take page num, size and media type you wanna get
        public async Task<List<Media>> GetPagedAsync(MediaParams mediaParams)
        {

            var movies = await baseQuery.Concat(
                baseQuery.Where(m => m.MediaType == mediaParams.MediaType)
                         .Skip((mediaParams.PageNumber - 1) * mediaParams.PageSize)
                         .Take(mediaParams.PageSize)).ToListAsync();
            return movies;
        }

        //Save changes in DB
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //Search media by query string (created for search bar filtering)
        public async Task<List<Media>> SearchMediaAsync(string query)
        {
            //Starting with the basic media db query - searching by title and description
            var mediaDbQuery = baseQuery.Concat(
                                        baseQuery.Where(m => m.Title.ToLower()
                                                 .Contains(query.ToLower()) || m.Description.ToLower()
                                                 .Contains(query.ToLower())));

            //Keywords check
            int numericValue;
            bool isNumber = int.TryParse(Regex.Match(query, @"\d+").Value, out numericValue);

            if (query.ToLower().Contains("star") && isNumber && numericValue.ToString().Length == 1)
            {
                if (query.ToLower().Contains("at least"))
                {
                    mediaDbQuery.Concat(mediaDbQuery
                                .Where(m => m.Ratings.Average(x => x.Value) >= numericValue));
                }
                else
                {
                    mediaDbQuery.Concat(mediaDbQuery
                    .Where(m => m.Ratings.Average(x => x.Value) == numericValue)
                    .OrderByDescending(x => x.Ratings.Select(x => x.Value).Average()));
                }
            }

            if (query.ToLower().Contains("year") && isNumber && numericValue.ToString().Length == 1)
            {
                if (query.ToLower().Contains("older"))
                    mediaDbQuery.Concat(mediaDbQuery
                                .Where(m => DateTime.Now.Year - m.ReleaseDate.Year >= numericValue));

                else
                    mediaDbQuery.Concat(mediaDbQuery
                                .Where(m => DateTime.Now.Year - m.ReleaseDate.Year <= numericValue));

            }

            if (isNumber && numericValue.ToString().Length == 4)
            {
                if (query.ToLower().Contains("after"))
                    mediaDbQuery.Concat(mediaDbQuery.Where(m => m.ReleaseDate.Year > numericValue));

                else
                    mediaDbQuery.Concat(mediaDbQuery.Where(m => m.ReleaseDate.Year == numericValue));

            }
            return await mediaDbQuery.ToListAsync();
        }
    }
}
