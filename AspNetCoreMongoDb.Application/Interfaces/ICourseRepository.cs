using AspNetCoreMongodb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMongoDb.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course);
        Task<IReadOnlyList<Course>> GetAllAsync();
    }
}
