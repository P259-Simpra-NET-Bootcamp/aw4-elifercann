using Autofac;
using SimApi.Operation;
using SimApi.Operation.Dapper;
using SimApi.Service.CustomService;

namespace SimApi.Service.Autofac
{
    public class AutofacBussinesModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLogService>().As<IUserLogService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerLifetimeScope();

            builder.RegisterType<TransactionReportService>().As<ITransactionReportService>().InstancePerLifetimeScope();
            builder.RegisterType<DapperAccountService>().As<IDapperAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<DapperCategoryService>().As<IDapperCategoryService>().InstancePerLifetimeScope();

            builder.RegisterType<ScopedService>().InstancePerLifetimeScope();
            builder.RegisterType<TransientService>().InstancePerDependency();
            builder.RegisterType<SingletonService>().SingleInstance();
        }
        
    }
}
