namespace PM.Common.Enums
{
    public enum ActivityType
    {
        System = 0,
        Profile = 1,
        Project = 2,
        Task = 3
    }

    public enum ActivityMagnitude
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    public static class EnumExtensions
    {
        public static int ToInt(this ActivityType type)
        {
            return (int)type;
        }

        public static int ToInt(this ActivityMagnitude type)
        {
            return (int)type;
        }
    }
}
