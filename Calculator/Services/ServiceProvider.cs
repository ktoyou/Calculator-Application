using Calculator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.Services
{
    internal static class ServiceProvider
    {
        private static readonly IServiceProvider _provider;

        static ServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();

            _provider = services.BuildServiceProvider();
        }

        public static T GetViewModel<T>() where T: BaseViewModel => _provider.GetService<T>();
    }
}
