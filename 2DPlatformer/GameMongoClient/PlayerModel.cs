using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer.GameMongoClient
{
    public class PlayerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int CoinCounter { get; set; }
        public int SlimeKilled { get; set; }
        public int Health { get; set; }
    }
}
