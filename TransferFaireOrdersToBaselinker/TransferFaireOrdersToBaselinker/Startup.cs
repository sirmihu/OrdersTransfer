using System;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FaireApiNs = FaireApi;
using FaireApi.Utils;
using BaselinkerApi.Utils;
using BaselinkerApiNs = BaselinkerApi;
using Microsoft.Extensions.Configuration;
using FaireApi.Settings;
using BaselinkerApi.Settings;

[assembly: FunctionsStartup(typeof(TransferFaireOrdersToBaselinker.Startup))]
namespace TransferFaireOrdersToBaselinker
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IFaireApiHttpClient, FaireApiHttpClient>();
            builder.Services.AddTransient<FaireApiNs.IFaireApi, FaireApiNs.FaireApi>();

            builder.Services.AddTransient<IBaselinkerApiHttpClient, BaselinkerApiHttpClient>();
            builder.Services.AddTransient<BaselinkerApiNs.IBaselinkerApi, BaselinkerApiNs.BaselinkerApi>();
        }
    }
}

