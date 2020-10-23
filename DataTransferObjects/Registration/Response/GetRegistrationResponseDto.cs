﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Registration.Response
{
    public class GetRegistrationResponseDto
    {
        public int Id { get; set; }

        public int PatientTitleID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int GenderID { get; set; }

        public int MaritalStatusID { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Mobile { get; set; }

        public int NationalityID { get; set; }

        public bool VIP { get; set; }

        public bool HasEmeriteID { get; set; }

        public string EmeriteID { get; set; }

        public bool IsManual { get; set; }

        public bool ISSMSEnable { get; set; }

        public int FacilityID { get; set; }

        public int CompanyID { get; set; }

        public int LocationID { get; set; }

        public string Occupation { get; set; }

        public int ReligionID { get; set; }

        public int CreatedBy { get; set; }

        public decimal AdvanceAmount { get; set; }

        public PatientResponseDto PatientAddress { get; set; }
    }
    public sealed class PatientResponseDto
    {
        public int Id { get; set; }

        public int CountryID { get; set; }

        public string Email { get; set; }

        public int FullAddress { get; set; }

        public string NextOfKin { get; set; }

        public int NextOfKinPhone { get; set; }
    }
}
