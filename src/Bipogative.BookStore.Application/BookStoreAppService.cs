using System;
using System.Collections.Generic;
using System.Text;
using Bipogative.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace Bipogative.BookStore
{
    /* Inherit your application services from this class.
     */
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}
