using AutoMapper;
using NDubko.Api.Requests;
using NDubko.Api.ViewModels;
using NDubko.Application.Commands.Authors;
using NDubko.Application.Queries.Authors;
using NDubko.Domain;

namespace NDubko.Api.Mapping;

/// <summary>
/// Task for #3 Automapper
/// </summary>
public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorRequest, CreateAuthorCommand>();
        CreateMap<UpdateAuthorRequest, UpdateAuthorCommand>();

        CreateMap<GetAuthorByFilterRequest, GetAuthorByFilterQuery>();

        CreateMap<Author, AuthorViewModel>(MemberList.Destination);
        CreateMap<Author, AuthorDetailsViewModel>(MemberList.Destination);
    }
}