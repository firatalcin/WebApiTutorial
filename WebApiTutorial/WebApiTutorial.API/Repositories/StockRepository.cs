using Microsoft.EntityFrameworkCore;
using WebApiTutorial.API.Data;
using WebApiTutorial.API.Interfaces;
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

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}
