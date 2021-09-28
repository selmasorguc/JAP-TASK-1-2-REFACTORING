using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities.StoredProceduresEntities;
using MovieApp.Core.Interfaces;
using MovieApp.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Top10Item>> GetTop10MoviesAsync()
        {
            return await _context.TopRatedMovies
                .FromSqlRaw("EXEC [dbo].[spGet_Top10_RatedMovies];").ToListAsync();
        }

        public async Task<List<TopScreened>> GetTop10ScreenedAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TopScreenedMovies
               .FromSqlRaw("EXEC [dbo].[spGet_Top10_ScreenedMovies] {0}, {1};", startDate, endDate).ToListAsync();
        }

        public async Task<List<TopSold>> GetTopSoldAsync()
        {
            return await _context.TopSoldMovies
                .FromSqlRaw("EXEC [dbo].[spGet_Top_Sold_Movies];").ToListAsync();
        }
    }
}
