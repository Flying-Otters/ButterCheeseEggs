namespace ButterCheeseEggs.Models
{
    public class Table<TContent> : List<TContent>
    {

        public int XSize { get; set; }

        public int YSize { get; set; }


        public TContent this[int x, int y]
        {
            get
            {
                int linearIndex = GetIndex(x, y);
                return this[linearIndex];
            }
            set
            {
                int linearIndex = GetIndex(x, y);
                this[linearIndex] = value;
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
                this.Add(item);
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
