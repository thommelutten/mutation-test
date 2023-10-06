using HouseBuilder.Enums;

namespace HouseBuilder
{
    public class House
    {
        public List<Material> Walls { get; private set; }

        internal House()
        {
            Walls = new List<Material>();
        }

        public static HouseBuilder CreateBuilder()
        {
            return new HouseBuilder();
        }
    }

}