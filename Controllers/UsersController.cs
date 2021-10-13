using AccountManager.DataAccess;
using AccountManager.DataAccess.Models;
using AccountManager.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            return await _dataContext.AppUsers.ToListAsync();
        }

        [HttpPost]
        public  ActionResult<AppUser> CreateUser(CreateUserModel createUserModel){
            var user = new AppUser{
                Username = createUserModel.Username, //Ovo objasniti kad kreiramo usera zašto nema ime i prezime
                FirstName = "Haris",
                LastName = "Begić"
            };
            _dataContext.AppUsers.Add(user);
            _dataContext.SaveChanges();
            return Ok(user);
        }
    }
}