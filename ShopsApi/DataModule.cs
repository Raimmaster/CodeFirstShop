using Autofac;
using CodeFirstEmployee.contexts;

namespace ShopsApi
{
    public class DataModule : Module
    {
        private string _connectionString;

        public DataModule(string conStr)
        {
            this._connectionString = conStr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ShopContext(_connectionString)).As<ShopContext>().InstancePerRequest();
            base.Load(builder);
        }
    }
}