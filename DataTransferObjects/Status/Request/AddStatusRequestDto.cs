using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Status.Request
{
    public class AddStatusRequestDto
    {
        public string AppointmentStatus { get; set; }

        public string StatusColor { get; set; }

        public int CreatedBy { get; set; }
    }
}
