using Core.EntityEffects;

namespace Core.Roleplay.Weapons
{
    public class Bite : Weapon
    {
        public Bite() 
        {
            var Damage = new DamageEffect();
            Damage.damage.Add(Roleplay.Damage.Piercing, 3);
            WeaponEffects.Add(Damage);
        }
    }
}