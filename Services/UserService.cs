using API.Models;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Models.Converters;

namespace API.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserRequest>> GetUsersRequest()
        {
            var users = await _repository.GetUsersAsync();

            var usersRequest = UserConvert.UserEntitytoRequestList(users);
            return usersRequest;
        }


        public async Task<UserRequest> GetByIdUserRequest(int id)
        {
            var userEntity = await _repository.GetByIdEntity(id);

            if (userEntity == null)
            {
                return null;
            }

            var user = UserConvert.UserEntityToRequest(userEntity);
            
            return user;

        }

        public async Task<bool> CreateUserRequest(UserRequest userRequest)
        {
            var user = UserConvert.UserRequestToEntity(userRequest);

            await _repository.CreateEntity(user);

            return true;
        }

        public async Task<UserRequest> UpdateUserRequest(int id, UserRequest userRequest)
        {
            var userEntity = await _repository.GetByIdEntity(id);

            if (userEntity == null)
            {
                return null;            }

           
            userEntity.Nome = userRequest.Nome;
            userEntity.Sobrenome = userRequest.Sobrenome;
            userEntity.Cpf = userRequest.Cpf;
            userEntity.DataNascimento = userRequest.DataNascimento;

            await _repository.UpdateEntity(userEntity);

            var userUpdateRequest = UserConvert.UserEntityToRequest(userEntity);
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
