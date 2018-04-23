using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Agent : EntityBase<Guid>
    {
        public Location Location { get; }

        public Agent(Guid id, string city, string country) : base(id)
        {
            Location = new Location(city, country);
        }
    }
}
