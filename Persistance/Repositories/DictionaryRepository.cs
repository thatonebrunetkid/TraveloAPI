using Application.DictionaryTypes.Contracts;
using Domain.Dictionary.Entities;
using Domain.DictionaryWord.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly TraveloDbContext DbContext;

        public DictionaryRepository(TraveloDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Domain.Dictionary.Entities.Dictionary>> GetAllDictionaries()
        {
            return await DbContext.Dictionary.ToListAsync();
        }

        public List<DictionaryWord> GetDictionaryWords(int DictionaryId)
        {
            return DbContext.DictionaryWord.Where(e => e.DictionaryId == DictionaryId).ToList();
        }


    }
}
