﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using ShopDAL;

namespace ShopDALTest
{
    public class ClothingRepositoryFake : IClothingRepository
    {
        public List<Clothing> clothingFakeList;

        public ClothingRepositoryFake()
        {
            clothingFakeList = new List<Clothing>();

            //add 1 clothing
            Clothing clothingToTest = new Clothing { Id = 1, Name = "Test", BrandId = 1, CategoryId = 2, GenderId = 4 };
            clothingToTest.Clothing_Category = new Clothing_Category { Id = 2, Name = "testCategory" };
            clothingToTest.Clothing_Brand = new Clothing_Brand { Id = 1, Name = "testBrand" };
            clothingToTest.Clothing_Gender = new Clothing_Gender { Id = 4, Name = "testGender" };

            //add to fake repo
            clothingFakeList.Add(clothingToTest);
        }

        public IEnumerable<Clothing> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clothing> GetAllWithChildren(IEnumerable<string> children)
        {
            throw new NotImplementedException();
        }

        public Clothing Get(int key)
        {
            return clothingFakeList.SingleOrDefault(item => item.Id == key);
        }

        public Clothing GetWithChildren(Clothing entity, IEnumerable<string> children)
        {
            throw new NotImplementedException();
        }

        public void Insert(Clothing entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Clothing entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}