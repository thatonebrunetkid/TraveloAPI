using Application.DictionaryTypes.Contracts;
using AutoMapper;
using Domain.Dictionary.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DictionaryTypes.Handlers.Queries
{
    public class GetDictionariesQuerieRequest : IRequest<GetDictionariesDTO>
    {
    }

    public class GetDictionariesQuerieHandler : IRequestHandler<GetDictionariesQuerieRequest, GetDictionariesDTO>
    {
        private readonly IDictionaryRepository Repository;
        private readonly IMapper Mapper;

        public GetDictionariesQuerieHandler(IDictionaryRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<GetDictionariesDTO> Handle(GetDictionariesQuerieRequest request, CancellationToken cancellationToken)
        {
            var Dictionaries = await Repository.GetAllDictionaries();
            foreach (var dictionary in Dictionaries)
                dictionary.Words = Repository.GetDictionaryWords(dictionary.DictionaryId);
            var DictionariesMapper = Mapper.Map<List<GetDictionaryDTO>>(Dictionaries);
            GetDictionariesDTO Mapping = new GetDictionariesDTO();
            Mapping.Dictionaries = DictionariesMapper;
            return Mapping;
        }
    }
}
