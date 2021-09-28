using MovieApp.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IMediaService
    {
        Task<List<MediaDto>> GetMediaAsync(MediaParams movieParams);
    }
}