using HouseBuilder.Enums;

namespace HouseBuilder
{
    public class House
    {
        public List<Material> Walls { get; private set; }
        public List<WindowType> Windows { get; private set; }

        internal House()
        {
            Walls = new List<Material>();
            Windows = new List<WindowType>();
        }

        public static HouseBuilder CreateBuilder()
        {
            return new HouseBuilder();
        }
    }
}