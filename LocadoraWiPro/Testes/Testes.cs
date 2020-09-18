using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Database;
using System;
using System.Linq;

namespace Testes
{
    [TestClass]
    public class UnitTest
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }

        [TestInitialize]
        public void Initialize()
        {
            Services = new ServiceCollection();

            Services.AddDbContext<LocacaoDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));

            ServiceProvider = Services.BuildServiceProvider();
        }
        [TestMethod]
        public void TesteTabelaCliente()
        {
            using (var dbContext = ServiceProvider.GetService<LocacaoDbContext>())
            {
                var quantidadeAntesDeInserir = dbContext.Clientes.Count();

                dbContext.Clientes.Add(new Cliente()
                {
                    Nome = "Gerson",
                    CPF = "33300068800"
                });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.Clientes.Count() > quantidadeAntesDeInserir);
            }
        }
        [TestMethod]
        public void TesteTabelaFilme()
        {
            using (var dbContext = ServiceProvider.GetService<LocacaoDbContext>())
            {
                var quantidadeAntesDeInserir = dbContext.Filmes.Count();

                dbContext.Filmes.Add(new Filme()
                {
                    FilmeId = 1,
                    Nome = "A Culpa é das Estrelas",
                    CodigoEan = "98745632156"
                });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.Filmes.Count() > quantidadeAntesDeInserir);
            }
        }
        [TestMethod]
        public void TesteTabelaLocacao()
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = 15,
                Nome = "Gerson",
                CPF = "33300068800"
            };
            Filme filme = new Filme()
            {
                FilmeId = 15,
                Nome = "A Culpa é das Estrelas",
                CodigoEan = "98745632156"
            };
            Locacao locacao = new Locacao()
            {
                LocacaoId = 1,
                Cliente = cliente,
                ClienteId = cliente.ClienteId,
                Filme = filme,
                FilmeId = filme.FilmeId,
                DataLocacao = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(2)
            };

            using (var dbContext = ServiceProvider.GetService<LocacaoDbContext>())
            {
               var quantidadeAntesDeInserir = dbContext.Locacacoes.Count();
                dbContext.Locacacoes.Add(locacao);
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.Locacacoes.Count() > quantidadeAntesDeInserir);
            }
        }

    }
}
