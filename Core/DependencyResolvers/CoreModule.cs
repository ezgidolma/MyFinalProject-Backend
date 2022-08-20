using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Ultities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule//servis bağımlılıklarımızı çözeceğimiz yer
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); 
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor >();
            serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager >();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
