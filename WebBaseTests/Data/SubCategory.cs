namespace WebBaseTests.Data
{
    class SubCategory
    {
        public SubCategory(Category category, string subCategotyName = "")
        {
            Name = subCategotyName;
            Category = category;
        }

        public string Name { get; set; }
        public Category Category;

    }
}
