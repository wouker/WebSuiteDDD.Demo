using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class LoadtestType : EntityBase<Guid>
    {
        public Description Description { get; }

        public LoadtestType(Guid guid, string shortDescription, string longDescription) 
            : base(guid)
        {
            Description = new Description(shortDescription, longDescription);
        }
    }
}
