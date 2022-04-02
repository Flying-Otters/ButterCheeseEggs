namespace ButterCheeseEggs.Models
{
    public class Table<T> : List<T>
    {

        public int XSize { get; set; }

        public int YSize { get; set; }


        public T this[int x, int y]
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
                T? item = default(T);
#pragma warning disable CS8604 // Possible null reference argument.
                this.Add(item);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }



        private int GetIndex(int x, int y)
        {
            return (y * YSize) + x;
        }

    }
}
