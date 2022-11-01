using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

StreamerDbContext dbContext = new();

await MultipleEntitiesQuery();
//await AddNewStreamerWithVideoId();
//await TrackingAndNotTracking();
//await AddNewRecords(dbContext);
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
//await QueryLinq();



Console.WriteLine($"Press any key to close the program.");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActors = await dbContext.Videos.Include(x => x.Actors)
    //    .FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actors!.Select(q=>q.Name).ToListAsync();

    var videoWithDirector = await dbContext.Videos
        .Where(q=>q.Director != null)
        .Include(q=>q.Director)
        .Select( q=>
            new
            {
                Director_FullName = $"{q.Director.Name} {q.Director.Nickname}",
                Movie = q.Nome
            }
        ).ToListAsync();

    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_FullName}");
    }

}
async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Name = "Lorenzo",
        Nickname = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Name = "Brad",
        Nickname = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1,
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nome = "Batman Forever",
        StreamerId = 4,
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Name = "Pantaya"
    };

    var hungerGames = new Video
    {
        Nome = "Hunger Games",
        Streamer = pantaya,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}
async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext.Streamers
        .FirstOrDefaultAsync(x => x.Id == 1);

    var streamerWithNoTracking = await dbContext.Streamers
        .AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Name = "Netflix Super";
    streamerWithNoTracking.Name = "Amazon Plus";

    await dbContext.SaveChangesAsync();
}
async Task QueryLinq()
{
    Console.WriteLine($"Input the streaming");
    var streamerName = Console.ReadLine();
    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Name, $"%{streamerName}%")
                           select i).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}
async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;
    var firstAsync = await streamer.Where(y => y.Name.Contains("a")).FirstAsync();
    var firstOrDefaultAsync = await streamer.Where(y => y.Name.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaultAsync_v2 = await streamer.FirstOrDefaultAsync(y => y.Name.Contains("a"));

    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();
    var resultado = await streamer.FindAsync(1);
}
async Task QueryFilter()
{
    Console.WriteLine($"Input name of a Streamer Company.");
    var streamingName = Console.ReadLine();

    var streamers = await dbContext!.Streamers!.Where(x => x.Name.Equals(streamingName)).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }

    //var streamerPartialResults = await dbContext!.
    //    Streamers!.Where(x=>x.Name.Contains(streamingName)).ToListAsync();

    var streamerPartialResults = await dbContext!.
        Streamers!.Where(x => EF.Functions.Like(x.Name, $"%{streamingName}%")).ToListAsync();

    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }

}
void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}
async Task AddNewRecords(StreamerDbContext dbContext)
{
    Streamer streamer = new()
    {
        Name = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Nome="La Cenicienta",
        StreamerId=streamer.Id,
    },
    new Video
    {
        Nome="1001 dalmatas",
        StreamerId=streamer.Id,
    },
    new Video
    {
        Nome="El Jorobado de Notredame",
        StreamerId=streamer.Id,
    },
    new Video
    {
        Nome="Star Wars",
        StreamerId=streamer.Id,
    },
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}