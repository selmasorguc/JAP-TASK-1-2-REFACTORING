using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        public MediaService(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<List<MediaDto>> GetPagedAsync(MediaParams movieParams)
        {
            return _mapper.Map<List<MediaDto>>(
            await _mediaRepository.GetPagedAsync(movieParams));
        }

        public async Task<List<MediaDto>> SearchMediaAsync(string query)
        {
            return _mapper.Map<List<MediaDto>>(await _mediaRepository.SearchMediaAsync(query));
        }
    }
}