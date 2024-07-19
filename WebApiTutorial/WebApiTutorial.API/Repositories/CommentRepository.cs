using Microsoft.EntityFrameworkCore;
using WebApiTutorial.API.Data;
using WebApiTutorial.API.Interfaces;
using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Comment>> GetAllAsync()
        {
            return _context.Comments.ToListAsync();
        }
    }
}
