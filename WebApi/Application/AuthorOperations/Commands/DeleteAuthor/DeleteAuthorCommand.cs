using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == AuthorId);
            var books = _context.Books.Where(x => x.AuthorId == AuthorId).ToList();
            if (author is null)
            {
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı");
            }
            if (author is not null)
            {
                if (books.Count > 0)
                {
                    _context.Books.RemoveRange(books);
                }
                _context.Authors.Remove(author);
            }

            _context.SaveChanges();
        }
    }
}
