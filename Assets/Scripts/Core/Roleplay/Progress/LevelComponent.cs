namespace Core.Roleplay.Progress
{
    public abstract class LevelComponent : EntityComponent
    {
        public float experience = 0;
        public int level = 0;
        public int nextlvlexp = 5;
    }
}
