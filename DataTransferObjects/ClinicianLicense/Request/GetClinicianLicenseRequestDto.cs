using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianLicense.Request
{
    public sealed class GetClinicianLicenseRequestDto
    {

        public string FacilityId { get; set; }

        public string MedicalDepartmentId { get; set; }
    }
}
