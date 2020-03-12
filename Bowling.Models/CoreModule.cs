using System;
using Ninject.Modules;

namespace Bowling.Models
{
    public class CoreModule:NinjectModule
    {
        public CoreModule()
        {
        }

        public override void Load()
        {
            Bind<IGame>().To<Game>();
            Bind<IDataProvider>().To<StringDataProvider>();
        }
    }
}
