using RWCustom;
using UnityEngine;

namespace CreatureFactory.Fisobs.Creatures.TheLizord
{
    public class SepiaLizard : Lizard
    {
        public SepiaLizard(AbstractCreature acrit, World world) : base(acrit, world)


        {
            var state = Random.state;
            Random.InitState(abstractCreature.ID.RandomSeed);

            effectColor = Color.Lerp(new Color(0.113f, 0.11f, 0.094f), new Color(0.219f, 0.18f, 0.153f), Random.value);

            Random.state = state;
        } // effectColor = Custom.HSL2RGB(Custom.WrappedRandomVariation(0.08f, 0.05f, 1f), 1f, Custom.ClampedRandomVariation(0.3f, 0.2f, 0.01f));I hate this it is unclear on how it works keeping it here for future reference
    }
}