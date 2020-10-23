using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.EmailSetting.Request
{
    public sealed  class UpdateEmailSettingRequestDto
    {

        public string SMTPClient { get; set; }

        public string SMTPPort { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailFrom { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public int FacilityID { get; set; }
        public int RegulatoryID { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
