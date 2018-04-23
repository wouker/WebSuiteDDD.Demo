using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Description: ValueObjectBase<Description>
    {
        public string ShortDescription { get; }
        public string LongDescription { get; }

        public Description(string shortDescription, string longDescription)
        {
            ShortDescription = shortDescription ?? throw new ArgumentNullException(nameof(shortDescription));
            LongDescription = longDescription ?? throw new ArgumentNullException(nameof(longDescription));
        }

        public Description WithShortDescription(string shortDescription)
        {
            return new Description(shortDescription, LongDescription);
        }

        public Description WithLongDescription(string longDescription)
        {
            return new Description(ShortDescription, longDescription);
        }

        public override bool Equals(Description other)
        {
            if (other == null) return false;
            return ShortDescription.Equals(other.ShortDescription, StringComparison.InvariantCultureIgnoreCase)
                   && LongDescription.Equals(other.LongDescription, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Description)) return false;
            return Equals((Description) obj);
        }

        public override int GetHashCode()
        {
            return LongDescription.GetHashCode() + ShortDescription.GetHashCode();
        }
    }
}
