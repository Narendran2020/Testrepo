using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Slot.Response
{
    public class AddSlotResponseDto
    {
        public string Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string ConsultationInterval { get; set; }
    }
}
