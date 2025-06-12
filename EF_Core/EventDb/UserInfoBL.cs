using System;
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace EventDb
{
    public class UserInfoBL
    {
        private readonly IUserInfoRepo<UserInfo> _userRepo;

        public UserInfoBL(IUserInfoRepo<UserInfo> userRepo)
        {
            this._userRepo = userRepo;
        }

        public List<UserInfo> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public UserInfo GetUserByEmail(string emailId)
        {
            if (string.IsNullOrWhiteSpace(emailId))
                throw new ArgumentException("Email cannot be empty.");

            return _userRepo.GetUserByEmail(emailId);
        }

        public UserInfo AddUser(UserInfo user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.EmailId) ||
                string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.Role))
            {
                throw new ArgumentException("All user fields are required.");
            }

            return _userRepo.AddUser(user);
        }

        public UserInfo UpdateUser(UserInfo user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.EmailId))
                throw new ArgumentException("Valid user object is required.");

            return _userRepo.UpdateUser(user);
        }

        public UserInfo DeleteUser(string emailId)
        {
            if (string.IsNullOrWhiteSpace(emailId))
                throw new ArgumentException("Email cannot be empty.");

            return _userRepo.DeleteUser(emailId);
        }
    }
}
