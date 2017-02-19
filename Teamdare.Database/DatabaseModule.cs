using Autofac;

namespace Teamdare.Database
{
    public class DatabaseModule : Module
    {
        private readonly string _connectionString;

        public DatabaseModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeamdareContext>().WithParameter("connectionString", _connectionString);
            //builder.Register((context, parameters) => new TeamdareContext(_connectionString));
        }
    }
}