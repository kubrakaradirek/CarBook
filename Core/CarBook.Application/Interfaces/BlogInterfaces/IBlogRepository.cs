using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetLast3BlogsWithAuthors();
        List<Blog> GetAllBlogsWithAuthors();
    }
}
