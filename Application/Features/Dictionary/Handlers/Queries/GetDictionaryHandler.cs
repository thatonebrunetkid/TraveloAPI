using Application.DTOs.Dictionary;
using Application.Features.Dictionary.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Dictionary.Handlers.Queries
{
    public class GetDictionaryHandler : IRequestHandler<GetDictionaryRequest, GetDictionariesDTO>
    {
        private readonly IDictionaryRepository _DictionaryRepository;
        private readonly IMapper _Mapper;

        public GetDictionaryHandler(IDictionaryRepository DictionaryRepository, IMapper Mapper)
        {
            _DictionaryRepository = DictionaryRepository;
            _Mapper = Mapper;
        }

        public async Task<GetDictionariesDTO> Handle(GetDictionaryRequest request, CancellationToken cancellationToken)
        {
            var Dictionaries = await _DictionaryRepository.GetDictionaries();
            foreach(Domain.Entities.Dictionary element in Dictionaries)
            {
                element.Words = _DictionaryRepository.GetDictionaryWords(element.DictionaryId);
            }

            var DictionariesMapper = _Mapper.Map<List<GetDictionaryDTO>>(Dictionaries);
            GetDictionariesDTO Mapping = new GetDictionariesDTO();
            Mapping.Dictionaries = DictionariesMapper;
            return Mapping;
        }
    }
}
