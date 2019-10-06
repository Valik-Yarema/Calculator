using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BAL.Managers;
using Interface.InterfacesDAL;
using Model.DB;
using Moq;
using NUnit.Framework;

namespace BAL.Tests.Managers
{
    public class ComputingManagerTests
    {
        protected static Mock<IUnitOfWork> _mockUnitOfWork;
        protected static Mock<IMapper> _mockMapper;
        protected ComputingManager _computingManager;
        [SetUp]
        protected void Initialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _computingManager =new ComputingManager(_mockUnitOfWork.Object, _mockMapper.Object);
            

            TestContext.WriteLine("Initialize test data");
        }

        [Test]
        public void Delete_Success_Null_ID()
        {
            
           _mockUnitOfWork.Setup(u => u.ComputingsRepository.GetById(new Guid())).ReturnsAsync((Computing) null);

           Assert.That(async () => { await _computingManager.Delete(new Guid()); }, Throws.Nothing);
        }

        [Test]
        public void Delete_Success_Result()
        {

            _mockUnitOfWork.Setup(u => u.ComputingsRepository.GetById(new Guid())).ReturnsAsync((Computing)null);

            Assert.That(async () => { await _computingManager.Delete(new Guid()); }, Throws.Nothing);
        }



    }
}
