using BepInEx;
using BepInEx.Logging;
using CreatureFactory.Fisobs.Creatures.TheLizord;
using Fisobs.Core;
using System;
using System.IO;
using System.Linq;

namespace CreatureFactory;

[BepInDependency("io.github.dual.fisobs")]
[BepInPlugin(MOD_ID, MOD_NAME, VERSION)]

public class Plugin : BaseUnityPlugin
{
    public const string MOD_ID = "BensoneWhite.CreatureFactory";
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_NAME = "CreatureFactory";
    public const string VERSION = "1.0.0";

    private bool isInit;

    public static new ManualLogSource Logger;

    public static void DebugLog(object message) => Logger.LogInfo(message);
    public static void DebugWarning(object message) => Logger.LogWarning(message);
    public static void DebugError(object message) => Logger.LogError(message);

    public void OnEnable()
    {
        Logger = base.Logger;

        DebugWarning($"{MOD_NAME} is loading.... {VERSION}");

        ApplyCreatures();
        CFEnums.Init();

        On.RainWorld.OnModsInit += RainWorld_OnModsInit;
    }

    private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);
        try
        {
            if (isInit) return;
            isInit = true;

            LoadAtlases();
        }
        catch (Exception ex)
        {
            DebugError(ex);
        }
    }

    private void ApplyCreatures()
    {
        DebugLog($"Applying {MOD_NAME} creatures...");

        LizordHooks.Init();

        Content.Register(
            // You can add more creatures by doing:
          //new CreatureCritob(),
            new LizordCritob()
            );
    }

    private void LoadAtlases()
    {
        var sprites = AssetManager.ListDirectory("CF_atlases")
            .Where(file => Path.GetExtension(file)
            .Equals(".png", StringComparison.OrdinalIgnoreCase));

        foreach (var file in sprites)
        {
            string fileWithoutExtension = Path.ChangeExtension(file, null);
            if (File.Exists(Path.ChangeExtension(file, ".txt")))
                Futile.atlasManager.LoadAtlas(fileWithoutExtension);
            else
                Futile.atlasManager.LoadImage(fileWithoutExtension);
        }
    }
}