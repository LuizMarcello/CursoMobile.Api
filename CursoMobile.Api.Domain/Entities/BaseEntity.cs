using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoMobile.Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        //Para que um método comum (não
        //abstrato) possa ser sobreposto, deve
        //ser incluído nele o prefixo "virtual"
        public virtual string Id { get; set; }
    }
}
