using System;
using System.Collections.Generic;
using System.Linq;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Scenario : EntityBase<Guid>
    {
        public string UriOne { get; }
        public string UriTwo { get; }
        public string UriThree { get; }

        public Scenario(Guid id, IEnumerable<Uri> loadtestSteps) : base(id)
        {
            var steps = loadtestSteps?.ToList();
            if (steps == null || !steps.Any())
                throw new ArgumentException("Loadtest scenario must have at least one valid URI.");

            UriOne = GetUri(steps, 0);
            UriTwo = GetUri(steps, 1);
            UriThree = GetUri(steps, 2);
        }

        private static string GetUri(IEnumerable<Uri> steps, int index)
        {
            var uri = steps.ElementAtOrDefault(index);
            return uri?.AbsoluteUri;
        }
    }
}
