using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BannyKills.Services
{
    public static class Ölüm
    {

        internal static void Ölüms(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            ushort Effect = 5489;
            short EffectAlt = 86;
            var Ölen = player;
            UnturnedPlayer Öldüren = UnturnedPlayer.FromCSteamID(murderer);
            var Ayarlar = Class1.Instance.Configuration.Instance;
            var Menü = Class1.Instance;
            var KatilDeğer = Ayarlar.Kayıtlar.FirstOrDefault(e => e.Kimlik == murderer);
            var ÖlenDeğer = Ayarlar.Kayıtlar.FirstOrDefault(e => e.Kimlik == Ölen.CSteamID);

            if (cause == EDeathCause.SENTRY || cause == EDeathCause.MISSILE || cause == EDeathCause.GRENADE || cause == EDeathCause.GUN || cause == EDeathCause.MELEE || cause == EDeathCause.PUNCH)
            {

                ÖlenDeğer.Death += 1;
                KatilDeğer.Kill += 1;
                ÖlenDeğer.Kd = Class1.KD(ÖlenDeğer.Kill, ÖlenDeğer.Death);
                KatilDeğer.Kd = Class1.KD(KatilDeğer.Kill, KatilDeğer.Death);
                Class1.Instance.Configuration.Save();

                if (limb == ELimb.SKULL)
                {
                    KatilDeğer.Kafa += 1;
                    Class1.Instance.Configuration.Save();

                    EffectManager.sendUIEffectText(EffectAlt, Öldüren.CSteamID, true, "KAFA", KatilDeğer.Kafa.ToString());
                    Class1.EffectYolla(Ölen.CSteamID);
                    Class1.EffectYolla(Öldüren.CSteamID);
                    return;
                }
                else
                {
                    Class1.EffectYolla(Ölen.CSteamID);
                    Class1.EffectYolla(Öldüren.CSteamID);

                }
            }

            if (cause == EDeathCause.SHRED || cause == EDeathCause.VEHICLE || cause == EDeathCause.ROADKILL || cause == EDeathCause.BREATH ||cause == EDeathCause.KILL ||cause == EDeathCause.BLEEDING || cause == EDeathCause.BONES || cause == EDeathCause.FREEZING || cause == EDeathCause.FOOD || cause == EDeathCause.WATER || cause == EDeathCause.ACID || cause == EDeathCause.ZOMBIE || cause == EDeathCause.ANIMAL || cause == EDeathCause.SUICIDE || cause == EDeathCause.INFECTION)
            {
                ÖlenDeğer.Death += 1;
                ÖlenDeğer.Kd = Class1.KD(ÖlenDeğer.Kill, ÖlenDeğer.Death);
                Class1.Instance.Configuration.Save();
                EffectManager.sendUIEffectText(EffectAlt, Ölen.CSteamID, true, "ÖLÜM", ÖlenDeğer.Death.ToString());
                EffectManager.sendUIEffectText(EffectAlt, Ölen.CSteamID, true, "SIRALAMA", Class1.SıralamaBul(Ölen.CSteamID));
                EffectManager.sendUIEffectText(EffectAlt, Ölen.CSteamID, true, "KD", ÖlenDeğer.Kd.ToString());

            }

       

        }


    }
}
