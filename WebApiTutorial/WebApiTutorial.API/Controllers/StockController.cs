using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTutorial.API.Data;
using WebApiTutorial.API.Dtos.Stock;
using WebApiTutorial.API.Interfaces;
using WebApiTutorial.API.Mappers;
using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stockDto = stocks.Select(x => x.ToStockDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if(stock is null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto request)
        {
            Stock stock = await _stockRepository.CreateAsync(request);
            return Ok(stock.Id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto request)
        {
            var stockModel = await _stockRepository.UpdateAsync(id, request);

            if (stockModel is null) 
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var stockModel = await _stockRepository.DeleteAsync(id);

            if (stockModel is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
