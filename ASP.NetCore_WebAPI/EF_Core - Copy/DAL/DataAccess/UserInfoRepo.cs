using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class UserInfoRepo : IUserInfoRepo<UserInfo>
    {
        public UserInfo GetUserByEmail(string emailId)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Users.Where(user => user.EmailId.Equals(emailId)).FirstOrDefault();
            }
        }

        public UserInfo UpdateUser(UserInfo user)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingUser = dbContext.Users.Where(u => u.EmailId.Equals(user.EmailId)).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.Password = user.Password;
                    existingUser.Role = user.Role;
                    dbContext.SaveChanges();
                    return existingUser;
                }
                return null;
            }
        }

        public UserInfo AddUser(UserInfo user)
        {
            using (var dbContext = new EventDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return user;
            }
        }

        public UserInfo DeleteUser(string emailId)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingUser = dbContext.Users.Where(user => user.EmailId.Equals(emailId)).FirstOrDefault();
                if (existingUser != null)
                {
                    dbContext.Users.Remove(existingUser);
                    dbContext.SaveChanges();
                    return existingUser;
                }
                return null;
            }
        }
        public UserInfo ValidateUser(string emailId, string password)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Users.FirstOrDefault(u => u.EmailId == emailId && u.Password == password);
            }
        }


        public List<UserInfo> GetAllUsers()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Users.ToList();
            }
        }
    }
}