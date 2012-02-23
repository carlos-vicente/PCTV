using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace PCTV.Input.Concrete
{
    public class DependencyModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IInputManager>().To<InputManager>().InSingletonScope();
        }
    }
}
