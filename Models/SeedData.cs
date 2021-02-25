using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//seed data for the database
namespace assignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            //if there is already data inside of the database then just pull from that
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if there is no context/data in the database then add this data to the database
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new BookModel
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorMiddleName = "",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Classic",
                        Classification = "Fiction",
                        Price = 9.95,
                        Pages = 1488
                    },

                    new BookModel
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Biography",
                        Classification = "Non-Fiction",
                        Price = 14.58,
                        Pages = 944
                    },

                    new BookModel
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorMiddleName = "",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Biography",
                        Classification = "Non-Fiction",
                        Price = 21.54,
                        Pages = 832
                    },

                    new BookModel
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category = "Biography",
                        Classification = "Non-Fiction",
                        Price = 11.61,
                        Pages = 864
                    },

                    new BookModel
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorMiddleName = "",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Historical",
                        Classification = "Non-Fiction",
                        Price = 13.33,
                        Pages = 528
                    },

                    new BookModel
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorMiddleName = "",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Historical Fiction",
                        Classification = "Fiction",
                        Price = 15.95,
                        Pages = 288
                    },

                    new BookModel
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorMiddleName = "",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Self-Help",
                        Classification = "Non-Fiction",
                        Price = 14.99,
                        Pages = 304
                    },

                    new BookModel
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorMiddleName = "",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Self-Help",
                        Classification = "Non-Fiction",
                        Price = 21.66,
                        Pages = 240
                    },

                    new BookModel
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorMiddleName = "",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Business",
                        Classification = "Non-Fiction",
                        Price = 29.16,
                        Pages = 400
                    },

                    new BookModel
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorMiddleName = "",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Thrillers",
                        Classification = "Fiction",
                        Price = 15.03,
                        Pages = 642
                    },

                    //Drew's three additional books
                    new BookModel
                    {
                        Title = "How to Win Friends and Influence People",
                        AuthorFirstName = "Dale",
                        AuthorMiddleName = "",
                        AuthorLastName = "Carnegie",
                        Publisher = "Pocket Books",
                        ISBN = "978-0671027032",
                        Category = "Business",
                        Classification = "Non-Fiction",
                        Price = 11.85,
                        Pages = 288
                    },

                    new BookModel
                    {
                        Title = "Shoe Dog",
                        AuthorFirstName = "Phil",
                        AuthorMiddleName = "",
                        AuthorLastName = "Knight",
                        Publisher = "Scribner",
                        ISBN = "978-1501135910",
                        Category = "Business",
                        Classification = "Non-Fiction",
                        Price = 29.00,
                        Pages = 383
                    },

                    new BookModel
                    {
                        Title = "Atomic Habits",
                        AuthorFirstName = "James",
                        AuthorMiddleName = "",
                        AuthorLastName = "Clear",
                        Publisher = "Avery",
                        ISBN = "978-0735211292",
                        Category = "Self-Help",
                        Classification = "Non-Fiction",
                        Price = 18.06,
                        Pages = 320
                    }
                );

                //save these objects to the database
                context.SaveChanges();
            }
        }
    }
}