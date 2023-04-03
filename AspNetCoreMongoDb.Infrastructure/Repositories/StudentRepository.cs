using AspNetCoreMongodb.Core.Models;
using AspNetCoreMongodb.Models;
using AspNetCoreMongoDb.Application.Interfaces;


namespace AspNetCoreMongoDb.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoDbRepository<Student, string> _repository;

        public StudentRepository(IMongoDbRepository<Student, string> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Student student)
            => await _repository.AddAsync(student);

        public async Task<IReadOnlyList<Student>> GetAllAsync()
            => await _repository.FindAsync(e => true);

        public async Task<Student> GetByIdAsync(string id)
            => await _repository.GetAsync(id);

    }
}
