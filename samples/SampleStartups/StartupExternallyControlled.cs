using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

// Note that this sample will not run. It is only here to illustrate usage patterns.

namespace SampleStartups
{
    public class StartupExternallyControlled : StartupBase
    {
        private IHost _host;
        private readonly List<string> _urls = new List<string>();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public StartupExternallyControlled()
        {
        }

        public void Start()
        {
            _host = new HostBuilder()
                .UseWebHostBuilder(b =>
                {

                })
                .UseRabbitMq()
                .Build();

            _host.Start();
        }

        public void Stop()
        {
            _host.Dispose();
        }

        public void AddUrl(string url)
        {
            _urls.Add(url);
        }
    }
}
