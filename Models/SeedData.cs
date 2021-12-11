using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {

        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                
                context.Genre.Add(new Genre("Romantic Comedy"));
                context.Genre.Add(new Genre("Spiritual"));
                context.Genre.Add(new Genre("Inspiring"));
                context.Genre.Add(new Genre("Thriller"));
                await context.SaveChangesAsync();

                var GenreList = from g in context.Genre
                               select g;



                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = GenreList.FirstOrDefault(g => g.Name == "Romantic Comedy"),
                        Price = 7.99M,
                        Rating = "PG",
                        url = "https://i.ebayimg.com/images/g/NhAAAOSwjVVV3gnD/s-l640.jpg"
                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2002-4-12"),
                        Genre = GenreList.FirstOrDefault(g => g.Name == "Spiritual"),
                        Price = 8.99M,
                        Rating = "PG",
                        url = "https://th.bing.com/th/id/OIP.D0U_JRjESZ10B3RHSIJuwQHaKT?pid=ImgDet&rs=1"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = GenreList.FirstOrDefault(g => g.Name == "Inspiring"),
                        Price = 9.99M,
                        Rating = "PG",
                        url = "https://www.gannett-cdn.com/-mm-/6546462979fe365b87e8d22c78a4ae9bb3fa0388/c=0-667-1236-1365/local/-/media/Phoenix/None/2014/10/09/635484653440700002-meet-the-mormons-poster.jpg?width=1236&height=698&fit=crop&format=pjpg&auto=webp"
                    },

                    new Movie
                    {
                        Title = "Saratov Approach",
                        ReleaseDate = DateTime.Parse("2013-10-9"),
                        Genre = GenreList.FirstOrDefault(g => g.Name == "Thriller"),
                        Price = 3.99M,
                        Rating = "PG",
                        url = "https://th.bing.com/th/id/OIP.uxvFryGiYMnejOfcL2sQJgAAAA?pid=ImgDet&rs=1"
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}