using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IQueueRepository
    {
        Task<List<QueueRecord>> GetAllAsync();
        Task CreateAsync(QueueRecord record);
    }
}
