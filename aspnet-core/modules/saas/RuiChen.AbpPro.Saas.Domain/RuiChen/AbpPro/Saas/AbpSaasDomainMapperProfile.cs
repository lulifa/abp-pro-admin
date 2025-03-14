﻿using AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.Saas
{
    public class AbpSaasDomainMapperProfile:Profile
    {
        public AbpSaasDomainMapperProfile()
        {
            CreateMap<Edition, EditionInfo>();
            CreateMap<Edition, EditionEto>();

            CreateMap<Tenant, TenantConfiguration>()
                .ForMember(ti => ti.ConnectionStrings, opts =>
                {
                    opts.MapFrom((tenant, ti) =>
                    {
                        var connStrings = new ConnectionStrings();

                        foreach (var connectionString in tenant.ConnectionStrings)
                        {
                            connStrings[connectionString.Name] = connectionString.Value;
                        }

                        return connStrings;
                    });
                })
                .ForMember(ti => ti.IsActive, opts =>
                {
                    opts.MapFrom((tenant, ti) =>
                    {
                        if (!tenant.IsActive)
                        {
                            return false;
                        }
                        // Injection IClock ?
                        if (tenant.EnableTime.HasValue && DateTime.Now < tenant.EnableTime)
                        {
                            return false;
                        }

                        if (tenant.DisableTime.HasValue && DateTime.Now > tenant.DisableTime)
                        {
                            return false;
                        }

                        return true;
                    });
                });

            CreateMap<Tenant, TenantEto>();
        }
    }
}
