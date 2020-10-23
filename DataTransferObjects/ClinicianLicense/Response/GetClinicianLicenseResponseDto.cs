using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianLicense.Response
{
    public sealed class GetClinicianLicenseResponseDto
    {
        public int Id { get; set; }

        public string Clinician { get; set; }

        public string ClinicianLicense { get; set; }

        public int FacilityId { get; set; }

    }
}
