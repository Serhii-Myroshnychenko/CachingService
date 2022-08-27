using CachingService.Models;

namespace CachingService.Data.Contracts
{
    public interface IPlatformRepository
    {
        void CreatePlatform(Platform platfrom);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform> GetAllPlatforms();
    }
}
