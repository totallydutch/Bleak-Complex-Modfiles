using System;
using System.Collections.Generic;
using UnityEngine;
using static CreatureFactory.CFEnums;

namespace CreatureFactory.Fisobs.Creatures.TheLizord;

public class LizordHooks
{
    public static void Init()
    {
        On.AbstractCreature.ctor += AbstractCreature_ctor;
        On.LizardBreeds.BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate += LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate;
    }

    private static CreatureTemplate LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate(On.LizardBreeds.orig_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate orig, CreatureTemplate.Type type, CreatureTemplate lizardAncestor, CreatureTemplate pinkTemplate, CreatureTemplate blueTemplate, CreatureTemplate greenTemplate)
    {
        var result = orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);

        if (type == CreatureType.TheLizord)
        {
            var lizardBreedParams = new LizardBreedParams(type)
            {
                terrainSpeeds = new LizardBreedParams.SpeedMultiplier[Enum.GetNames(typeof(AItile.Accessibility)).Length]
            };
            for (var i = 0; i < lizardBreedParams.terrainSpeeds.Length; i++)
            {
                lizardBreedParams.terrainSpeeds[i] = new LizardBreedParams.SpeedMultiplier(0.1f, 1f, 1f, 1f);
            }

            lizardBreedParams.bodyRadFac = 1f;
            lizardBreedParams.pullDownFac = 1f;
            lizardBreedParams.bodyLengthFac = 1f;
            var tileTypeResistances = new List<TileTypeResistance>();
            var tileConnectionResistances = new List<TileConnectionResistance>();

            lizardBreedParams.terrainSpeeds[1] = new LizardBreedParams.SpeedMultiplier(1f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Floor, 1f, PathCost.Legality.Allowed));
            lizardBreedParams.terrainSpeeds[2] = new LizardBreedParams.SpeedMultiplier(1.2f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Corridor, 1.2f, PathCost.Legality.Allowed));
            lizardBreedParams.terrainSpeeds[3] = new LizardBreedParams.SpeedMultiplier(0.5f, 1f, 0.75f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Climb, 2.5f, PathCost.Legality.Allowed));
            lizardBreedParams.terrainSpeeds[4] = new LizardBreedParams.SpeedMultiplier(0.8f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Wall, 1f, PathCost.Legality.Allowed));
            lizardBreedParams.terrainSpeeds[5] = new LizardBreedParams.SpeedMultiplier(0.6f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Ceiling, 1.2f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.DropToFloor, 2f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.DropToClimb, 2f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ShortCut, 5f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachOverGap, 1.1f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachUp, 1.1f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachDown, 1.1f, PathCost.Legality.Allowed));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.CeilingSlope, 2f, PathCost.Legality.Allowed));
            lizardBreedParams.biteDelay = 12;
            lizardBreedParams.biteInFront = 15f;
            lizardBreedParams.biteHomingSpeed = 1.2f;
            lizardBreedParams.biteChance = 1f / 6f;
            lizardBreedParams.attemptBiteRadius = 40f;
            lizardBreedParams.getFreeBiteChance = 0.65f;
            lizardBreedParams.biteDamage = 1f;
            lizardBreedParams.biteDamageChance = 0.4f;
            lizardBreedParams.toughness = 0.8f;
            lizardBreedParams.stunToughness = 1f;
            lizardBreedParams.regainFootingCounter = 3;
            lizardBreedParams.baseSpeed = 6.84f;
            lizardBreedParams.bodyMass = 2f;
            lizardBreedParams.bodySizeFac = 1f;
            lizardBreedParams.floorLeverage = 0.5f;
            lizardBreedParams.maxMusclePower = 5f;
            lizardBreedParams.danger = 0.7f;
            lizardBreedParams.aggressionCurveExponent = 0.9f;
            lizardBreedParams.wiggleSpeed = 1f;
            lizardBreedParams.wiggleDelay = 15;
            lizardBreedParams.bodyStiffnes = 0.2f;
            lizardBreedParams.swimSpeed = 0.45f;
            lizardBreedParams.idleCounterSubtractWhenCloseToIdlePos = 1;
            lizardBreedParams.headShieldAngle = 100f;
            lizardBreedParams.canExitLounge = true;
            lizardBreedParams.canExitLoungeWarmUp = true;
            lizardBreedParams.findLoungeDirection = 1f;
            lizardBreedParams.loungeDistance = 130f;
            lizardBreedParams.preLoungeCrouch = 35;
            lizardBreedParams.preLoungeCrouchMovement = -0.3f;
            lizardBreedParams.loungeSpeed = 4.5f;
            lizardBreedParams.loungeMaximumFrames = 20;
            lizardBreedParams.loungePropulsionFrames = 10;
            lizardBreedParams.loungeJumpyness = 0.9f;
            lizardBreedParams.loungeDelay = 110;
            lizardBreedParams.riskOfDoubleLoungeDelay = 0.8f;
            lizardBreedParams.postLoungeStun = 10;
            lizardBreedParams.loungeTendensy = 0.033f;
            lizardBreedParams.perfectVisionAngle = Mathf.Lerp(1f, -1f, 1f / 12f);
            lizardBreedParams.periferalVisionAngle = Mathf.Lerp(1f, -1f, 19f / 36f);
            lizardBreedParams.biteDominance = 0.45f;
            lizardBreedParams.limbSize = 1f;
            lizardBreedParams.limbThickness = 1f;
            lizardBreedParams.stepLength = 0.5f;
            lizardBreedParams.liftFeet = 0.3f;
            lizardBreedParams.feetDown = 0.5f;
            lizardBreedParams.noGripSpeed = 0.1f;
            lizardBreedParams.limbSpeed = 5f;
            lizardBreedParams.limbQuickness = 0.5f;
            lizardBreedParams.limbGripDelay = 1;
            lizardBreedParams.smoothenLegMovement = true;
            lizardBreedParams.legPairDisplacement = 0.2f;
            lizardBreedParams.standardColor = new Color(0.264f, 0.237f, 0.22f);
            lizardBreedParams.walkBob = 4f;
            lizardBreedParams.tailSegments = 6;
            lizardBreedParams.tailStiffness = 250f;
            lizardBreedParams.tailStiffnessDecline = 0.2f;
            lizardBreedParams.tailLengthFactor = 1f;
            lizardBreedParams.tailColorationStart = 0.1f;
            lizardBreedParams.tailColorationExponent = 0.5f;
            lizardBreedParams.headSize = 1f;
            lizardBreedParams.neckStiffness = 0.2f;
            lizardBreedParams.jawOpenAngle = 110f;
            lizardBreedParams.jawOpenLowerJawFac = 0.55f;
            lizardBreedParams.jawOpenMoveJawsApart = 23f;
            lizardBreedParams.headGraphics = new int[5];
            lizardBreedParams.framesBetweenLookFocusChange = 80;
            lizardBreedParams.tamingDifficulty = 3f;

            result = new CreatureTemplate(type, lizardAncestor, tileTypeResistances, tileConnectionResistances, new CreatureTemplate.Relationship(CreatureTemplate.Relationship.Type.Ignores, 0f))
            {
                name = "Sepia lizard",
                waterPathingResistance = 5f,
                visualRadius = 1000f,
                waterVision = 0.4f,
                throughSurfaceVision = 0.85f,
                breedParameters = lizardBreedParams,
                baseDamageResistance = lizardBreedParams.toughness * 2f,
                baseStunResistance = lizardBreedParams.toughness
            };
            result.damageRestistances[(int)Creature.DamageType.Bite, 0] = 2.5f;
            result.damageRestistances[(int)Creature.DamageType.Bite, 1] = 3f;
            result.damageRestistances[(int)Creature.DamageType.Electric, 1] = 3f;
            result.meatPoints = 6;
            result.doPreBakedPathing = false;
            result.preBakedPathingAncestor = blueTemplate;
            result.virtualCreature = false;
            result.pickupAction = "Bite";
            result.jumpAction = "Call";
            //result.throwAction = "Launch";
        }

        return result;
    }

    private static void AbstractCreature_ctor(On.AbstractCreature.orig_ctor orig, AbstractCreature self, World world, CreatureTemplate creatureTemplate, Creature realizedCreature, WorldCoordinate pos, EntityID ID)
    {
        orig(self, world, creatureTemplate, realizedCreature, pos, ID);

        if(creatureTemplate.type == CFEnums.CreatureType.TheLizord)
        {
            self.personality.aggression = 1f;
            self.personality.dominance = 1f;
            self.personality.energy = 1f;
        }
    }
}
