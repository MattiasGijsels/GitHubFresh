using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Labo.API.Wasm.Client.Pages
{
    public class EditBookBase : ComponentBase
    {
        [Inject]
        public IManagerService BookService { get; set; } = default!;

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        [Parameter]
        public string BookId { get; set; } = string.Empty;

        protected Books? Book { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await BookService.GetByIdAsync(BookId);
        }

        protected async Task SaveBook()
        {
            if (Book != null)
            {
                await BookService.UpdateAsync(Book);
                Navigation.NavigateTo("/Library");
            }
        }

        protected void Cancel()
        {
            Navigation.NavigateTo("/Library");
        }
    }
}
