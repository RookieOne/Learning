using Domain;
using Norm.Configuration;

namespace MapTests.Maps
{
    public class CustomerMap : MongoConfigurationMap
    {
        public CustomerMap()
        {
            For<Customer>(x =>
                              {
                                  x.IdIs(c => c.Id);
                                  x.ForProperty(c => c.Name);
                              });
        }
    }
}