﻿using BLL.Interfaces;
using Models;
using OnlineFastFoodDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class UserLoginDao : UserLogin
    {
        public async Task<User> GetUserDetails(string UserID, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignUp(User user)
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    int UserID = _context.TblUsers.Max(x => (int?)x.UserId) ?? 0;
                    TblUser tbl = new TblUser();
                    tbl.UserId = UserID + 1;
                    tbl.UserName = user.UserName;
                    tbl.Password = user.Password;
                    tbl.AccountStatus = "Pending";
                    tbl.IsActive = true;
                    tbl.FullAddress = user.FullAddress;
                    tbl.FullName = user.FullName;
                    tbl.Image = user.Image;
                    tbl.PhoneNumber = user.PhoneNumber;
                    _context.TblUsers.Add(tbl);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
