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
        private readonly DataContext _context;
        public MediaRepository(DataContext context)
        {
            _context = context;
        }

          
        public async Task<Media> GetSingleMediaAync(int id)
        {
            return await _context.Media.Include(m => m.Cast)
                                       .Include(m => m.Ratings)
                                       .Include(x => x.Screenings)
                                       .OrderByDescending(x => x.Ratings
                                       .Select(x => x.Value).Average()).Include(m => m.Ratings)
                                       .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Media>> GetMediaAsync(MediaParams mediaParams)
        {
            IQueryable<Media> query = _context.Media.Include(m => m.Cast)
                                             .Include(m => m.Ratings)
                                             .Include(x => x.Screenings).AsQueryable();

            if (mediaParams.SearchQuery != null) query = SearchFilter(query, mediaParams.SearchQuery);

            if (mediaParams.MediaType != null) query = query.Where(m => m.MediaType == mediaParams.MediaType);

            List<Media> movies = await query.OrderByDescending(x => x.Ratings.Select(x => x.Value).Average())
                                             .Skip((mediaParams.PageNumber - 1) * mediaParams.PageSize)
                                             .Take(mediaParams.PageSize).ToListAsync();
            return movies;
        }

        //Private function that expands the basic query with a search filter applied
        private IQueryable<Media> SearchFilter(IQueryable<Media> query, string searchTerm)
        {
            //First we search by title and description
            query = query.Where(m => m.Title.ToLower()
                                             .Contains(searchTerm.ToLower()) || m.Description.ToLower()
                                             .Contains(searchTerm.ToLower()));

            //Keywords check 
            //Checking if the user looked for movies based on rating or release year
            int numericValue;
            bool isNumber = int.TryParse(Regex.Match(searchTerm, @"\d+").Value, out numericValue);

            if (searchTerm.ToLower().Contains("star")
            && isNumber && numericValue.ToString().Length == 1)
            {
                //Da li ovdje treba kad ukuca 5 star da da samo 5 star, i kad ukuca 4 star samo da da 4 star a ne i 5 star
                if (searchTerm.ToLower().Contains("at least"))
                    query = query.Where(m => m.Ratings.Average(x => x.Value) >= numericValue);

                else
                    query = query.Where(m => m.Ratings.Average(x => x.Value) == numericValue);

                // query = searchTerm.ToLower().Contains("at least") 
                //         ? query.Where(m => m.Ratings.Average(x => x.Value) >= numericValue)
                //         : query = query.Where(m => m.Ratings.Average(x => x.Value) == numericValue);
            }

            if (searchTerm.ToLower().Contains("year") && isNumber && numericValue.ToString().Length == 1)
            {
                if (searchTerm.ToLower().Contains("older"))
                    query = query.Where(m => DateTime.Now.Year - m.ReleaseDate.Year >= numericValue);

                else
                    query = query.Where(m => DateTime.Now.Year - m.ReleaseDate.Year <= numericValue);
            }

            if (isNumber && numericValue.ToString().Length == 4)
            {
                if (searchTerm.ToLower().Contains("after"))
                    query = query.Where(m => m.ReleaseDate.Year > numericValue);

                else
                    query = query.Where(m => m.ReleaseDate.Year == numericValue);

            }
            return query;
        }
    }
}
