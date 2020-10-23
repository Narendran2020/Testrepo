using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Facility.Response
{
    public class GetFacilityResponseDto
    {
        public string Id { get; set; }

        public string Facility { get; set; }

        public string FacilityCode { get; set; }
    }
}
