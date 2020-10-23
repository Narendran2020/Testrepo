using AutoMapper;
using medical.ServiceContract.ServiceObjects;
using Medical.DataTransferObjects.Appointment.Request;
using Medical.DataTransferObjects.Appointment.Response;
using Medical.DataTransferObjects.Appointment_Prefix.Request;
using Medical.DataTransferObjects.Appointment_Prefix.Response;
using Medical.DataTransferObjects.Calender;
using Medical.DataTransferObjects.ClinicianLicense.Request;
using Medical.DataTransferObjects.ClinicianLicense.Response;
using Medical.DataTransferObjects.ClinicianSchedule.Request;
using Medical.DataTransferObjects.ClinicianSchedule.Response;
using Medical.DataTransferObjects.Country.Request;
using Medical.DataTransferObjects.Country.Response;
using Medical.DataTransferObjects.Department.Response;
using Medical.DataTransferObjects.EmailSetting.Request;
using Medical.DataTransferObjects.EmailSetting.Response;
using Medical.DataTransferObjects.Facility.Response;
using Medical.DataTransferObjects.Location.Response;
using Medical.DataTransferObjects.Login.Request;
using Medical.DataTransferObjects.Nationality.Response;
using Medical.DataTransferObjects.Patient.Response;
using Medical.DataTransferObjects.Registration.Request;
using Medical.DataTransferObjects.Registration.Response;
using Medical.DataTransferObjects.ReSchedule.Request;
using Medical.DataTransferObjects.ReSchedule.Response;
using Medical.DataTransferObjects.SeperatedSlot.Request;
using Medical.DataTransferObjects.SeperatedSlot.Response;
using Medical.DataTransferObjects.Slot.Request;
using Medical.DataTransferObjects.Slot.Response;
using Medical.DataTransferObjects.Sms;
using Medical.DataTransferObjects.Sms.Request;
using Medical.DataTransferObjects.Sms.Response;
using Medical.DataTransferObjects.SmsSetting.Request;
using Medical.DataTransferObjects.SmsSetting.Response;
using Medical.DataTransferObjects.Status.Request;
using Medical.DataTransferObjects.Status.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Medical.DataTransferObjects.Appointment.Request.AddAppointmentRequestDto;

