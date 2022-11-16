using kiteAutoInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiteAutoInjection.Test
{
    public class TransientDependencyTestClass : ITransientDependency
    {
        public Guid Id { get; set; }
        public TransientDependencyTestClass()
        {
            Id = Guid.NewGuid();
        }
    }


    public class ScopedDependencyTsetClass : IScopedDependency
    {
        public Guid Id { get; set; }
        public ScopedDependencyTsetClass()
        {
            Id = Guid.NewGuid();
        }
    }

    public class SingletonDependencyTsetClass : ISingletonDependency
    {
        public Guid Id { get; set; }
        public SingletonDependencyTsetClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
