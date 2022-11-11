using Domain.OweSinglePayment.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelTypes.Queries
{
    public class GetPayersNameQuerieRequest : IRequest<List<GetOweSinglePayersDTO>>
    {
        public int TravelId { get; set; }
    }

    public class GetPayersNameQuerieHandler : IRequestHandler<GetPayersNameQuerieRequest, List<GetOweSinglePayersDTO>>
    {

    }
}
