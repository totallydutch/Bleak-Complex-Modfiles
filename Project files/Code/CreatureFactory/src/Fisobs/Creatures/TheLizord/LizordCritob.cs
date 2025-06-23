using DevInterface;
using Fisobs.Core;
using Fisobs.Creatures;
using Fisobs.Sandbox;
using System.Collections.Generic;
using static CreatureFactory.CFEnums;
using Color = UnityEngine.Color;

namespace CreatureFactory.Fisobs.Creatures.TheLizord;

public class LizordCritob : Critob
{
    public LizordCritob() : base(CFEnums.CreatureType.TheLizord)
    {
        Icon = new SimpleIcon("Futile_White", Color.yellow);
        ShelterDanger = ShelterDanger.Hostile;
        SandboxPerformanceCost = new(0.5f, 0.1f);
        CreatureName = nameof(CFEnums.CreatureType.TheLizord);

        RegisterUnlock(KillScore.Configurable(5), CFEnums.SandboxUnlocks.TheLizord);
    }

    public override CreatureState CreateState(AbstractCreature acrit) => new LizardState(acrit);

    public override CreatureTemplate.Type ArenaFallback() => CreatureTemplate.Type.BlackLizard;

    public override IEnumerable<string> WorldFileAliases() => new[] { "Sepia Lizard, SepiaLizard, Sepia" };

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => new[] { RoomAttractivenessPanel.Category.Lizards, RoomAttractivenessPanel.Category.LikesInside };

    public override string DevtoolsMapName(AbstractCreature acrit) => "Sepia lizard";

    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.yellow;

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new LizardAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new SepiaLizard(acrit, acrit.world);

    public override CreatureTemplate CreateTemplate()
    {
        return LizardBreeds.BreedTemplate(Type, StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.LizardTemplate), StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.PinkLizard),
            StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.BlueLizard), StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.GreenLizard));
    }

    public override void EstablishRelationships()
    {
        Relationships r = new(CreatureType.TheLizord);
        foreach (var template in StaticWorld.creatureTemplates)
        {
            r.Fears(template.type, 1f);
            r.FearedBy(template.type, 1f);
            r.Fears(CreatureTemplate.Type.PinkLizard, 0.5f);
            r.Fears(CreatureTemplate.Type.RedCentipede, 1f);
            r.Eats(CreatureTemplate.Type.Slugcat, 0.05f);
            r.Eats(CreatureTemplate.Type.Centipede, 0.5f);
            r.Eats(CreatureTemplate.Type.SmallCentipede, 1f);
            r.Eats(CreatureTemplate.Type.BigSpider, 0.8f);
            r.AttackedBy(CreatureTemplate.Type.BlueLizard, 1f);
            r.AttackedBy(CreatureTemplate.Type.PinkLizard, 1f);
            r.Antagonizes(CreatureTemplate.Type.BigSpider, 1f);
            r.Antagonizes(CreatureTemplate.Type.BlueLizard, 0.8f);
            r.FearedBy(CreatureTemplate.Type.Centipede, 0.1f);
            r.FearedBy(CreatureTemplate.Type.SmallCentipede, 0.8f);
            r.EatenBy(CreatureTemplate.Type.RedCentipede, 0.8f);
        }
        r.Rivals(CreatureType.TheLizord, 0.5f);

        
    }
}