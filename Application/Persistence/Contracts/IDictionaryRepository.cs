using Application.DTOs.Dictionary;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IDictionaryRepository
    {
        public Task<List<Dictionary>> GetDictionaries();
        public List<DictionaryWord> GetDictionaryWords(int DictionaryId);
    }
}
