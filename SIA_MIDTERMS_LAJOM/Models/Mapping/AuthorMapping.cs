using AutoMapper;
using SIA_MIDTERMS_LAJOM.Models.DTO.AuthorDTO;
using SIA_MIDTERMS_LAJOM.Models.DTO.PublisherDTO;
using SIA_MIDTERMS_LAJOM.Models.DTO.TitleDTO;

namespace SIA_MIDTERMS_LAJOM.Models.Mapping
{
    public class AuthorMapping : Profile
    {
        public AuthorMapping() 
        {
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<Author, AuthorCreateDTO>();
            CreateMap<Author, AuthorUpdateDTO>();
            CreateMap<AuthorReadDTO, Author>();
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<AuthorUpdateDTO, Author>();

            CreateMap<Title, TitleReadDTO>();
            CreateMap<Title, TitleCreateDTO>();
            CreateMap<Title, TitleUpdateDTO>();
            CreateMap<TitleReadDTO, Title>();
            CreateMap<TitleCreateDTO, Title>();
            CreateMap<TitleUpdateDTO, Title>();

            CreateMap<Publisher, PublisherReadDTO>();
            CreateMap<Publisher, PublisherCreateDTO>();
            CreateMap<Publisher, PublisherUpdateDTO>();
            CreateMap<PublisherReadDTO, Publisher>();
            CreateMap<PublisherCreateDTO, Publisher>();
            CreateMap<PublisherUpdateDTO, Publisher>();
        }
    }
}
