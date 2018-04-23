using System;
using WebSuiteDDD.SharedKernel;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Customer : EntityBase<Guid>
    {
        private string _name;
        public string Name
        {
            get => _name;
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Customer name");
                _name = value; }
        }

        public Customer(Guid id, string name) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
