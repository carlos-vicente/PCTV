using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCTV.ExternalInput.Service;
using Ninject.Modules;

namespace PCTV.ExternalInput
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExternalInput>().To<ExternalInputService>().InSingletonScope();
        }
    }
}
