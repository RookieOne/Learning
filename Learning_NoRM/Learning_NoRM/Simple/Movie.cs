using System;
using Norm;

namespace Learning_NoRM.Simple
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid();
        }

        [MongoIdentifier]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}