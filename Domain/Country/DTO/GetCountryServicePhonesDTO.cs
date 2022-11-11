using Domain.ServicePhone.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Country.DTO
{
    public class GetCountryServicePhonesDTO
    {
        public string Name { get; set; }
        public GetServicePhoneDTO Number { get; set; }
    }
}
