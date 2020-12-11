using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {

        //调用iis
        /// <summary>
        /// 因为我们的web程序需要一个宿主, 所以 CreateWebHostBuilder这个方法就创建了一个WebHostBuilder. 而且我们还需要Web Server.

        /// asp.net core 自带了两种http servers, 一个是WebListener, 它只能用于windows系统, 另一个是kestrel, 它是跨平台的.

        ///kestrel是默认的web server, 就是通过UseKestrel()这个方法来启用的.

        ///但是我们开发的时候使用的是IIS Express, 调用UseIISIntegration()这个方法是启用IIS Express, 它作为Kestrel的Reverse Proxy server反向代理服务器来用
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();
            //UseStartup<Startup>(), 这句话表示在程序启动的时候, 我们会调用Startup这个类.

            //Build()完之后返回一个实现了IWebHost接口的实例(WebHostBuilder), 然后调用Run()就会运行Web程序, 并且阻止这个调用的线程, 直到程序关闭.
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
