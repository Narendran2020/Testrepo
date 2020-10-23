using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Patient.Response
{
    public class GetPatientResponseDto
    {
        public int Id { get; set; }

        public string EmeriteID { get; set; }

        public int PatientTitleID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GenderID { get; set; }

        public PatientAddressDto PatientAddress { get; set; }

        public string Mobile { get; set; }
    }
    public sealed class PatientAddressDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FullAddress { get; set; }
    }
    }
