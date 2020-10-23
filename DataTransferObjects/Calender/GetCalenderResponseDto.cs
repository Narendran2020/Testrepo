using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Calender
{
    public sealed class GetCalenderResponseDto
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Title { get; set; }

    }
}
