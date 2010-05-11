using Norm;

namespace Learning_NoRM
{
    public static class MongoTestHelper
    {
        public static Mongo create_new_database_connection()
        {
            return new Mongo("test", "localhost", "27017", "");
        }
    }
}