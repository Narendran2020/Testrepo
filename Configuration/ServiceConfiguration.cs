using AutoMapper;
using medical.data;
using medical.data.repositories;
using medical.Service.services;
using medical.ServiceContract.services;
using Medical.Controllers;
using Medical.DataContracts.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Medical.Configuration
{
    public static class ServiceConfiguration
    {

        public static void AddServices(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IRegistrationService, RegistrationService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<ILoginService, LoginService>();
            serviceCollection.AddScoped<ISlotService, SlotService>();
            serviceCollection.AddScoped<IStatusService, StatusService>();
            serviceCollection.AddScoped<IClinicianScheduleService, ClinicianScheduleService>();
            serviceCollection.AddScoped<IFacilityService, FacilityService>();
            serviceCollection.AddScoped<IClinicianLicenseService, ClinicianLicenseService>();
            serviceCollection.AddScoped<IDepartmentService, DepartmentService>();
            serviceCollection.AddScoped<ISeperatedSlotService, SeperatedSlotService>();
            serviceCollection.AddScoped<IPatientService, PatientService>();
            serviceCollection.AddScoped<IAppointmentService, AppointmentService>();
            serviceCollection.AddScoped<ICalendarService, CalendarService>();
            serviceCollection.AddScoped<IReScheduleService, ReScheduleService>();
            serviceCollection.AddScoped<ISmsService, SmsService>();
            serviceCollection.AddScoped<ISmsSettingService, SmsSettingService>();
            serviceCollection.AddScoped<IEmailSettingService,EmailSettingService>();
            serviceCollection.AddScoped<IAppointmentPrefixService, AppointmentPrefixService>();
            serviceCollection.AddScoped<INationalityService, NationalityService>();
            serviceCollection.AddScoped<ILocationService, LocationServices>();
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IRegistrationRepository, RegistrationRepository>();
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<ILoginRepository, LoginRepository>();
            serviceCollection.AddScoped<ISlotRepository, SlotRepository>();
            serviceCollection.AddScoped<IStatusRepository, StatusRepository>();
            serviceCollection.AddScoped<IClinicianScheduleRepository, ClinicianScheduleRepository>();
            serviceCollection.AddScoped<IFacilityRepository, FacilityRepository>();
            serviceCollection.AddScoped<IClinicianLicenseRepository, ClinicianLicenseRepository>();
            serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
            serviceCollection.AddScoped<ISeperatedSlotRepository, SeperatedSlotRepository>();
            serviceCollection.AddScoped<IPatientRepository, PatientRepository>();
            serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();
            serviceCollection.AddScoped<ICalendarRepository, CalendarRepository>();
            serviceCollection.AddScoped<IReScheduleRepository, ReScheduleRepository>();
            serviceCollection.AddScoped<ISmsRepository, SmsRepository>();
            serviceCollection.AddScoped<ISmsSettingRepository, SmsSettingRepository>();
            serviceCollection.AddScoped<IEmailSettingRepository, EmailSettingRepository>();
            serviceCollection.AddScoped<IAppointmentPrefixRepository, AppointmentPrefixRepository>();
            serviceCollection.AddScoped<INationalityRepository, NationalityRepository>();
            serviceCollection.AddScoped<ILocationRepository, LocationRepository>();
        }

        public static void AddSqlServerDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddDbContext<MedicalDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperProfiles(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            var autoMapperAssemblies = new List<Assembly>
            {
                typeof(RegistrationController).GetTypeInfo().Assembly,
                typeof(RegistrationService).GetTypeInfo().Assembly
            };

            serviceCollection.AddAutoMapper(autoMapperAssemblies);
        }

        public static void AddValidators(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }
        }
    }
}