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
    public class GetDictionaryWordsHandler : IRequestHandler<GetDictionaryWordsRequest, List<GetDictionaryWordDTO>>
    {
        private readonly IDictionaryRepository _DictionaryRepository;
        private readonly IMapper _Mapper;

        public GetDictionaryWordsHandler(IDictionaryRepository DictionaryRepository, IMapper Mapper)
        {
            _DictionaryRepository = DictionaryRepository;
            _Mapper = Mapper;
        }
        public async Task<List<GetDictionaryWordDTO>> Handle(GetDictionaryWordsRequest request, CancellationToken cancellationToken)
        {
            var DictionaryWords = _DictionaryRepository.GetDictionaryWords(request.DictionaryId);
            return _Mapper.Map<List<GetDictionaryWordDTO>>(DictionaryWords);
        }
    }
}
