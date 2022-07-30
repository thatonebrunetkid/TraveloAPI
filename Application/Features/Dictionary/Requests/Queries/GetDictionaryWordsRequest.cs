using Application.DTOs.Dictionary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dictionary.Requests.Queries
{
    public class GetDictionaryWordsRequest : IRequest<List<GetDictionaryWordDTO>>
    {
        public int DictionaryId;
    }
}
