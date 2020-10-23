using Medical.DataTransferObjects.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.SmsSetting.Response
{
    public sealed class GetSmsSettingResponseDto
    {

        public int Id { get; set; }
        public string SMSProvider { get; set; }

        public string SMSProviderURL { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string MessageType { get; set; }

        public bool DeliveryReportRequired { get; set; }

        public int FacilityID { get; set; }
        public int RegulatoryID { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public FacilityListDto Facility { get; set; }
    }
}
