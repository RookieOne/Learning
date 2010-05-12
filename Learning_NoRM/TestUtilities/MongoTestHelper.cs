using Norm;
using Norm.Linq;

namespace TestUtilities
{
    public static class MongoTestHelper
    {
        public static Mongo create_new_database_connection()
        {
            return new Mongo("test", "localhost", "27017", "");
        }

        public static MongoQueryProvider create_query_provider()
        {
            return new MongoQueryProvider(create_new_database_connection());
        }        
    }
}