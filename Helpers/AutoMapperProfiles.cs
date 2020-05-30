using System.Linq;
using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){

            CreateMap <User, UserForListDto>()
            .ForMember(dest => dest.Url, opt => opt.MapFrom(scr => scr.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom (src => src.DateOfBirth.CalculateAge()));

            CreateMap <User, UserForDetailsDto>()
            .ForMember(dest => dest.Url, opt => opt.MapFrom(scr => scr.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom (src => src.DateOfBirth.CalculateAge()));

            CreateMap <Photo, PhotosForDetailDto>();

            CreateMap <UserToUpdateDto, User>(); 

            CreateMap <Photo, PhotoForReturnDto>().ReverseMap();

            CreateMap <Photo, PhotoForCreationDto>();

        }
        
    }
}