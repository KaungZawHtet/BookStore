using Volo.Abp.Application.Dtos;

namespace Bipogative.BookStore.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}