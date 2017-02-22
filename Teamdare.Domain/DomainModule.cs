using System.Collections.Generic;
using Autofac;
using Microsoft.Bot.Connector;
using Teamdare.Core.Commands;
using Teamdare.Core.Events;
using Teamdare.Core.Queries;
using Teamdare.Domain.DecisionTree;
using Teamdare.Domain.DecisionTree.Base;
using Teamdare.Domain.DecisionTree.Queries;
using Teamdare.Domain.NLP;

namespace Teamdare.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<ICommand>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<IEvent>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<IQuery>())
                .AsImplementedInterfaces();

            builder.RegisterType<CheckIfMessageIsEmpty>().As<DecisionQuery<Activity, IEnumerable<Activity>>>();

            builder.RegisterType<NLPProcessor>().As<NLPProcessor>();

            builder.RegisterType<DecisionTreeHead>().As<DecisionTreeHead>();
        }
    }
}