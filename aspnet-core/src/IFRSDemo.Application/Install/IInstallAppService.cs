﻿using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.Install.Dto;

namespace IFRSDemo.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}