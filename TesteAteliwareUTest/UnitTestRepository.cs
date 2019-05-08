using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PortalTest.Controllers;
using PortalTest.Data;
using PortalTest.Infrastructure;
using PortalTest.Interface;
using PortalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Listar()
        {
            Mock<IGitRepositorieRepository> mock = new Mock<IGitRepositorieRepository>();
            List<GitRepositorie> lista = new List<GitRepositorie>();
            mock.Setup(m => m.Listar()).ReturnsAsync(lista);
            Assert.AreEqual(0, lista.Count);
        }

        [Test]
        public void Salvar()
        {
            Mock<IGitRepositorieRepository> mock = new Mock<IGitRepositorieRepository>();
            List<GitRepositorie> listinha = new List<GitRepositorie>();
            var model = new GitRepositorie();
            mock.Setup(m => m.Salvar(It.IsAny<GitRepositorie>()));
            Assert.Pass();
        }

        [Test]
        public void ListarById()
        {
            Mock<IGitRepositorieRepository> mock = new Mock<IGitRepositorieRepository>();
            GitRepositorie model = new GitRepositorie();
            mock.Setup(m => m.ListarById(It.IsAny<long>())).ReturnsAsync(model);
            Assert.IsNotNull(model);
        }


    }
}