﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Sms
{
    public sealed class AddSmsResponseDto
    {
        public int Id { get; set; }
        public int FacilityID { get; set; }

        public int Event { get; set; }
        public string SmsFrom { get; set; }

        public string SmsContent { get; set; }

        public string EmailContent { get; set; }

        public bool IsSmsEnable { get; set; }

        public bool IsEmailEnable { get; set; }

        public int? CreatedBy { get; set; }


        public FacilityListDto Facility { get; set; }
    }

    public sealed class FacilityListDto
    {
        public string Id { get; set; }

        public string Facility { get; set; }
    }
}
