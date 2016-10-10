
#pragma warning disable 1587

using EloBuddy; 
 using LeagueSharp.SDK; 
 namespace ExorAIO.Champions.Karthus
{
    using System;

    using ExorAIO.Utilities;

    using LeagueSharp;
    using LeagueSharp.SDK;
    using LeagueSharp.SDK.UI;
    using LeagueSharp.SDK.Utils;

    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Harass(EventArgs args)
        {
            if (!Targets.Target.IsValidTarget() || Invulnerable.Check(Targets.Target, DamageType.Magical))
            {
                return;
            }

            /// <summary>
            ///     The Q Harass Logic.
            /// </summary>
            if (Vars.Q.IsReady() && Targets.Target.IsValidTarget(Vars.Q.Range - 100f)
                && GameObjects.Player.ManaPercent
                > ManaManager.GetNeededMana(Vars.Q.Slot, Vars.Menu["spells"]["q"]["harass"])
                && Vars.Menu["spells"]["q"]["harass"].GetValue<MenuSliderButton>().BValue)
            {
                if (GameObjects.Player.Distance(Vars.Q.GetPrediction(Targets.Target).CastPosition) < Vars.Q.Range)
                {
                    Vars.Q.Cast(Vars.Q.GetPrediction(Targets.Target).CastPosition);
                }
            }
        }

        #endregion
    }
}