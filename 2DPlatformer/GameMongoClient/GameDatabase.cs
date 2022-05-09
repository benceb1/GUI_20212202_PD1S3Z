using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer.GameMongoClient
{
    public class GameDatabase
    {
        public static string connString = "mongodb+srv://databaseuser:databaseuser@testcluster.hvqwh.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";

        public static PlayerModel CreatePlayer(PlayerModel model)
        {
            MongoClient dbClient = new MongoClient(connString);
            var db = dbClient.GetDatabase("GUI_GAME");
            db.GetCollection<PlayerModel>("Players").InsertOne(model);
            return model;
        }

        public static IList<PlayerModel> GetPlayers()
        {
            MongoClient dbClient = new MongoClient(connString);
            var db = dbClient.GetDatabase("GUI_GAME");
            var collection = db.GetCollection<PlayerModel>("Players").AsQueryable().ToList();
            return collection;
        }

        public static void SavePlayer(PlayerModel model)
        {
            MongoClient dbClient = new MongoClient(connString);
            var db = dbClient.GetDatabase("GUI_GAME");
            var players = db.GetCollection<PlayerModel>("Players");
            var filter = Builders<PlayerModel>.Filter.Eq(p => p.Id, model.Id);
            var update = Builders<PlayerModel>.Update
                .Set(p => p.Name, model.Name)
                .Set(p => p.Experience, model.Experience)
                .Set(p => p.Level, model.Level)
                .Set(p => p.CoinCounter, model.CoinCounter)
                .Set(p => p.SlimeKilled, model.SlimeKilled)
                .Set(p => p.Health, model.Health);
            players.UpdateOne(filter, update);
        }
    }
}
