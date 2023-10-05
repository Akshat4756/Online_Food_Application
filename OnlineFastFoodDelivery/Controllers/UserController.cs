﻿using BLL.Implementation;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Http;
using BLL.Interfaces;
using OnlineFastFoodDelivery.Utilites;
using System.Reflection;

namespace OnlineFastFoodDelivery.Controllers
{
    public class UserController : Controller
    {

        //public IFormFile imageFile { get; set; }//this is necessary to accept a file or get a file through httpcontext
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        UserLogin DAL= new UserLoginDao();
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(string Username, string Password)
        {
            return View();
        }
        public IActionResult UserSignUp()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> UserSignUp(User user)
       {
            try
            {

                if (HttpContext.Request.Form.Files.Count > 0) 
                {
                    user.imageFile = HttpContext.Request.Form.Files[0];
                    if (user.imageFile != null)
                    {
                        var extension = Path.GetExtension(user.imageFile.FileName);
                        if (ImageExtensions.Contains(extension.ToUpperInvariant()))
                        {
                            NecessaryFunctions nec = new NecessaryFunctions();
                            user.Image = nec.ImageSave(user.Image, user.imageFile);
                        }
                    }
                }
                
                
                bool isSuccess = false;
                isSuccess = await DAL.SignUp(user);
                if (isSuccess)
                {
                    TempData["Success"] = "Registered Successfully ! Please Login";
                    
                    return RedirectToAction("Index","Home");   
                }
                else
                {
                    TempData["Error"] = "Registration Failed"; 
                    return View();
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        
    }
}
