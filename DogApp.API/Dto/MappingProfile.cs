using AutoMapper;
using DogApp.Data.EntityModels;

namespace DogApp.API.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Track, SimpleTrackDTO>(); 
        }
    }
}
