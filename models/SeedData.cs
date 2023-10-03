using Microsoft.EntityFrameworkCore;
using MyScriptureJourney.Data;
using MyScriptureJourney.models;

namespace MyScriptureJourney.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJourneyContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJourneyContext>>()))
        {
            if (context == null || context.Scripture == null)
            {
                throw new ArgumentNullException("Null MyScriptureJourneyContext");
            }

            if (context.Scripture.Any())
            {
                return;
            }

            context.Scripture.AddRange(
                new Scripture
                {
                    Book = "1 Nephi",
                    ReleaseDate = DateTime.Parse("2023-10-02"),
                    Chapter = 2,
                    Verses = 7,
                    Notes = "Important scripture 1."
                },

                new Scripture
                {
                    Book = "Mosiah",
                    ReleaseDate = DateTime.Parse("2023-10-02"),
                    Chapter = 3,
                    Verses = 2,
                    Notes = "Important scripture 2."
                }
            );
            context.SaveChanges();
        }
    }
}