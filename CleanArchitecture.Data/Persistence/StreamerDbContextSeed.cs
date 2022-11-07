using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContext> logger)
        {
            if (!context.Streamers.Any())
            {
                context.Streamers.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Inserted news records in db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy= "zarbg", Name="Maxi HBP", Url="http://www.hbp.com" },
                new Streamer {CreatedBy= "zarbg", Name="Amazon VIP", Url="http://www.amazonvip.com" },
            };
        }
    }
}