namespace Medical.Configuration
{
    public sealed class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMapForRegistrations();
            this.CreateMapForCountries();
            this.CreateMapForLogin();
            this.CreateMapForSlots();
            this.CreateMapForStatus();
            this.CreateMapForClinicianSchedules();
            this.CreateMapForFacilities();
            this.CreateMapForClinicianLicense();
            this.CreateMapForDepartments();
            this.CreateMapForSeperatedSlots();
            this.CreateMapForPatients();
            this.CreateMapForAppointments();
            this.CreateMapForCalender();
            this.CreateMapForReSchedule();
            this.CreateMapForSMS();
            this.CreateMapForSMSSetting();
            this.CreateMapForEmailSetting();
            this.CreateMapForAppointmentPrefix();
            this.CreateMapForNationality();
            this.CreateMapForLocations();
        }

        private void CreateMapForRegistrations()
        {
            this.CreateMap<AddRegistrationRequestDto, RegistrationServiceObject>()
            .ForMember(so => so.PatientAddress, opt => opt.MapFrom(dto => dto.PatientAddress));

            this.CreateMap<PatientAddressRequestDto, PatientAddressServiceObject>();

            this.CreateMap<RegistrationServiceObject, AddRegistrationResponseDto>();

            this.CreateMap<UpdateRegistrationRequestDto, RegistrationServiceObject>();
            this.CreateMap<RegistrationServiceObject, UpdateRegistrationResponseDto>();

            this.CreateMap<RegistrationServiceObject, GetRegistrationResponseDto>();

            this.CreateMap<PatientAddressServiceObject, PatientResponseDto>();
        }
        private void CreateMapForReSchedule()
        {
            this.CreateMap<AddReScheduleRequestDto, ReScheduleServiceObject>();
            this.CreateMap<ReScheduleServiceObject, AddReScheduleResponseDto>();

        }
        private void CreateMapForCountries()
        {
            this.CreateMap<AddCountryRequestDto, CountryServiceObject>();
            this.CreateMap<CountryServiceObject, AddCountryResponseDto>();

            this.CreateMap<UpdateCountryRequestDto, CountryServiceObject>();
            this.CreateMap<CountryServiceObject, UpdateCountryResponseDto>();

            this.CreateMap<CountryServiceObject, GetCountryResponseDto>();
        }
        private void CreateMapForNationality()
        {
            this.CreateMap<NationalityServiceObject, GetNationalityResponseDto>();
        }
        private void CreateMapForLocations()
        {
            this.CreateMap<LocationServiceObject, GetLocationResponseDto>();
        }
        private void CreateMapForLogin()
        {
            this.CreateMap<AddLoginRequestDto, LoginServiceObject>();
        }
        private void CreateMapForFacilities()
        {
            this.CreateMap<FacilityServiceObject, GetFacilityResponseDto>();
        }
        private void CreateMapForSeperatedSlots()
        {
            this.CreateMap<GetSeperatedSlotRequestDto, GetSeperatedSlotServiceObject>();
            this.CreateMap<SeperatedSlotServiceObject, GetSeperatedSlotResponseDto>();
        }

        private void CreateMapForCalender()
        {
            this.CreateMap<CalendarServiceObject, GetCalenderResponseDto>();
        }
        private void CreateMapForDepartments()
        {
            this.CreateMap<DepartmentServiceObject, GetDepartmentResponseDto>();
        }
        private void CreateMapForClinicianLicense()
        {
            this.CreateMap<GetClinicianLicenseRequestDto, ClinicianLicenseServiceObject>();
            this.CreateMap<ClinicianLicenseServiceObject, GetClinicianLicenseResponseDto>();
        }
        private void CreateMapForSlots()
        {
            this.CreateMap<AddSlotRequestDto, SlotServiceObject>();
            this.CreateMap<SlotServiceObject, AddSlotResponseDto>();

            this.CreateMap<UpdateSlotRequestDto, SlotServiceObject>();
            this.CreateMap<SlotServiceObject, UpdateSlotResponseDto>();

            this.CreateMap<SlotServiceObject, GetSlotResponseDto>();
        }

        private void CreateMapForSMS()
        {
            this.CreateMap<AddSmsRequestDto, SmsServiceObject>();
            this.CreateMap<SmsServiceObject, AddSmsResponseDto>();

            this.CreateMap<UpdateSmsRequestDto, SmsServiceObject>();
            this.CreateMap<SmsServiceObject, UpdateSmsResponseDto>();

            this.CreateMap<SmsServiceObject, GetSmsResponseDto>();
            this.CreateMap<FacilityServiceObject, FacilityListDto>();
        }

        private void CreateMapForSMSSetting()
        {
            this.CreateMap<AddSmsSettingRequestDto, SmsSettingServiceObject>();
            this.CreateMap<SmsSettingServiceObject, AddSmsSettingResponseDto>();

            this.CreateMap<UpdateSmsSettingRequestDto, SmsSettingServiceObject>();
            this.CreateMap<SmsSettingServiceObject, UpdateSmsSettingResponseDto>();

            this.CreateMap<SmsSettingServiceObject, GetSmsSettingResponseDto>();
            this.CreateMap<FacilityServiceObject, FacilityListDto>();
        }

        private void CreateMapForAppointmentPrefix()
        {
            this.CreateMap<AddAppointmentPrefixRequestDto, AppointmentprefixServiceObject>();
            this.CreateMap<AppointmentprefixServiceObject, AddAppointmentPrefixResponseDto>();

            this.CreateMap<UpdateAppointmentPrefixRequestDto, AppointmentprefixServiceObject>();
            this.CreateMap<AppointmentprefixServiceObject, UpdateAppointmentPrefixResponseDto>();

            this.CreateMap<AppointmentprefixServiceObject, GetAppointmentPrefixResponseDto>();
            this.CreateMap<FacilityServiceObject, FacilityListDto>();
        }


        private void CreateMapForEmailSetting()
        {
            this.CreateMap<AddEmailSettingRequestDto, EmailSettingServiceObject>();
            this.CreateMap<EmailSettingServiceObject, AddEmailSettingResponseDto>();

            this.CreateMap<UpdateEmailSettingRequestDto, EmailSettingServiceObject>();
            this.CreateMap<EmailSettingServiceObject, UpdateEmailSettingResponseDto>();

            this.CreateMap<EmailSettingServiceObject, GetEmailSettingResponseDto>();
            this.CreateMap<FacilityServiceObject, FacilityListDto>();
        }
        private void CreateMapForClinicianSchedules()
        {
            this.CreateMap<AddClinicianScheduleRequestDto, ClinicianScheduleServiceObject>();
            this.CreateMap<SearchClinicianScheduleDto, SearchClinicianScheduleServiceObject>()
            .ForMember(so => so.Begin, opt => opt.MapFrom(dto => dto.ScheduleDates.Begin))
            .ForMember(so => so.End, opt => opt.MapFrom(dto => dto.ScheduleDates.End));
            this.CreateMap<ClinicianScheduleServiceObject, AddClinicianScheduleResponseDto>();

            this.CreateMap<UpdateClinicianScheduleRequestDto, ClinicianScheduleServiceObject>();
            this.CreateMap<ClinicianScheduleServiceObject, UpdateClinicianScheduleResponseDto>();

            this.CreateMap<ClinicianScheduleServiceObject, GetClinicianScheduleResponseDto>();

            this.CreateMap<SlotServiceObject, SlotDto>();
            this.CreateMap<FacilityServiceObject, FacilityDto>();
            this.CreateMap<ClinicianLicenseServiceObject, ClinicianLicenseDto>();
        }
        private void CreateMapForAppointments()
        {
            this.CreateMap<AddAppointmentRequestDto, AppointmentServiceObject>()
            //this.CreateMap<AddAppointmentRequestDto, AppointmentScheduleServiceObject>();
            .ForMember(so => so.AppointmentSchedule, opt => opt.MapFrom(dto => dto.AppointmentSchedule));
            this.CreateMap<CancelAppointmentRequest, CancelAppointmentServiceObject>();
            this.CreateMap<UpdateAppointmentRequestDto, AppointmentServiceObject>();
            this.CreateMap<AppointmentServiceObject, UpdateAppointmentResponseDto>();

            this.CreateMap<AddAppointmentScheduleRequestDto, AppointmentScheduleServiceObject>();

            this.CreateMap<AppointmentServiceObject, GetAppointmentResponseDto>()
            .ForMember(dto => dto.AppointmentSchedule, opt => opt.MapFrom(so => so.AppointmentSchedule));


            this.CreateMap<AppointmentScheduleServiceObject, AppointmentScheduleResponseDto>();
        }
        private void CreateMapForPatients()
        {
            this.CreateMap<PatientServiceObject, GetPatientResponseDto>();

            this.CreateMap<PatientServiceObject, GetMRNResponseDto>();

            this.CreateMap<PatientAddressServiceObject, PatientAddressDto>();
        }
        private void CreateMapForStatus()
        {
            this.CreateMap<AddStatusRequestDto, StatusServiceObject>();
            this.CreateMap<StatusServiceObject, AddStatusResponseDto>();

            this.CreateMap<UpdateStatusRequestDto, StatusServiceObject>();
            this.CreateMap<StatusServiceObject, UpdateStatusResponseDto>();

            this.CreateMap<StatusServiceObject, GetStatusResponseDto>();
        }
    }
}
