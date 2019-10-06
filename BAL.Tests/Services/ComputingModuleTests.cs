using AutoMapper;
using Interface.InterfacesDAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BAL.Services;

namespace BAL.Tests.Services
{
    public class ComputingModuleTests
    {
        protected static Mock<IUnitOfWork> _mockUnitOfWork;
        protected static Mock<IMapper> _mockMapper;
        protected ComputingModule _computingModule;

        [SetUp]
        protected void Initialize()
        {
            _computingModule = new ComputingModule();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            TestContext.WriteLine("Initialize test data");
        }

        [TearDown]
        protected void Cleanup()
        {
            TestContext.WriteLine("Cleanup test data");
        }


        [Test]
        [TestCase("4")]
        [TestCase("5,2")]
        public void IsDouble_Success_Result_True(string s)
        {
            var result = _computingModule.IsDouble(s);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("5.2")]
        [TestCase("test")]
        public void IsDouble_Success_Result_False(string s)
        {
            var result = _computingModule.IsDouble(s);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("+", 4, 4, ExpectedResult = 8)]
        [TestCase("-", 4, 2, ExpectedResult = 2)]
        [TestCase("*", 4, 2, ExpectedResult = 8)]
        [TestCase("/", 4, 2, ExpectedResult = 2)]
        [TestCase("%", 5, 2, ExpectedResult = 1)]
        [TestCase("pow", 4, 2, ExpectedResult = 16)]
        [TestCase("sqrt", 16, ExpectedResult = 4)]
        [TestCase("nsqrt", 3, 27, ExpectedResult = 3)]
        [TestCase("(", 3, ExpectedResult = 3)]
        public double ActionMath_Success_Result(string fun, int a, int b = 0)
        {
            var result = _computingModule.ActionMath(fun, a, b);
            return result;
        }
        

    }
}
