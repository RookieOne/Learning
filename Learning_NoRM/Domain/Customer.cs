using System;

namespace Domain
{
    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}