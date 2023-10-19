using HouseBuilder.Enums;

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
            Assert.That(house.Walls,
                Has.Exactly(2).EqualTo(Material.Brick)
                .And.Exactly(1).EqualTo(Material.Stone)
                .And.Exactly(1).EqualTo(Material.Concrete));
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
        public void HouseBuilder_BuildHouseWithWallsAndWindow_Success()
        {
            House house = House.CreateBuilder()
                .AddWall(Material.Brick)
                .AddWall(Material.Brick)
                .AddWall(Material.Stone)
                .AddWall(Material.Concrete)
                .AddWindow(WindowType.Medium)
                .Build();

            Assert.That(house.Windows, Has.Exactly(1).EqualTo(WindowType.Medium));
        }
    }
}