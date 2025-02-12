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
        private string SearchQuery { get; set; } = "";
        private string? SelectedGenre { get; set; } = null;
        bool _genreListIsOpen = false;
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
            Books = await BookService.FindAsync(SearchQuery);

            StateHasChanged();
        }

        private async Task OnSearchChanged(ChangeEventArgs e)
        {
                SearchQuery = e.Value?.ToString() ?? "";


            await LoadBooks();
        }
        private async Task OnGenreChanged(ChangeEventArgs e)
        {
            SelectedGenre = e.Value?.ToString() ?? "";
            await LoadBooks();
        }
        void OnToggleOpen() => _genreListIsOpen = !_genreListIsOpen;
        private void OnGenreClicked() {

            var genre = SelectedGenre;
        }
        private async Task OnGenreSelected(string? genre)
        {
            //SelectedGenre = e.Value?.ToString() ?? "";
            SelectedGenre=genre;
            _genreListIsOpen=false;
            await LoadBooks();
        }

    }
}
