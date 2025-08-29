using API.Models;
using API.Entities;

namespace API.Models.Converters
{
    public static class UserConvert
    {
        public static UserEntity UserRequestToEntity(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return null;
            }

            var entity = new UserEntity
            {
                Nome = userRequest.Nome,
                Sobrenome = userRequest.Sobrenome,
                Cpf = userRequest.Cpf,
                DataNascimento = userRequest.DataNascimento,
            };
            return entity;
        }

        public static UserRequest UserEntityToRequest(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }

            var request = new UserRequest
            {
                Nome = userEntity.Nome,
                Sobrenome = userEntity.Sobrenome,
                Cpf = userEntity.Cpf,
                DataNascimento = userEntity.DataNascimento,
            };

            return request;
        }

        public static List<UserRequest> UserEntitytoRequestList(List<UserEntity> userEntities)
        {
            return userEntities.Select(UserEntityToRequest).ToList();
        }

        public static List<UserEntity> UserRequesttoEntityList(List<UserRequest> userRequests)
        {
            return userRequests.Select(UserRequestToEntity).ToList();
        }


    }
}
