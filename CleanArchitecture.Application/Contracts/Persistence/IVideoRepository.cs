using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository:IAsyncEnumerator<Video>
    {
        Task<Video> GetVideoByName(string name);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
