using Autofac;
using SpecFlow.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebUI.Tests.Contexts;

namespace WebUI.Tests
{
    public static class Dependencies
    {
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WebBrowserContext>().SingleInstance();
            builder.RegisterType<PaymentDetailsContext>().SingleInstance();
            builder.RegisterType<MockServicesContext>().SingleInstance();

            //TODO: add customizations, stubs required for testing

            //auto-reg all types from our assembly
            //builder.RegisterAssemblyTypes(typeof(TestDependencies).Assembly).SingleInstance();

            //auto-reg all [Binding] types from our assembly
            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            return builder;
        }
    }

    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            return Dependencies.CreateContainerBuilder();
        }
    }
}
