namespace NovelReformatorWebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ReformatorContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}