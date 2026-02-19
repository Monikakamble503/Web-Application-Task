using MyWebApp.Models;

public class QueueService
{
    private readonly QueueRepository _repository;

    public QueueService(QueueRepository repository)
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