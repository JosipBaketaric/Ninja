using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ninja.Repository.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {

        /*

        [TestMethod]
        public void TestMethodAddFromUnitOfWork()
        {
            //Arange
            var dbSet = new Mock<DbSet<Clan>>();
            dbSet.Setup(x => x.Add(It.IsAny<Clan>())).Returns((Clan c) => c);

            var ninjaContextMock = new Mock<NinjaContext>();
            ninjaContextMock.Setup(x => x.Clans.Add(It.IsAny<Clan>())).Returns((Clan c) => c);
            ninjaContextMock.Setup(x => x.Set<Clan>()).Returns(dbSet.Object);

            var clan = new Clan() { Id = 1, Name = "da" };

            var clanRepo = new ClansRepository(ninjaContextMock.Object);
            var equipmentRepo = new EquipmentRepository(ninjaContextMock.Object);
            var ninjasRepo = new NinjasRepository(ninjaContextMock.Object);
            var unitOfWork = new UnitOfWork.UnitOfWork(ninjaContextMock.Object, clanRepo, equipmentRepo, ninjasRepo);

            unitOfWork.Clans.Add(clan);

            //Assert
            dbSet.Verify(x => x.Add(It.Is<Clan>(u => u.Id == 1)), Times.Once);
        }



        [TestMethod]
        public void TestMethodGetFromUnitOfWork()
        {
            //Arange
            var clan = new Clan() { Id = 1, Name = "da" };

            var dbSet = new Mock<DbSet<Clan>>();
            dbSet.Setup(x => x.Find(It.IsAny<int>())).Returns((Clan)clan);

            var ninjaContextMock = new Mock<NinjaContext>();
            ninjaContextMock.Setup(x => x.Clans.Find(It.IsAny<int>())).Returns((Clan c) => c);
            ninjaContextMock.Setup(x => x.Set<Clan>()).Returns(dbSet.Object);



            var clanRepo = new ClansRepository(ninjaContextMock.Object);
            var equipmentRepo = new EquipmentRepository(ninjaContextMock.Object);
            var ninjasRepo = new NinjasRepository(ninjaContextMock.Object);
            var unitOfWork = new UnitOfWork.UnitOfWork(ninjaContextMock.Object, clanRepo, equipmentRepo, ninjasRepo);

            var result = unitOfWork.Clans.Get(1);

            //Assert
            Assert.AreEqual(clan, result);
        }




        [TestMethod]
        public void TestSave()
        {
            //Arange
            var dbSet = new Mock<DbSet<Clan>>();
            dbSet.Setup(x => x.Add(It.IsAny<Clan>())).Returns((Clan c) => c);

            var ninjaContextMock = new Mock<NinjaContext>();
            ninjaContextMock.Setup(x => x.Clans.Add(It.IsAny<Clan>())).Returns((Clan c) => c);
            ninjaContextMock.Setup(x => x.Set<Clan>()).Returns(dbSet.Object);

            var clan = new Clan() { Id = 1, Name = "da" };

            var clanRepo = new ClansRepository(ninjaContextMock.Object);
            var equipmentRepo = new EquipmentRepository(ninjaContextMock.Object);
            var ninjasRepo = new NinjasRepository(ninjaContextMock.Object);
            var unitOfWork = new UnitOfWork.UnitOfWork(ninjaContextMock.Object, clanRepo, equipmentRepo, ninjasRepo);

            unitOfWork.Clans.Add(clan);
            unitOfWork.Complete();

            //Assert
            ninjaContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        */


       
    }
}
