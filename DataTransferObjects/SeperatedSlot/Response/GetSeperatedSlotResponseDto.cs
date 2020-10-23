using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.SeperatedSlot.Response
{
    public sealed class GetSeperatedSlotResponseDto
    {
        public int Id { get; set; }

        public string SlotTime { get; set; }
    }
}
