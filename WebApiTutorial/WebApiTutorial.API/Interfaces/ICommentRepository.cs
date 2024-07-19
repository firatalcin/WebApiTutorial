using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();
    }
}
