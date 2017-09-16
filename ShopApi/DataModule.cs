using Autofac;
using CodeFirstEmployee.contexts;

namespace ShopApi
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
            builder.Register(c => new ShopContext(_connectionString)).InstancePerRequest();
            base.Load(builder);
        }
    }
}