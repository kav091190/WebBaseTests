namespace WebBaseTests
{
    class Town
    {
        public Town(Region region, string townName = "")
        {
            Name = townName;
            Region = region;
        }

        public string Name { get; }
        public Region Region;
    }
}
