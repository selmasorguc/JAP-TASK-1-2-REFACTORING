using MovieApp.Core.Entities.StoredProceduresEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IReportRepository
    {
        Task<List<Top10Item>> GetTop10MoviesAsync();
        Task<List<TopScreened>> GetTop10ScreenedAsync(DateTime startDate, DateTime endDate);
        Task<List<TopSold>> GetTopSoldAsync();
    }
}
