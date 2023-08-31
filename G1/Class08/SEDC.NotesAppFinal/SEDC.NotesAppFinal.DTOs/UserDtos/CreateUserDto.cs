using SEDC.NotesAppFinal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        public string Username { get; set; } = string.Empty;

        public int Age { get; set; }

       



    }
}
