﻿using EloBuddy;
using LeagueSharp.Common;
using NechritoRiven.Core;
using NechritoRiven.Menus;

namespace NechritoRiven.Event
{
    class Interrupt2 : Core.Core
    {
        public static void OnInterruptableTarget(AIHeroClient sender, Interrupter2.InterruptableTargetEventArgs args)
        {
            if (!MenuConfig.InterruptMenu || sender.IsInvulnerable) return;

            if (sender.IsValidTarget(Spells.W.Range))
            {
                if (Spells.W.IsReady())
                {
                    Spells.W.Cast(sender);
                }
            }
        }
    }
}
