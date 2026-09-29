using HarmonyLib;
using System;
using System.Diagnostics;

namespace Unfunny.HarmonyPatches
{
    [HarmonyPatch(typeof(DateTime), "get_Now")]
    internal class DateTimeNow
    {
        private static void Postfix(ref DateTime __result)
        {
            var month = __result.Month;
            var day = __result.Day;
            if ((month == 4 && day == 1) || (month == 4 && day == 22) || (month == 12 && day == 18))
                __result = __result.AddDays(1); // Skip to April 2nd, April 23rd and December 18th thus skipping april fools and earth day, and the week before Christmas Day.
        }
    }
}
