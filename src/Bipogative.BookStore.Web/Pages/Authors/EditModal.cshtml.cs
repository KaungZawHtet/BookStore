using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bipogative.BookStore.Authors;
using Bipogative.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Bipogative.BookStore.Web.Pages.Authors
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty]
        public EditAuthorViewModel Author { get; set; }

        private readonly IAuthorAppService _authorAppService;

        public EditModalModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var authorDto = await _authorAppService.GetAsync(id);
            Author = ObjectMapper.Map<AuthorDto, EditAuthorViewModel>(authorDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorAppService.UpdateAsync(
                Author.Id,
                ObjectMapper.Map<EditAuthorViewModel, UpdateAuthorDto>(Author)
            );

            return NoContent();
        }

        public class EditAuthorViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [StringLength(AuthorConsts.MaxNameLength)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [TextArea]
            public string ShortBio { get; set; }
        }
    }
}
