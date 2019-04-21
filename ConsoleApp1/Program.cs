﻿using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // add data protection services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            // create an instance of MyClass using the service provider
            var instance = ActivatorUtilities.CreateInstance<MyClass>(services);
            instance.RunSample();
            Console.ReadLine();
        }

        public class MyClass
        {
            IDataProtector _protector;

            // the 'provider' parameter is provided by DI
            public MyClass(IDataProtectionProvider provider)
            {
                _protector = provider.CreateProtector("Contoso.MyClass.v1");
            }

            public void RunSample()
            {
                Console.Write("Enter input: ");
                string input = Console.ReadLine();

                // protect the payload
                string protectedPayload = _protector.Protect(input);
                Console.WriteLine($"Protect returned: {protectedPayload}");

                // unprotect the payload
                string unprotectedPayload = _protector.Unprotect(protectedPayload);
                Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
            }
        }
    }
}
