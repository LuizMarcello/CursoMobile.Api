using CursoMobile.Api.Domain.Entities;
using CursoMobile.Api.Domain.Interfaces;
using CursoMobile.Api.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoMobile.Api.Infra.Data.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        //O contexto:
        private readonly MongoContext<User> context;

        //Construtor/Injeção de dependências
        public UserRepository(IMongoDatabase database) =>
            context = new MongoContext<User>(database, "user");

        //Deletando um usuário:
        public async void DeleteByIdAsync(string id) =>
            await context.Collection.DeleteOneAsync(d => d.Id == id);

        //Recuperando todos os usuários do banco de dados:
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await context.Collection.AsQueryable().ToListAsync();

        //Recuperando um uuário específico:
        public async Task<User> GetByIdAsync(string id) =>
           (await context.Collection.FindAsync(f => f.Id == id)).FirstOrDefault();

        //Inserindo um novo usuário:
        public async Task<User> InsertAsync(User user)
        {
            await context.Collection.InsertOneAsync(user);
            return user;
        }

        //Atualizando um usuário:
        public async Task<User> UpdateAsync(User user) =>
            await context.Collection.FindOneAndReplaceAsync(new BsonDocument("_id", user.Id), user);

       
    }
}





