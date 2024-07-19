using Microsoft.EntityFrameworkCore;
using WebApiTutorial.API.Data;
using WebApiTutorial.API.Dtos.Stock;
using WebApiTutorial.API.Interfaces;
using WebApiTutorial.API.Mappers;
using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(CreateStockRequestDto request)
        {
            var stockModel = request.ToStockFromCreateDto();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel is null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto request)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel is null)
            {
                return null;
            }

            stockModel.Symbol = request.Symbol;
            stockModel.CompanyName = request.CompanyName;
            stockModel.Purchase = request.Purchase;
            stockModel.LastDiv = request.LastDiv;
            stockModel.MarketCap = request.MarketCap;
            stockModel.Industry = request.Industry;

            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}
