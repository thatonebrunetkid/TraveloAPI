using Domain.DictionaryWord.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DictionaryTypes.Contracts
{
    public interface IDictionaryRepository
    {
        Task<List<Domain.Dictionary.Entities.Dictionary>> GetAllDictionaries();
        List<DictionaryWord> GetDictionaryWords(int DictionaryId);
    }
}
