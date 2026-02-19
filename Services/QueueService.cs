using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class QueueService
    {
        private readonly IQueueRepository _repository;

        public QueueService(IQueueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<QueueRecord>> GetRecordsForDisplayAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddRecordAsync(QueueRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.QueueName))
                throw new ArgumentException("Queue Name cannot be empty");

            await _repository.CreateAsync(record);
        }
    }
}