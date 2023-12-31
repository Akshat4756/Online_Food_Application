﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface UserLogin
    {
        public Task<User> GetUserDetails(string UserID, string Password);
        public Task<bool> SignUp(User user);
        Task<User> Login(string Username, string Password);
        Task<bool> checkUsername(string Username);
        Task<string> GetHashString(string Username);
        Task<List<Order>> GetAllOrders(int UserID);
        Task<List<OrderDetail>> GetAllOrderDetails(int OrderID);
        Task<User> GetUserByUsername(string Username);
        Task<String> GenerateOTP();
        Task<bool> UpdatePassword(int UserID,User user);
    }
}
