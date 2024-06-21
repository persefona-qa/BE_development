using AutoMapper;
using NDubko.Api.Requests;
using NDubko.Api.ViewModels;
using NDubko.Application.Commands.Books;
using NDubko.Application.Queries.Books;
using NDubko.Domain;

namespace NDubko.Api.Mapping;

/// <summary>
/// Task for #3 Automapper
/// </summary>
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookRequest, CreateBookCommand>();
        CreateMap<UpdateBookRequest, UpdateBookCommand>();

        CreateMap<GetBookByFilterRequest, GetBookByFilterQuery>();

        CreateMap<Book, BookViewModel>(MemberList.Destination);
        CreateMap<Book, BookDetailsViewModel>(MemberList.Destination);
    }
}