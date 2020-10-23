using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ReSchedule.Request
{
    public class CancelAppointmentRequest
    {
        public int Id { get; set; }

        public string ReScheduleReason { get; set; }
    }
}
