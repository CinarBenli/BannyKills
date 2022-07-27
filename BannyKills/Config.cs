using Rocket.API;
using System.Collections.Generic;

namespace BannyKills
{
    public class Config : IRocketPluginConfiguration
    {

        public string Logo;
        public string Discord;
        public string Vote;

        public List<KullanıcıKayıtlar> Kayıtlar;

        public void LoadDefaults()
        {
            Discord = "http";
            Vote = "http";
            Kayıtlar = new List<KullanıcıKayıtlar>();
        }
    }
}