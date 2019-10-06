using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Interface.InterfacesDAL;
using Moq;
using NUnit.Framework;

namespace BAL.Tests.Managers
{
    public class ComputingManagerTests
    {
        protected static Mock<IUnitOfWork> _mockUnitOfWork;
        protected static Mock<IMapper> _mockMapper;

        [SetUp]
        protected void Initialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            TestContext.WriteLine("Initialize test data");
        }

        [TearDown]
        protected void Cleanup()
        {
            TestContext.WriteLine("Cleanup test data");
        }

        
    }
}
