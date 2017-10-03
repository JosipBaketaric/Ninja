using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ninja.Repository.Tests
{
    [TestClass]
    public class GenericRepositoryTests
    {
        /*

        //TKO ZNA ZNA :D


        [TestMethod]
        public void TestMethodAddClanFromRepo()
        {
            //Arange
            var dbSet = new Mock<DbSet<Clan>>();
            dbSet.Setup(x => x.Add(It.IsAny<Clan>())).Returns((Clan c) => c);

            var ninjaContextMock = new Mock<NinjaContext>();
            ninjaContextMock.Setup(x => x.Clans.Add(It.IsAny<Clan>())).Returns((Clan c) => c);
            ninjaContextMock.Setup(x => x.Set<Clan>()).Returns(dbSet.Object);

            var clanRepo = new ClansRepository(ninjaContextMock.Object);

            var clan = new Clan(){Id=1, Name="da"};
            //Act
            clanRepo.Add(clan);

            //Assert
            //ninjaContextMock.Verify(x => x.Clans.Add(It.Is<Clan>(u=> u.Id ==1)), Times.Once);
            dbSet.Verify(x => x.Add(It.Is<Clan>(u => u.Id == 1)), Times.Once);
        }




        [TestMethod]
        public void TestMethodGetFromRepo()
        {
            //Arange
            var clan = new Clan() { Id = 1, Name = "da" };

            var dbSet = new Mock<DbSet<Clan>>();
            dbSet.Setup(x => x.Find(It.IsAny<int>())).Returns((Clan) clan);

            var ninjaContextMock = new Mock<NinjaContext>();
            ninjaContextMock.Setup(x => x.Clans.Find(It.IsAny<int>())).Returns((Clan c) => c);
            ninjaContextMock.Setup(x => x.Set<Clan>()).Returns(dbSet.Object);

            var clanRepo = new ClansRepository(ninjaContextMock.Object);

            //Act
            var result = clanRepo.Get(1);

            //Assert
            Assert.AreEqual(clan, result);
        }



        */

    }
}
