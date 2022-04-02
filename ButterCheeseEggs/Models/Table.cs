using System.Runtime.Serialization;

namespace ButterCheeseEggs.Models
{

    public class Table<TContent>
    {
        public int XSize { get; set; }

        public int YSize { get; set; }

        public List<TContent> LinearData { get; set; } = new List<TContent>();

        public TContent this[int x, int y]
        {
            get
            {
                int linearIndex = GetIndex(x, y);
                return LinearData[linearIndex];
            }
            set
            {
                int linearIndex = GetIndex(x, y);
                LinearData[linearIndex] = value;
            }
        }


        public Table()
        {

        }

        public Table(int xSize, int ySize)
        {
            this.XSize = xSize;
            this.YSize = ySize;

            int length = xSize * ySize;

            for(int i = 0; i < length; i++)
            {
                TContent? item = default(TContent);

#pragma warning disable CS8604 // Possible null reference argument.
                LinearData.Add(item);
#pragma warning restore CS8604 // Possible null reference argument.

            }
        }



        private int GetIndex(int x, int y)
        {
            DoBoundaryCheck(x, y);
            int linearIndex = (y * XSize) + x;
            return linearIndex;
        }

        private void DoBoundaryCheck(int x, int y)
        {
            if(x >= XSize)
            {
                throw new IndexOutOfRangeException("X cannot be greater than XSize");
            }

            if (y >= YSize)
            {
                throw new IndexOutOfRangeException("Y cannot be greater than YSize");
            }
        }

    }
}
