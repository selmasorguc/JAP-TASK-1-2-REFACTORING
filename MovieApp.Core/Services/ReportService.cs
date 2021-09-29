namespace MovieApp.Core.Services
{
    using MovieApp.Core.Entities;
    using MovieApp.Core.Entities.StoredProceduresEntities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Executes stored procedures
    /// Check the ReportRepository
    /// </summary>
    public class ReportService : IReportService
    {
        public readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ServiceResponse<List<Top10Item>>> GetTop10MoviesAsync()
        {
            var response = new ServiceResponse<List<Top10Item>>();
            try
            {
                response.Data = await _reportRepository.GetTop10MoviesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<TopScreened>>> GetTop10ScreenedAsync(DateTime startDate, DateTime endDate)
        {
            var response = new ServiceResponse<List<TopScreened>>();
            try
            {
                response.Data = await _reportRepository.GetTop10ScreenedAsync(startDate, endDate);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<TopSold>>> GetTopSoldAsync()
        {
            var response = new ServiceResponse<List<TopSold>>();
            try
            {
                response.Data = await _reportRepository.GetTopSoldAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
