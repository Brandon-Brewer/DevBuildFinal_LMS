﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevBuildFinal_LMS.Services;
using DevBuildFinal_LMS.Models;

namespace DevBuildFinal_LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService userData;

        public UserController(IUserDataService userData)
        {
            this.userData = userData;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return userData.GetUsers();
        }

        [HttpGet("teachers")]
        public IEnumerable<User> GetTeachers()
        {
            return userData.GetTeachers();
        }

        [HttpGet("regular")]
        public IEnumerable<User> GetRegularUsers()
        {
            return userData.GetRegularUsers();
        }

        [HttpGet("names")]
        public IEnumerable<string> GetUsersNames()
        {
            return userData.GetUsersNames();
        }

        [HttpGet("name/{userName}")]
        public User GetUserByName(string userName)
        {
            return userData.GetUserByName(userName);
        }


        [HttpPost("add")]
        public Object AddUser(User user)
        {
            var result = userData.AddUser(user);

            return UpdateError(result);
        }

        [HttpPut("admin/change")]
        public Object ChangeAdminStatus(User user)
        {
            var result = userData.ChangeAdminStatus(user);

            return UpdateError(result);
        }
        
        public object UpdateError(int result)
        {
            if (result == 1)
            {
                return new { Success = true, Message = "Success" };
            }
            else
            {
                return new { Success = false, Message = "Error" };
            }
        }
    }
}