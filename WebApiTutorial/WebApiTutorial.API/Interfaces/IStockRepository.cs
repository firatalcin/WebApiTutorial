using WebApiTutorial.API.Dtos.Stock;
using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(CreateStockRequestDto request);
        Task<Stock> UpdateAsync(int id,UpdateStockRequestDto request);
        Task<Stock?> DeleteAsync(int id);

    }
}
