namespace FusionAPI.Handlers
{
    public  interface IFusionBaseModel
    {
        MongoDB.Bson.ObjectId _id { get; set; }
        string TransactionId { get; set; }
    }
}