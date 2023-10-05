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
    public class HomePageDao : HomePageDAO
    {
        public async Task<List<FoodType>> GetAllFoodTypes()
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<FoodType> list = new List<FoodType>();
                    list = _context.TblFoodTypes.Where(x => x.IsActive == true).Select(
                        x => new FoodType()
                        {
                            FoodTypeId = x.FoodTypeId,
                            FoodTypeImg = x.FoodTypeImg,
                            FoodTypeName = x.FoodType,
                            IsActive = x.IsActive,
                            FoodTypeDesc = x.FoodTypeDesc,
                            //SubCatid = (int)x.SubCatid,
                            //SubCategoryName = x.SubCat.SubCatName,
                            //CatId = x.CatId,
                            //CategoryName = x.Cat.CatName
                        }
                        ).ToList();
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Category>> GetCategoriesForHomepage()
        {
           await using (var _Context=new Online_Food_ApplicationContext())
            {
                List<Category> listCat= _Context.TblCategories.Where(x=>x.ShowOnHomepage==true&&x.IsActive==true).Select(x => new Category()
                {
                    CatName = x.CatName,
                    CatId = x.CatId,
                    CatDesc = x.CatDesc,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage

                }).Take(3).OrderBy(x=>x.CatId).ToList();
                return listCat;
            }
        }
       

        public async Task<List<Food>> GetFoodsForHomepage()
        {
            await using (var _context = new Online_Food_ApplicationContext())
            {
                List<Food> list = _context.TblFoods.Where(x => x.IsActive == true).Select(x => new Food
                {
                    FoodId = x.FoodId,
                    FoodName = x.FoodName,
                    FoodDesc = x.FoodDesc,
                    FoodAmount = x.FoodAmount,
                    Quantity = (int)(x.Quantity),
                    FoodTypeId = x.FoodTypeId,
                    FoodTypeName = x.FoodType.FoodType,
                    SubCatId = x.SubCatId,
                    SubCategoryName = x.SubCat.SubCatName,
                    CatId = x.CatId,
                    CategoryName = x.Cat.CatName,
                    IsActive = x.IsActive,
                    BannerImage = x.BannerImage,
                    IconImage = x.IconImage,
                    ShowOnHomePage = x.ShowOnHomePage
                }
                    ).Take(3).OrderBy(x=>x.FoodId).ToList();
                return list;
            }
        }
        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                await using (var _context = new Online_Food_ApplicationContext())
                {
                    List<Category> listCat = _context.TblCategories.Where(x => x.IsActive == true).Select(x => new Category()
                    {
                        CatName = x.CatName,
                        CatId = x.CatId,
                        CatDesc = x.CatDesc,
                        BannerImage = x.BannerImage,
                        IconImage = x.IconImage

                    }).ToList();
                    return listCat;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<List<FoodType>> GetFoodTypeForHomePage()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> GetSubCategoriesForHomePage(int _catId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Food>> GetTopRatingFood()
        {
            throw new NotImplementedException();
        }
    }
}
