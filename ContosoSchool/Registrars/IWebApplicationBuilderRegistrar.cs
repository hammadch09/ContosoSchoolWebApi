﻿namespace ContosoSchool.Registrars
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder);
    }
}
