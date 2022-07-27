using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace BannyKills.Commands
{
	public class CommandLeaderBoards : IRocketCommand
	{
		public AllowedCaller AllowedCaller => AllowedCaller.Player;
		public string Name => "lb";
		public string Help => "En İyi 10 Oyuncuyu Görürsünüz.";
		public string Syntax => "/lb";
		public List<string> Aliases => new List<string>() { "ranks" };
		public List<string> Permissions => new List<string>() { "banny.lb" };

		public void Execute(IRocketPlayer caller, string[] command)
		{
			UnturnedPlayer player = (UnturnedPlayer)caller;
			short EffectAlt = 86;

			player.Player.enablePluginWidgetFlag(EPluginWidgetFlags.Modal);
			Class1.Görünürlük(EffectAlt, "Rank", player.CSteamID, true);
			var değer = Class1.Instance.Configuration.Instance.Kayıtlar.FirstOrDefault(e => e.Kimlik == player.CSteamID);
			Class1.GönderYazı(EffectAlt, "RÖLÜM", değer.Death.ToString(), player.CSteamID);
			Class1.GönderYazı(EffectAlt, "RÖLDÜRME", değer.Kill.ToString(), player.CSteamID);
			Class1.GönderYazı(EffectAlt, "RSIRALAMA", Class1.SıralamaBul(player.CSteamID), player.CSteamID);
			Class1.GönderYazı(EffectAlt, "RKAFA", değer.Kafa.ToString(), player.CSteamID);
			Class1.GönderYazı(EffectAlt, "RKD", değer.Kd.ToString(), player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (0)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (1)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (2)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (3)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (4)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (5)", $" ", player.CSteamID);
			Class1.GönderYazı(EffectAlt, $"Kill (6)", $" ", player.CSteamID);

			var Killers = Class1.Instance.Configuration.Instance.Kayıtlar.OrderByDescending(Kill => Kill.Kd).Take(7).ToList();

			foreach (var kill in Killers)
			{
				UnturnedPlayer pl = UnturnedPlayer.FromCSteamID(kill.Kimlik);
				Class1.GönderYazı(EffectAlt, $"Kill ({Killers.IndexOf(kill)})", $"{pl.CharacterName} - {kill.Kill} - {kill.Death} - {kill.Kd}", player.CSteamID);
			}


		}
	}
}
