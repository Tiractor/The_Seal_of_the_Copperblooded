namespace Core.EntityStatuses
{
    public enum Statuses
    {
        Null,
        Bleeded,
        Fired,
        Frosted,
        Poisoned,
        PACD
    }
    public static class StatusReturner 
    {
        public static EntityStatus EnumToStatus(Statuses status) 
        {
            switch (status) 
            { 
                case Statuses.Bleeded: return new Bleeded();
                case Statuses.Fired: return new Fired();
                case Statuses.Frosted: return new Fired();
                case Statuses.Poisoned: return new Poisoned();
                case Statuses.PACD: return new PrimaryAttackCooldown();
                default: return null;
            }
        }
        public static Statuses StatusToEnum(EntityStatus status)
        {
            switch (status)
            {
                case Bleeded _: return Statuses.Bleeded;
                case Fired _: return Statuses.Fired;
                case Frosted _: return Statuses.Frosted;
                case Poisoned _: return Statuses.Poisoned;
                case PrimaryAttackCooldown _: return Statuses.PACD;
                default: return Statuses.Null; // Если статус неизвестен
            }
        }
    }

}