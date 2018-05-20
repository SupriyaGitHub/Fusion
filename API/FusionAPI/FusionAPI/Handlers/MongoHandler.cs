using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FusionAPI.Handlers
{
    public class MongoHandler
    {

        public List<T> GetAllItems<T>(string collectionName)
        {
            var mongoClient = new MongoClient();

            IMongoDatabase db = mongoClient.GetDatabase("MyMongoDB");

            var itemCollection = db.GetCollection<T>(collectionName);

            var documents = itemCollection.Find<T>(FilterDefinition<T>.Empty);

            var jsonDocument = documents.ToList();
            
            return jsonDocument;
        }

        public T GetItemsId<T>(string id, string collectionName) where T : IFusionBaseModel
        {
            var mongoClient = new MongoClient();
            IMongoDatabase db = mongoClient.GetDatabase("MyMongoDB");

            var itemCollection = db.GetCollection<T>(collectionName);
            var documents = itemCollection.Find<T>(e => e.TransactionId == id);
            var jsonDocument = documents.ToList();

            return jsonDocument.FirstOrDefault();
        }

        public bool DeleteByTransactionId<T>(string id, string collectionName) where T : IFusionBaseModel
        {
            var mongoClient = new MongoClient();
            IMongoDatabase db = mongoClient.GetDatabase("MyMongoDB");

            var itemCollection = db.GetCollection<T>(collectionName);
            var documents = itemCollection.FindOneAndDelete<T>(e => e.TransactionId == id);

            return true;
        }

        public bool Update<T>(T item,string collectionName) where T : IFusionBaseModel
        {
            var mongoClient = new MongoClient();
            IMongoDatabase db = mongoClient.GetDatabase("MyMongoDB");
            var itemCollection = db.GetCollection<T>("inventory");
            var documents = itemCollection.Find<T>(e => e.TransactionId == item.TransactionId);

            foreach (var document in documents.ToList<T>())
            {
                item._id = document._id;
                break;
            }

            itemCollection.FindOneAndReplace<T>(e => e.TransactionId == item.TransactionId, item);

            return true;
        }

        public bool Insert<T>(T item, string collectionName) where T : IFusionBaseModel
        {
            var mongoClient = new MongoClient();
            IMongoDatabase db = mongoClient.GetDatabase("MyMongoDB");
            var itemCollection = db.GetCollection<T>(collectionName);
            itemCollection.InsertOne(item);

            return true;
        }

    }
}
