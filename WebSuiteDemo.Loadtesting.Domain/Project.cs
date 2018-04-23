using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Project : EntityBase<Guid>
    {
        public Description Description { get; }

        public Project(Guid id, string shortDescription, string longDescription) : base(id)
        {
            Description = new Description(shortDescription, longDescription);
        }
    }
}
