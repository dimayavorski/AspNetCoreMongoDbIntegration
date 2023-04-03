using AspNetCoreMongodb.Core.Models;
using AspNetCoreMongoDb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMongoDb.Infrastructure.Repositories
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IMongoDbRepository<Course, string> _repository;
        public CourseRepository(IMongoDbRepository<Course, string> repository) {
            _repository = repository;
        }

        public Task AddAsync(Course course) => _repository.AddAsync(course);

        public Task<IReadOnlyList<Course>> GetAllAsync()
            => _repository.FindAsync(e => true);

        public async Task<Course> GetByIdAsync(string id)
            => await _repository.GetAsync(id);
    }
}
