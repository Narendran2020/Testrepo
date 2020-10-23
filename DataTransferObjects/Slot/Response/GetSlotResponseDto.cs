using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Slot.Response
{
    public class GetSlotResponseDto
    {
        public string Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string ConsultationInterval { get; set; }
    }
}
