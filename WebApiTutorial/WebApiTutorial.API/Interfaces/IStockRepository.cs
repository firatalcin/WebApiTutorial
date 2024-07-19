using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}
