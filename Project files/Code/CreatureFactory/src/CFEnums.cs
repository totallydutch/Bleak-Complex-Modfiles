using System.Runtime.CompilerServices;

namespace CreatureFactory;

public class CFEnums
{
    public static void Init()
    {
        RuntimeHelpers.RunClassConstructor(typeof(CreatureType).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(SandboxUnlocks).TypeHandle);
    }

    public static class CreatureType
    {
        public static CreatureTemplate.Type TheLizord = new(nameof(TheLizord), true);
    }

    public static class SandboxUnlocks
    {
        public static MultiplayerUnlocks.SandboxUnlockID TheLizord = new(nameof(TheLizord), true);
    }
}