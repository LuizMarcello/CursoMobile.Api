using AutoMapper;
using CursoMobile.Api.Domain.DTO;
using CursoMobile.Api.Domain.Entities;
using CursoMobile.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoMobile.Api.Service.Services
{
    public class UserService : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper;

        public UserService(IRepositoryUser repositoryUser, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public async Task<UserDto> Add(UserDto userDtoo)
        {
            var user = _mapper.Map<User>(userDtoo);

            user = await _repositoryUser.InsertAsync(user);

            userDtoo = _mapper.Map<UserDto>(user);

            return userDtoo;
        }
        public void Delete(string id) =>
            _repositoryUser.DeleteByIdAsync(id);

        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _repositoryUser.GetAllAsync();

            var usersDto = users.Select(s => _mapper.Map<UserDto>(s));
            return usersDto; ;

        }
    }
}


       






