using AutoMapper;
using Bipogative.BookStore.Authors;
using Bipogative.BookStore.Books;

namespace Bipogative.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

              CreateMap<Book, BookDto>();
              CreateMap<CreateUpdateBookDto, Book>(); // look weird
              CreateMap<Author, AuthorDto>();
              CreateMap<Author, AuthorLookupDto>();
        }
    }
}
