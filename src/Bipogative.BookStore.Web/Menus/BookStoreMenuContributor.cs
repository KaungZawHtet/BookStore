using System.Threading.Tasks;
using Bipogative.BookStore.Localization;
using Bipogative.BookStore.MultiTenancy;
using Bipogative.BookStore.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Bipogative.BookStore.Web.Menus
{
    public class BookStoreMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<BookStoreResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    BookStoreMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );



            //CHECK the PERMISSION
            if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
            {
                context.Menu.Items.Insert(
                        1,
                         new ApplicationMenuItem(
                    BookStoreMenus.Books, // "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/Books",
                        icon: "fas fa-book"
                )
                    );
            }

                //CHECK the PERMISSION
            if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                context.Menu.Items.Insert(
                        1,
                         new ApplicationMenuItem(
                    BookStoreMenus.Authors, // "Authors
                    l["Menu:Authors"],
                    url: "/Authors",
                        icon: "fas fa-user"
                )
                    );
            }

            

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        }
    }
}
