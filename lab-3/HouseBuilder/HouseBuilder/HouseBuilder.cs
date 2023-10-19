using HouseBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    public class HouseBuilder
    {
        private readonly House house;

        public HouseBuilder()
        {
            house = new House();
        }

        public HouseBuilder AddWall(Material material)
        {
            house.Walls.Add(material);
            return this;
        }

        public HouseBuilder AddWindow(WindowType windowType)
        {
            house.Windows.Add(windowType);
            return this;
        }

        public House Build()
        {
            if (house.Walls.Count < 4)
            {
                throw new InvalidOperationException("A house must have at least 4 walls.");
            }

            return house;
        }
    }
}
