using System.Runtime.CompilerServices;
using WebApiTutorial.API.Dtos.Comment;
using WebApiTutorial.API.Models;

namespace WebApiTutorial.API.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
                Title = comment.Title
            };
        }
    }
}
