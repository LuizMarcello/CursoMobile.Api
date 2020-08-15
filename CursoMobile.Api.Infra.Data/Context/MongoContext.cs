using CursoMobile.Api.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoMobile.Api.Infra.Data.Context
{
    //Essa classe é do tipo "Generics"(<T>), e vai receber uma classe do tipo
    //"CursoMobile.Api.Domain.Entities.BaseEntity(abstrata)", como parâmetro.
    public class MongoContext<T> where T : BaseEntity
    {
        private readonly IMongoDatabase _database;
        private readonly string _collection;

        //Injeção de dependência:
        public MongoContext(IMongoDatabase database, string collection)
        {
            _database = database;
            _collection = collection;
        }

        //Recuperando a nossa classe de acôrdo o nome da nossa collection e tipando ela
        //com o tipo da classe que estamos passando como parâmetro para esta nossa classe
        //genérica.
        public IMongoCollection<T> Collection => 
            _database.GetCollection<T>(_collection);
    }
}



