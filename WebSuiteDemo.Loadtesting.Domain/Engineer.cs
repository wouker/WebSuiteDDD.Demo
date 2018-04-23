using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Engineer : EntityBase<Guid>
    {
        public string Name { get; }

        public Engineer(Guid id, string name) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
