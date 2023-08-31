using SEDC.NotesAppFinal.DataAccess.Interfaces;
using SEDC.NotesAppFinal.Domain.Models;
using SEDC.NotesAppFinal.DTOs.UserDtos;
using SEDC.NotesAppFinal.Services.Interfaces;
using SEDC.NotesAppFinal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            User userEntity = createUserDto.MapToUser();
            await _userRepository.CreateAsync(userEntity);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);


        }

        public async Task EditUserAsync(CreateUserDto createUserDto, int id)
        {
            User userDb = await _userRepository.GetByIdAsync(id);
            if (userDb == null)
            {
                throw new Exception("user not found");
            }
            userDb.FirstName = createUserDto.FirstName;
            userDb.LastName = createUserDto.LastName;
            userDb.Username = createUserDto.Username;
            userDb.Age = createUserDto.Age;

            await _userRepository.UpdateAsync(userDb);



        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllAsync();
                
            return users.Select(u => u.MapToUserDto()).ToList();
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
           User user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");

            }
            return user.MapToUserDto();

        }

        public Task GetUserAsync(int? id)
        {
            throw new NotImplementedException();
        }
    } 
}
