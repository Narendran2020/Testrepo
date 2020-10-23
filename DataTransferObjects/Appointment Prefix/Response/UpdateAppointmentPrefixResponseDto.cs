﻿using Medical.DataTransferObjects.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Appointment_Prefix.Response
{
    public sealed class UpdateAppointmentPrefixResponseDto
    {
        public int Id { get; set; }
        public string Prefix { get; set; }

        public bool EnablePrefix { get; set; }
        public string StartWith { get; set; }

        public int FacilityID { get; set; }
        public int RegulatoryID { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }
        public FacilityListDto Facility { get; set; }
    }
}
