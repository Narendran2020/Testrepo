using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Patient.Response
{
    public class GetMRNResponseDto
    {
        public int Id { get; set; }

        public string MRN { get; set; }
    }
}
