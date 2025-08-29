using API.Models;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserRequest> CreateUserRequest(UserRequest userRequest)
        {
            var user = new UserEntity
            {
                Nome = userRequest.Nome,
                Sobrenome = userRequest.Sobrenome,
                Cpf = userRequest.Cpf,
                DataNascimento = userRequest.DataNascimento
            };

             await _repository.CreateEntity(user);

            return userRequest;
        }

        public async Task<UserRequest> GetByIdUserRequest(int id)
        {
            var userEntity = await _repository.GetByIdEntity(id);

            if (userEntity == null)
            {
                return null;
            }

            var userRequest = new UserRequest
            {
                Nome = userEntity.Nome,
                Sobrenome = userEntity.Sobrenome,
                Cpf = userEntity.Cpf,
                DataNascimento = userEntity.DataNascimento
            };

            return userRequest;

        }

        public async Task<UserRequest> UpdateUserRequest(int id, UserRequest userRequest)
        {
            var userEntity = await _repository.GetByIdEntity(id);

            if(userEntity == null)
            {
                return null;
            }

            userEntity.Nome = userRequest.Nome;
            userEntity.Sobrenome = userRequest.Sobrenome;
            userEntity.Cpf = userRequest.Cpf;
            userEntity.DataNascimento = userRequest.DataNascimento;

            await _repository.UpdateEntity(userEntity);

            var userUpdateRequest = new UserRequest
            {
                Nome = userEntity.Nome,
                Sobrenome = userEntity.Sobrenome,
                Cpf = userEntity.Cpf,
                DataNascimento = userEntity.DataNascimento
            };

            return userUpdateRequest;           

        }

        public async Task<bool> DeleteUserRequest(int id)
        {
            var userEntity = await _repository.GetByIdEntity(id);

            if (userEntity == null)
            {
                return false;
            }

            await _repository.DeleteEntity(userEntity);
            return true;

        }

    }
}
