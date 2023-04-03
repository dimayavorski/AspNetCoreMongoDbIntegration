using AspNetCoreMongodb.Core.Models;
using AspNetCoreMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMongoDb.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<IReadOnlyList<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
    }
}
