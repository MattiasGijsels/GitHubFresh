using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;

using Microsoft.AspNetCore.Components;

namespace Labo.API.Wasm.Client.Pages
{
    public partial class Library
    {
        [Inject]
        public IManagerService BookService { get; set; } = default!;
        IEnumerable<Books>? Books { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Books = await BookService.GetAllAsync();
            StateHasChanged();
        }

    }
}
