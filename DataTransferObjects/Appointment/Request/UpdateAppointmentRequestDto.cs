using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Appointment.Request
{
    public class UpdateAppointmentRequestDto
    {
        public string MRN { get; set; }

        public string EmirateID { get; set; }

        public string PatientTitle { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public int GenderID { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Reason { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime PreferredBookingDate { get; set; }

        public string PreferredSlot { get; set; }

        public int ClinicianSlotTransID { get; set; }

        public int FacilityID { get; set; }
    }
}
