using AutoMapper;
using Bipogative.BookStore.Authors;
using Bipogative.BookStore.Books;

namespace Bipogative.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();

            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,
                      CreateAuthorDto>();

            // ADD THESE NEW MAPPINGS
            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
                      UpdateAuthorDto>();


            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();




        }
    }
}
