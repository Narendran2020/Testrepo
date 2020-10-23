﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Sms.Request
{
    public sealed class UpdateSmsRequestDto
    {
        public int FacilityID { get; set; }

        public int Event { get; set; }
        public string SmsFrom { get; set; }

        public string SmsContent { get; set; }

        public string EmailContent { get; set; }

        public bool IsSmsEnable { get; set; }

        public bool IsEmailEnable { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
