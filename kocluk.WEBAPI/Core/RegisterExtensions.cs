﻿using kocluk.CORE.Repository;
using kocluk.DOMAIN;
using kocluk.SERVICES.Interface;
using kocluk.SERVICES.Services;
using Microsoft.EntityFrameworkCore;

namespace kocluk.WEBAPI.Core
{
    internal static class RegisterExtensions
    {
        internal static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var contextConnectionString = configuration.GetConnectionString("Default");
            services.AddDbContextPool<koclukdb>(x => x.UseSqlServer(contextConnectionString, o =>
            {
                o.EnableRetryOnFailure(3);
            })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        internal static void AddInjections(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudyService, StudyService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IBookingRequestService, BookingRequestService>();

        }
    }
}
