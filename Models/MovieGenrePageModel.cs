using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Cozma_Marian.Data;

namespace Proiect_Cozma_Marian.Models
{
    public class MovieGenrePageModel
    : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;
        public void PopulateAssignedGenreData(Proiect_Cozma_MarianContext context,
        Movie movie)
        {
            var allGenres = context.Genre;
            var movieGenre = new HashSet<int>(
            movie.MovieGenres.Select(c => c.GenreID)); //
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var gen in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = gen.ID,
                    Name = gen.GenreName,
                    Assigned = movieGenre.Contains(gen.ID)
                });
            }
        }
        public void UpdateMovieGenres(Proiect_Cozma_MarianContext context,
        string[] selectedGenres, Movie movieToUpdate)
        {
            if (selectedGenres == null)
            {
                movieToUpdate.MovieGenres = new List<MovieGenre>();
                return;
            }
            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var movieGenres = new HashSet<int>
            (movieToUpdate.MovieGenres.Select(g => g.Genre.ID));
            foreach (var gen in context.Genre)
            {
                if (selectedGenresHS.Contains(gen.ID.ToString()))
                {
                    if (!movieGenres.Contains(gen.ID))
                    {
                        movieToUpdate.MovieGenres.Add(
                        new MovieGenre
                        {
                            MovieID = movieToUpdate.ID,
                            GenreID = gen.ID
                        });
                    }
                }
                else
                {
                    if (movieGenres.Contains(gen.ID))
                    {
                        MovieGenre courseToRemove
                        = movieToUpdate
                        .MovieGenres
                        .SingleOrDefault(i => i.GenreID == gen.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}