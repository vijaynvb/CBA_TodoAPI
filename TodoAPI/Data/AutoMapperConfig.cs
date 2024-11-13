using AutoMapper;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserDTO,User>().ReverseMap();

            CreateMap<Todo,TodoDTO>().ReverseMap().ForMember(dest => dest.TodoUserId, act => act.MapFrom(src => src.UserId));

            CreateMap<TodoResposeDTO,Todo>().ReverseMap().ForMember(dest => dest.UserId, act => act.MapFrom(src => src.TodoUserId)); ;
        }
    }
}
