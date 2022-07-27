using Rocket.Unturned.Player;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannyKills.Services
{
    public static class Giriş
    {
        internal static void Giris(UnturnedPlayer player)
        {

            var pl = player.CSteamID;
            var Ayarlar = Class1.Instance.Configuration.Instance;
            ushort Effect = 5489;
            short EffectAlt = 86;
            var DeğerÇek = Ayarlar.Kayıtlar.FirstOrDefault(Kayıt => Kayıt.Kimlik == player.CSteamID);
            Class1.Gönder(Effect, EffectAlt, pl);

            Class1.Görünürlük(EffectAlt, "Rank", player.CSteamID, false);

            if (DeğerÇek == null)
            {
                Ayarlar.Kayıtlar.Add(new KullanıcıKayıtlar { Kimlik = pl, Kill = 0, Death = 0, Kd = 0, Kafa = 0 });
                Class1.Instance.Configuration.Save();
                Class1.GönderYazı(EffectAlt, "ÖLÜM", "0", pl);
                Class1.GönderYazı(EffectAlt, "ÖLDÜRME", "0", pl);
                Class1.GönderYazı(EffectAlt, "KAFA", "0", pl);
                Class1.GönderYazı(EffectAlt, "KD", "0", pl);
                Class1.GönderYazı(EffectAlt, "SIRALAMA", Class1.SıralamaBul(pl), pl);
            }
            else
            {
                Class1.GönderYazı(EffectAlt, "ÖLDÜRME", DeğerÇek.Kill.ToString(), pl);
                Class1.GönderYazı(EffectAlt, "ÖLÜM", DeğerÇek.Death.ToString(), pl);
                Class1.GönderYazı(EffectAlt, "KAFA", DeğerÇek.Death.ToString(), pl);
                Class1.GönderYazı(EffectAlt, "KD", DeğerÇek.Death.ToString(), pl);
                Class1.GönderYazı(EffectAlt, "SIRALAMA", Class1.SıralamaBul(pl), pl);

            }
         
        }
    }
}
