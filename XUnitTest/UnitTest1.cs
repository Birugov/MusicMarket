using BozheHvatitDushit_Sharp.Models;
using BozheHvatitDushit_Sharp.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Tests
{
    public class UnitTest1
    {
        public interface IRepository
        {
            IEnumerable<Category> GetAll();
            Category Get(int id);
            void Create(Category category);
        }

        [Test]
        public void GetAllCommentsTest()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo=>repo.GetAll()).Returns(GetCategoryList);
            var category = mock.Object.GetAll();
            Assert.AreEqual(3, category.Count());
        }
        [Test]
        public void GetCategoryById()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetCategoryList());
            var category = mock.Object.GetAll().FirstOrDefault(p => p.id==1);
            Assert.AreEqual(1, category.id);
        }
        private List<Category> GetCategoryList()
        {
            return new List<Category>()
            {
                new Category() { id = 1 },
                new Category() { id = 2 },
                new Category() { id = 3 }
            };
        }
    }
}
