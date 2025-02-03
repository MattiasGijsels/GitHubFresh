using Labo.API.Contracts.Models;
using Labo.API.Wasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.API.Wasm.Client.Pages
{
    public partial class Library
    {
        [Inject]
        public IManagerService BookService { get; set; } = default!;

        private IEnumerable<Books>? Books { get; set; } = null;
        private List<string> Genre { get; set; } = new();
        private string SearchWriterQuery { get; set; } = "";
        private string SearchBookQuery { get; set; } = "";
        private string SelectedGenre { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadGenres();
            await LoadBooks();
        }

        private async Task LoadGenres()
        {
            var allBooks = await BookService.GetAllAsync();
            Genre = allBooks.Select(b => b.Genre.GenreName).Distinct().ToList();
        }

        private async Task LoadBooks()
        {
            Books = await BookService.FilterAsync(
                null,
                string.IsNullOrWhiteSpace(SearchBookQuery) ? null : SearchBookQuery,
                string.IsNullOrWhiteSpace(SelectedGenre) ? null : SelectedGenre,
                string.IsNullOrWhiteSpace(SearchWriterQuery) ? null : SearchWriterQuery,
                string.IsNullOrWhiteSpace(SearchWriterQuery) ? null : SearchWriterQuery
            );

            StateHasChanged();
        }

        private async Task OnSearchChanged(ChangeEventArgs e)
        {
            await LoadBooks(); // Refresh books based on search inputs
        }
    }
}
