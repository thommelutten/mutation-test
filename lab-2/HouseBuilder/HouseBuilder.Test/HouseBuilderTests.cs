using HouseBuilder.Enums;
using NUnit.Framework;

namespace HouseBuilder.Test
{
    [TestFixture]
    public class HouseBuilderTests
    {
        [Test]
        public void HouseBuilder_BuildHouseWithWalls_Success()
        {
            House house = House.CreateBuilder()
                .AddWall(Material.Brick)
                .AddWall(Material.Brick)
                .AddWall(Material.Stone)
                .AddWall(Material.Concrete)
                .Build();

            Assert.That(house, Is.Not.Null);
            Assert.That(house.Walls, Has.Count.EqualTo(4));
            Assert.That(house.Walls, Does.Contain(Material.Brick));
            Assert.That(house.Walls, Does.Contain(Material.Concrete));
            Assert.That(house.Walls, Does.Contain(Material.Stone));
        }

        [Test]
        public void HouseBuilder_BuildHouseWithInsufficientWalls_ThrowsException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                House house = House.CreateBuilder()
                    .AddWall(Material.Brick)
                    .Build();
            });

            Assert.That(exception.Message, Is.EqualTo("A house must have at least 4 walls."));
        }

        [Test]
        public void HouseBuilder_BuilderHouseWithWallsAndWindow_Success()
        {
            House house = House.CreateBuilder()
                .AddWall(Material.Brick)
                .AddWall(Material.Brick)
                .AddWall(Material.Stone)
                .AddWall(Material.Concrete)
                .AddWindow(WindowType.Medium)
                .Build();
        }
    }
}