using AutoMapper;
using Bipogative.BookStore.Books;

namespace Bipogative.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
             CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
