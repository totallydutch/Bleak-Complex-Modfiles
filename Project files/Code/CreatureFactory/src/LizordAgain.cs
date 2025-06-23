using LizardCosmetics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static CreatureFactory.CFEnums;
using Random = UnityEngine.Random;
namespace LizordAgain;

public class LizardHooks
{
    public static void Apply()
    {
        On.LizardGraphics.ctor += LizardGraphics_ctor;
    }

    private static void LizardGraphics_ctor(On.LizardGraphics.orig_ctor orig, LizardGraphics self, PhysicalObject ow)
    {
        orig(self, ow);

        if (self.lizard.Template.type == CreatureFactory.CFEnums.CreatureType.TheLizord)
        {
            var state = Random.state;
            Random.InitState(self.lizard.abstractCreature.ID.RandomSeed);
            var num = self.startOfExtraSprites + self.extraSprites;
            self.ivarBodyColor = Color.red;

            //num = self.AddCosmetic(num, new Antennae(self, num));

            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new ShortBodyScales(self, num));
            }
            if (Random.value < 0.1f)
            {
                var e = new LongHeadScales(self, num)
                {
                    colored = false
                };
                e.numberOfSprites = e.scalesPositions.Length;
                var value = Random.value;
                var num2 = Mathf.Pow(Random.value, 0.45f);
                for (var i = 0; i < e.scalesPositions.Length; i++)
                {
                    e.scaleObjects[i] = new LizardScale(e)
                    {
                        length = Mathf.Lerp(10f, 30f, num),
                        width = Mathf.Lerp(1.0f, 1.4f, value * num)
                    };
                    e.backwardsFactors[i] = num2;
                }
                e.numberOfSprites = (e.colored ? (e.scalesPositions.Length * 2) : e.scalesPositions.Length);

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.0f)
            {
                var e = new SpineSpikes(self, num)
                {
                    colored = 0,
                    graphic = 4,
                    spineLength = Mathf.Lerp(0.3f, 0.55f, Random.value) * 1
                };
                e.numberOfSprites = e.bumps;

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.0f)
            {
                var e = new LongShoulderScales(self, num)
                {
                    rigor = 0f,
                    graphic = 4
                };
                e.GeneratePatchPattern(0.2f, Random.Range(6, 9), 0.9f, 2f);
                e.colored = false;
                var num4 = 0f;
                var num5 = 1f;
                var num2 = Mathf.Lerp(1f, 1f / Mathf.Lerp(1f, (float)e.scalesPositions.Length, Mathf.Pow(Random.value, 2f)), 0.5f);
                var num3 = Mathf.Lerp(5f, 15f, Random.value) * num2;
                var b = Mathf.Lerp(num3, 35f, Mathf.Pow(Random.value, 0.5f)) * num2;
                var p = Mathf.Lerp(0.1f, 0.9f, Random.value);
                e.scaleObjects = new LizardScale[e.scalesPositions.Length];
                e.backwardsFactors = new float[e.scalesPositions.Length];

                for (var i = 0; i < e.scalesPositions.Length; i++)
                {
                    if (e.scalesPositions[i].y > num4)
                    {
                        num4 = e.scalesPositions[i].y;
                    }
                    if (e.scalesPositions[i].y < num5)
                    {
                        num5 = e.scalesPositions[i].y;
                    }
                }

                for (var j = 0; j < e.scalesPositions.Length; j++)
                {
                    e.scaleObjects[j] = new LizardScale(e);
                    var num6 = Mathf.Pow(Mathf.InverseLerp(num5, num4, e.scalesPositions[j].y), p);
                    e.scaleObjects[j].length = (Mathf.Lerp(num3, b, Mathf.Lerp(Mathf.Sin(num6 * 3.1415927f), 1.1f, (num6 < 0.5f) ? 0.5f : 0.3f)));
                    e.scaleObjects[j].width = (Mathf.Lerp(1.0f, 1.2f, Mathf.Lerp(Mathf.Sin(num6 * 3.1415927f), 1.1f, (num6 < 0.5f) ? 0.5f : 0.3f)) * num2);
                    e.backwardsFactors[j] = e.scalesPositions[j].y * 0.7f;
                }
                e.numberOfSprites = (e.colored ? (e.scalesPositions.Length * 2) : e.scalesPositions.Length);

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                var e = new AxolotlGills(self, num)
                {
                    graphic = 6
                };
                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new SnowAccumulation(self, num));
            }
            if (Random.value < 0.9f)
            {
                var e = new WingScales(self, num)
                {
                    graphic = (Random.value >= 0.4f) ? Random.Range(0, 5) : Random.Range(1, 5)
                };
                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new JumpRings(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new BodyStripes(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new BumpHawk(self, num));
            }
            if (Random.value < 0.0f)
            {
                num = self.AddCosmetic(num, new Whiskers(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new TailGeckoScales(self, num));
            }
            if (Random.value < 0.9f)
            {
                var e = new TailFin(self, num)
                {
                    colored = false
                };
                e.numberOfSprites = e.bumps * 2;
                _ = self.AddCosmetic(num, e);
            }

            Random.state = state;
        }
    }
}