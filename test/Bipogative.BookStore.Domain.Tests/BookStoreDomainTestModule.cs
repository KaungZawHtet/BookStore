using Bipogative.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bipogative.BookStore
{
    [DependsOn(
        typeof(BookStoreEntityFrameworkCoreTestModule)
        )]
    public class BookStoreDomainTestModule : AbpModule
    {

    }
}