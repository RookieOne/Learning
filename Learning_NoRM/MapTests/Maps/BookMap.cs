using Domain;
using Norm.Configuration;

namespace MapTests.Maps
{
    public class BookMap : MongoConfigurationMap
    {
        public BookMap()
        {
            For<Book>(c =>
                          {
                              c.IdIs(b => b.Id);
                              c.ForProperty(b => b.Title);
                              c.ForProperty(b => b.Author);
                          });            
        }
    }
}