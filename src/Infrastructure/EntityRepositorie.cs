using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using src.Application.Dtos;

namespace src.Infrastructure
{
    public interface IEntityRepositorie
    {
        Task<Entity> GetEntityById(Guid id);
        Task<bool> RegisterEntity(Entity entity);
    }

    public sealed class EntityRepositorie : IEntityRepositorie
    {
        private readonly IAmazonDynamoDB _dynamo;

        public EntityRepositorie(IAmazonDynamoDB dynamo)
        {
            _dynamo = dynamo;
        }

        public async Task<Entity> GetEntityById([FromForm] Guid id)
        {
            var findEntity = new GetItemRequest
            {
                TableName = "DapperProject",
                Key = new Dictionary<string, AttributeValue>
                {
                    {"id", new AttributeValue { S = id.ToString()}}
                }
            };

            var response = await _dynamo.GetItemAsync(findEntity) ?? throw new InvalidOperationException("Entity not found");
            var itemAsDocument = Document.FromAttributeMap(response.Item);
            var json = itemAsDocument.ToJson();

            // Deserialize the JSON string into an Entity object
            var entity = JsonConvert.DeserializeObject<Entity>(json);

            return entity;
        }

        public async Task<bool> RegisterEntity(Entity entity)
        {
            Amazon.DynamoDBv2.DocumentModel.Document doc = new Amazon.DynamoDBv2.DocumentModel.Document
            {
                { "id", entity.Id },
                { "Name", entity.Name },
                { "Age", entity.age }
            };

            var registerEntity = new PutItemRequest
            {
                TableName = "DapperProject",
                Item = doc.ToAttributeMap()
            };
            var response = await _dynamo.PutItemAsync(registerEntity);
            return response.HttpStatusCode.Equals(HttpStatusCode.OK);
        }
    }
}