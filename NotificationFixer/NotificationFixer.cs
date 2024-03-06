using HarmonyLib;
using ResoniteModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;

namespace NotificationFixer;

public class NotificationFixer : ResoniteMod
{
    public override string Name => "NotificationFixer";
    public override string Author => "art0007i";
    public override string Version => "1.0.0";
    public override string Link => "https://github.com/art0007i/NotificationFixer/";
    public override void OnEngineInit()
    {
        Harmony harmony = new Harmony("me.art0007i.NotificationFixer");
        harmony.PatchAll();

    }
    [HarmonyPatch(typeof(NotificationPanel), "OnCommonUpdate")]
    class NotificationFixerPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes)
        {
            foreach (var code in codes)
            {
                if (code.operand is float f && f == 36.0f)
                {
                    code.operand = 32.0f;
                }

                yield return code;

            }
        }
    }
}
