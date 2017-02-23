using Autofac;
using Experion.Marina.Business.Services;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Contracts.Services;
using Experion.Marina.Data.Services;
using Experion.Marina.Data.Services.Entities;
using Experion.Marina.Data.Services.Services;
using System.Configuration;
using System.Data.Entity;

namespace Experion.Marina.IocConfig
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterGeneralComponents(this ContainerBuilder builder)
        {
            builder.RegisterType<MasterDataHandler>().As<MasterDataHandler>();
            builder.RegisterType<MailKitEmailSender>().As<IEmailSender>();
            builder.RegisterType<EmailParameter>().As<EmailParameter>().SingleInstance();
            // builder.RegisterType<FccRequestParameter>().As<ISmsRequestParameter>().SingleInstance();
            // builder.RegisterType<FccSmsProvider>().As<ISmsSender>();
        }

        /// <summary>
        /// Registers the business services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void RegisterBusinessServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>().As<ISampleService>();
            builder.RegisterType<DirectoryService>().As<IDirectoryService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<SelectDirectoryName>().As<ISelectDirectoryName>();

        }

        /// <summary>
        /// Registers the data services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void RegisterDataServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SampleDataService>().As<ISampleDataService>();
            builder.RegisterType<DirectoryDataService>().As<IDirectoryDataService>();
            builder.RegisterType<UserDataService>().As<IUserDataService>();
            builder.RegisterType<ContactDataService>().As<IContactDataService>();


        }

        /// <summary>
        /// Registers the entities.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void RegisterEntities(this ContainerBuilder builder)
        {
            builder.RegisterType<SampleEntity>().As<ISampleEntity>();
            builder.RegisterType<Directory>().As<IDirectory>();
            builder.RegisterType<ValidUser>().As<IValidUser>();
            builder.RegisterType<UserCredential>().As<IUserCredential>();
            builder.RegisterType<Contact>().As<IContact>();

        }

        /// <summary>
        /// Registers the database components.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void RegisterDbComponents(this ContainerBuilder builder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TelephoneDirectoryDb"].ConnectionString;
            builder.RegisterType<MarinaContext>().As<DbContext>().WithParameter("connectionString", connectionString).SingleInstance();

            // Registering repository & database connection string
            builder.RegisterType<MarinaRepositoryContext>().As<IRepositoryContext>()
                .WithParameter("connectionString", connectionString);
        }
    }
}
