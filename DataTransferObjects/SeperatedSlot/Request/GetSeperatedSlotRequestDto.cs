using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.SeperatedSlot.Request
{
    public class GetSeperatedSlotRequestDto
    {
        public string FacilityID { get; set; }

        public string ClinicianID { get; set; }

        public string PreferredDate { get; set; }
    }
}
