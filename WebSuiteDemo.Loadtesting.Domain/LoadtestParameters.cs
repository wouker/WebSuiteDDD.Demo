using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class LoadtestParameters : ValueObjectBase<LoadtestParameters>
    {
        public DateTime StartDateUtc { get; private set; }
        public DateTime EndDateUtc => StartDateUtc.AddSeconds(DurationSec);
        public int UserCount { get; private set; }
        public int DurationSec { get; private set; }

        private LoadtestParameters() { }

        public LoadtestParameters(DateTime startDateUtc, int userCount, int durationSec)
        {
            if(userCount < 1) throw new ArgumentException("User count cannot be less than 1.");
            if(durationSec < 30) throw new ArgumentException("Test duration cannot be less than 30 seconds.");
            if(durationSec > 3600) throw new ArgumentException("Test duration cannot be more than 1 hour (=3600 seconds)");

            StartDateUtc = startDateUtc < DateTime.UtcNow ? DateTime.UtcNow : startDateUtc;
            UserCount = userCount;
            DurationSec = durationSec;
        }

        public LoadtestParameters WithStartDateUtc(DateTime newStartDateUtc)
        {
            return new LoadtestParameters(newStartDateUtc, UserCount, DurationSec);
        }

        public LoadtestParameters WithUserCount(int newUserCount)
        {
            return new LoadtestParameters(StartDateUtc, newUserCount, DurationSec);
        }

        public LoadtestParameters WithDuration(int newDurationSec)
        {
            return new LoadtestParameters(StartDateUtc, UserCount, newDurationSec);
        }

        public override bool Equals(LoadtestParameters other)
        {
            if (other == null) return false;
            return other.StartDateUtc == StartDateUtc && other.UserCount ==
                UserCount && other.DurationSec == DurationSec;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is LoadtestParameters)) return false;
            return Equals((LoadtestParameters) obj);
        }

        public override int GetHashCode()
        {
            return DurationSec.GetHashCode() + StartDateUtc.GetHashCode() + UserCount.GetHashCode();
        }
    }
}
