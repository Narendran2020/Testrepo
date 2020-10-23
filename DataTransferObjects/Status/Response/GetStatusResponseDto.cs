using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Status.Response
{
    public class GetStatusResponseDto
    {
        public string Id { get; set; }

        public string AppointmentStatus { get; set; }

        public string StatusColor { get; set; }
    }
}
