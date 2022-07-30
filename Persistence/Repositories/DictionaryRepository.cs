using Application.DTOs.Dictionary;
using Application.Persistence.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DictionaryRepository : GenericRepository<Dictionary>, IDictionaryRepository
    {
        private readonly TraveloDbContext _dbContext;

        public DictionaryRepository (TraveloDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dictionary>> GetDictionaries()
        {
            return await _dbContext.Dictionary.ToListAsync();
        }

        public List<DictionaryWord> GetDictionaryWords(int DictionaryId)
        {
            return _dbContext.DictionaryWord.Where(e => e.DictionaryId == DictionaryId).ToList();
        }
    }
}
