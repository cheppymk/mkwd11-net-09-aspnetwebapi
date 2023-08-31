using SEDC.NotesAppFinal.DTOs.NoteDTOs;
using SEDC.NotesAppFinal.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);

        Task<List<UserDto>> GetAllUsersAsync();

        Task CreateUserAsync(CreateUserDto createUserDto);

        Task DeleteUserAsync(int id);

        Task EditUserAsync(CreateUserDto createUserDto, int id);
        
    }
}
