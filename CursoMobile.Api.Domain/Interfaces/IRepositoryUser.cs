using CursoMobile.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoMobile.Api.Domain.Interfaces
{
    //Essa interface é um contrato para o repositório "UserRepository".
    public interface IRepositoryUser
    {
        //Recuperando todos os usuários do banco de dados:
        Task<IEnumerable<User>> GetAllAsync();

        //Recuperando um uuário específico:
        Task<User> GetByIdAsync(string id);

        //Inserindo um novo usuário:
        Task<User> InsertAsync(User user);

        //Atualizando um usuário:
        Task<User> UpdateAsync(User user);

        //Deletando um usuário:
        void DeleteByIdAsync(string id);
    }
}
