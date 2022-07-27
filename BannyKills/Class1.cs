using BannyKills.Services;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BannyKills
{
    public class Class1 : RocketPlugin<Config>
    {
        public static Class1 Instance { get; private set; }



        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += Giriş.Giris;
            UnturnedPlayerEvents.OnPlayerDeath += Ölüm.Ölüms;
            EffectManager.onEffectButtonClicked += Button;
            base.Load();
        }

        private void Button(Player player, string buttonName)
        {
            short EffectAlt = 86;

            UnturnedPlayer pl = UnturnedPlayer.FromPlayer(player);
            switch (buttonName)
            {
                case "DiscordButton":
                    player.sendBrowserRequest("Discord", Configuration.Instance.Discord);
                    break;
                case "VoteButton":
                    player.sendBrowserRequest("Vote", Configuration.Instance.Vote);
                    break;
                case "CloseButton":
                    pl.Player.disablePluginWidgetFlag(EPluginWidgetFlags.Modal);
                    Görünürlük(EffectAlt, "Rank", pl.CSteamID, false);
                    break;
            }
        }

        public static string SıralamaBul(CSteamID Pl)
        {

            var Ayarlar = BannyKills.Class1.Instance.Configuration;
            var Killerss = Ayarlar.Instance.Kayıtlar.OrderByDescending(kayıt => kayıt.Kd).ToList();
            var deger = Ayarlar.Instance.Kayıtlar.FirstOrDefault(e => e.Kimlik == Pl);
            var değerekle = Killerss.IndexOf(deger);
            var sonuç = değerekle + 1;
            return sonuç.ToString();
        }

        public static void EffectYolla(CSteamID pl)
        {
            short EffectAlt = 86;
            var Ayarlar = BannyKills.Class1.Instance.Configuration;
            var Killers = Ayarlar.Instance.Kayıtlar.FirstOrDefault(e => e.Kimlik == pl);
            Class1.GönderYazı(EffectAlt, "ÖLÜM", Killers.Death.ToString(), pl);
            Class1.GönderYazı(EffectAlt, "ÖLDÜRME", Killers.Death.ToString(), pl);
            Class1.GönderYazı(EffectAlt, "KAFA", Killers.Kafa.ToString(), pl);
            Class1.GönderYazı(EffectAlt, "KD", Class1.KD(Killers.Kill, Killers.Death).ToString(), pl);
            Class1.GönderYazı(EffectAlt, "SIRALAMA", Class1.SıralamaBul(pl), pl);
        }

        public static int KD(int Öldürme, int Ölüm)
        {
            var sonuç = Öldürme / Ölüm;

            return sonuç;
        }
        public static void GönderYazı(short Id, string Name, string Metin, CSteamID Pl)
        {
            EffectManager.sendUIEffectText(Id, Pl, true, Name, Metin);
        }
        public static void Gönder(ushort Ids, short Id, CSteamID Pl)
        {
            EffectManager.sendUIEffect(Ids, Id, Pl, true);
        }
        public static void Görünürlük(short Id, string Name, CSteamID Pl, bool cancel)
        {
            EffectManager.sendUIEffectVisibility(Id, Pl, true, Name, cancel);
        }
        public static void Kaydet()
        {
            Class1.Instance.Configuration.Save();
        }

    }
}
