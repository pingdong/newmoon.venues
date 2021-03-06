﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PingDong.DDD.Infrastructure;
using PingDong.DDD.Services;
using PingDong.Messages;
using PingDong.Newmoon.Venues.Infrastructure;
using PingDong.Services;
using System;
using System.Reflection;

namespace PingDong.Newmoon.Venues.Services
{
    public class Registrar
    {
        public virtual void Register(IServiceCollection services)
        {
            services.AddScoped<IRequestManager, RequestManager>();
            services.AddScoped(typeof(ITenantManager<string>), typeof(TenantManager));

            // MediatR
            services.AddMediatR(
                typeof(DomainEventHandler).Assembly,
                Assembly.GetExecutingAssembly()
            );

            // FluentValidation
            services.AddValidatorsFromAssemblies(new [] {
                //    From this assembly
                Assembly.GetExecutingAssembly()
            });

            // Venue Services
            services.AddSingleton<IVenueQueryService, VenueQueryService>();

            // Dump
            services.AddSingleton<IRepository<Guid, Venue>, DumpRepository>();
            services.AddSingleton<DumpContext>();
            services.AddSingleton<IMessagePublisher, DumpPublisher>();
        }
    }
}
