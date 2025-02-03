using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labo.API.Wasm.Client.Pages
{
    public partial class Library
    {
        [Inject]
        public IManagerService BookService { get; set; } = default!;

        private IEnumerable<Books>? Books { get; set; } = null;
        private string SearchQuery { get; set; } = ""; // Search string

        protected override async Task OnInitializedAsync()
        {
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery)||SearchQuery.Length<3)
            {
                Books = await BookService.GetAllAsync();
            }
            else
            {
                Books = await BookService.FilterAsync(null, SearchQuery, SearchQuery, SearchQuery, SearchQuery);
            }
            StateHasChanged();
        }

        private async Task OnSearchChanged(ChangeEventArgs e)
        {
            SearchQuery = e.Value?.ToString() ?? "";
            await LoadBooks(); // Refresh books based on search
        }
    }
}
