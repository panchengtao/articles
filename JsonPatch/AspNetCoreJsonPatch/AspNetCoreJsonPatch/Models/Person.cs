using MongoDB.Bson;

namespace AspNetCoreJsonPatch.Models
{
    public class Person : IEntity<ObjectId>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public ObjectId Id { get; set; }
    }
}