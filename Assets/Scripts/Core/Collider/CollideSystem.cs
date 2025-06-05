namespace Core.Collide
{
    public class CollideSystem : ComponentSystem
    {
        public override void Initialize()
        {
            Subscribe<ContactEffector, CollideEvent>(OnCollide);

        }
        void OnCollide(ContactEffector component, CollideEvent args)
        {
            Logger.Tech("Effect");
            foreach (var eff in component._effects)
            {
                eff.Effect(args.With);
            }
        }
    }
}
