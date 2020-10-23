using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Slot.Request
{
    public class AddSlotRequestDto
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string ConsultationInterval { get; set; }

        public int CreatedBy { get; set; }
    }
}
