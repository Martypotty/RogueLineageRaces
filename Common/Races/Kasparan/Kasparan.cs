using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;

namespace RogueLineageRaces.Common.Races.Kasparan
{
	public class Kasparan : Race
	{
		public override string RaceSelectIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/KasparanSelectIcon");
		public override string RaceDisplayMaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/KasparanDisplayMale");
		public override string RaceDisplayFemaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/KasparanDisplayFemale");
		
		public override string RaceDisplayName => "Kasparans of Gaia";
		public override string RaceLore1 => "Kasparans are a dragon-" + "\n-esk race oriented" + "\naround using heat"  +  "\nand healing buffs to"  +  "\nincrease survivability.";
		public override string RaceLore2 => "Kasparans used to be at the top of" + "\ntheir game with Respirare. Fortunately," + "\na magic called Tithe was found, and" + "\nthis caused their empires to fall.";
		
		public override string RaceEnvironmentIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Kasparan");
		public override string RaceEnvironmentOverlay2Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/Resilient");
		public override string RaceEnvironmentOverlay1Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/KasparanEnvironment");
		
		public override string RaceAbilityName => "Extra life (Passive)";
		public override string RaceAbilityDescription1 => "-Being inflicted by normal healing buffs and heat/heat-related buffs increases your Endurance by 3.2% and Attack by 1.4%.";
		public override string RaceAbilityDescription2 => "-This passive can stack ontop of itself multiple times. Provides 'Cozy fire' instead of endurance when On Fire or Burning.";
		public override string RaceAbilityDescription3 => "-Note that the ability does not apply to altered types of flames such as Cursed Flames or Shadow Flames.";
		public override string RaceAbilityDescription4 => "-Dryad's Blessing is not as effected by the Extra Life Passive. [25% less rather than more.] W.I.Fire gives 125% more.";
		
		public override string RaceHealthDisplayText => "[c/34EB93:+20%]";
		public override string RaceArmorPenetrationDisplayText => "[c/34EB93:+6]";
		public override string RaceMeleeCritChanceDisplayText => "[c/34EB93:+5%]";
		public override string RaceRangedCritChanceDisplayText => "[c/34EB93:+5%]";
		public override string RaceMagicCritChanceDisplayText => "[c/34EB93:+5%]";
		public override string RaceAdditionalNotesDescription1 => "-The race is semi-reliant on knowledge of what could be considered a heat-related Buff in order to unlock it's full potential.";
		public override string RaceAdditionalNotesDescription2 => "-It benefits best at an arena where you can receive 2-4 additional buffs easily.";
		public override string RaceAdditionalNotesDescription3 => "-The max stat boost the passive can grant without a regenerative armor set on is 25.6% endurance and 11.25% Attack.";
		public override string RaceAdditionalNotesDescription4 => "";
		public override string RaceAdditionalNotesDescription5 => "-If I can in the future, this race may be altered to have an offensive ability. Their stats will be somewhat nerfed down when or if this happens.";
		public override string RaceAdditionalNotesDescription6 => "-A kid's episode about Sungazers and their needed time in the sun inspired the mechanics of the ability.";
		
			public override void Load(Player player)
		{
			//if your custom race has increased health, it should also be added here (the player first joins in with vanilla health by default regardless of what their max health is). Does not need to be done with decreased health
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLife += (player.statLifeMax2 / 5);
			}
		}

		
		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLifeMax2 += (player.statLifeMax2 / 5);
				player.armorPenetration += 6;
				player.meleeCrit += 5;
                player.rangedCrit += 5;
                player.magicCrit += 5;
				
				 if (player.HasBuff(74)) // WI. Fire
				 {
					 player.endurance += 0.0720f;
					 player.allDamage += 0.0315f;
				 }
				 if (player.HasBuff(48)) // Honey
				 {
					 player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
				 }
				 if (player.HasBuff(2)) // Regeneration
				 {
					 player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
				 }
				 if (player.HasBuff(58)) // Rapid Healing
				 {
					 player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
				 }
				 if (player.HasBuff(89)) // Heart Lamp
				 {
					 player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
				 }
				 				 if (player.HasBuff(165)) // Dryad's Blessing
				 {
					 player.endurance += 0.0300f;
					 player.allDamage += 0.0105f;
				 }
				 if (player.HasBuff(124)) // Warmth
				 {
					 player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
				 }
				 					  if (player.HasBuff(173)) // Life Nebula I
				  {
					  player.endurance += 0.0320f;
					  player.allDamage += 0.0140f;
				  }
				  
				 if (player.HasBuff(174)) // Life Nebula II
			      {
				    player.endurance += 0.0320f;
					player.allDamage += 0.0140f;
				  }
				  
				 if (player.HasBuff(175)) // Life Nebula III
				     {
		      	     player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
			    	 }

				  
				  if (player.HasBuff(170)) // Solar Blaze I
				  {
					  player.endurance += 0.0320f;
					  player.allDamage += 0.0140f;
				  }
				 if (player.HasBuff(171)) // Solar Blaze II
			      {
				      player.endurance += 0.0320f;
					  player.allDamage += 0.0140f;
				  }
				  
				 if (player.HasBuff(172)) // Solar Blaze III
				     {
		      	     player.endurance += 0.0320f;
					 player.allDamage += 0.0140f;
			    	 }
			  if (player.HasBuff(24)) // On fire
				{
					player.AddBuff(87, 2);
				}
				
				  if (player.HasBuff(67)) // Burning
				{
					player.AddBuff(87, 2);
				}
				  if (player.HasBuff(87))  // Cozy Fire
				  {
					  player.endurance += 0.0320f;
					  player.allDamage += 0.0140f;
				  }
				  
				  if (player.HasBuff(158))  // Star in a Bottle. Stars are hot!
				  {
					  player.endurance += 0.0320f;
					  player.allDamage += 0.0140f;
				  }

				  
				
			}
			
				

		}
		
			public override void ProcessTriggers(Player player, Mod mod)
		{
			//custom hotkey stuff goes here
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				if (MrPlagueRaces.MrPlagueRaces.RacialAbilityHotKey.Current)
				{
				
				if (player.HasBuff(67))
				{
				}
				
				
				}
			}
		}
public override void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo)
        {
			//custom race's default color values and clothing styles go here
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Item familiarshirt = new Item();
            familiarshirt.SetDefaults(ItemID.FamiliarShirt);
            Item familiarpants = new Item();
            familiarpants.SetDefaults(ItemID.FamiliarPants);
            if (modPlayer.resetDefaultColors)
            {
                modPlayer.resetDefaultColors = false;
                player.hairColor = new Color(242, 222, 142);
	            player.skinColor = new Color(253, 56, 70);
	            player.eyeColor = new Color(45, 245, 35);
    			player.skinVariant = 0;
				if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
					player.armor[2] = familiarpants;
				}
			}
		}
	public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
{
	var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();

	bool hideChestplate = modPlayer.hideChestplate;
    bool hideLeggings = modPlayer.hideLeggings;

	Main.playerTextures[0, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head");
	Main.playerTextures[0, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2");
	Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes");
	Main.playerTextures[0, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
	}
	else
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_1");
	}
	else
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
	}
	else
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand");
	Main.playerTextures[0, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
		Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
	}
	else
	{
		Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1_2");
	}
	else
	{
		Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1_2");
	}
	else
	{
		Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head");
	Main.playerTextures[1, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2");
	Main.playerTextures[1, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes");
	Main.playerTextures[1, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
	}
	else
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
	}
	else
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
	}
	else
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand");
	Main.playerTextures[1, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
		Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
	}
	else
	{
		Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2_2");
	}
	else
	{
		Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2_2");
	}
	else
	{
		Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head");
	Main.playerTextures[2, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2");
	Main.playerTextures[2, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes");
	Main.playerTextures[2, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
	}
	else
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
	}
	else
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
	}
	else
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand");
	Main.playerTextures[2, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
		Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
	}
	else
	{
		Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3_2");
	}
	else
	{
		Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3_2");
	}
	else
	{
		Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head");
	Main.playerTextures[3, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2");
	Main.playerTextures[3, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes");
	Main.playerTextures[3, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
	}
	else
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
	}
	else
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
	}
	else
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand");
	Main.playerTextures[3, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
		Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
	}
	else
	{
		Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4_2");
	}
	else
	{
		Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4_2");
	}
	else
	{
		Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head");
	Main.playerTextures[8, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2");
	Main.playerTextures[8, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes");
	Main.playerTextures[8, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
	}
	else
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
	}
	else
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
	}
	else
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand");
	Main.playerTextures[8, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
		Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
	}
	else
	{
		Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9_2");
	}
	else
	{
		Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9_2");
	}
	else
	{
		Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head_Female");
	Main.playerTextures[4, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2_Female");
	Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_Female");
	Main.playerTextures[4, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
	}
	else
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
	}
	else
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
	}
	else
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand_Female");
	Main.playerTextures[4, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs_Female");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
		Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
	}
	else
	{
		Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5_2");
	}
	else
	{
		Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5_2");
	}
	else
	{
		Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head_Female");
	Main.playerTextures[5, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2_Female");
	Main.playerTextures[5, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_Female");
	Main.playerTextures[5, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
	}
	else
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
	}
	else
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
	}
	else
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand_Female");
	Main.playerTextures[5, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs_Female");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
		Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
	}
	else
	{
		Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6_2");
	}
	else
	{
		Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6_2");
	}
	else
	{
		Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head_Female");
	Main.playerTextures[6, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2_Female");
	Main.playerTextures[6, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_Female");
	Main.playerTextures[6, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
	}
	else
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
	}
	else
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
	}
	else
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand_Female");
	Main.playerTextures[6, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs_Female");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
		Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
	}
	else
	{
		Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7_2");
	}
	else
	{
		Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7_2");
	}
	else
	{
		Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head_Female");
	Main.playerTextures[7, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2_Female");
	Main.playerTextures[7, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_Female");
	Main.playerTextures[7, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
	}
	else
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
	}
	else
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
	}
	else
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand_Female");
	Main.playerTextures[7, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs_Female");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
		Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
	}
	else
	{
		Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8_2");
	}
	else
	{
		Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8_2");
	}
	else
	{
		Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Head_Female");
	Main.playerTextures[9, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_2_Female");
	Main.playerTextures[9, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Eyes_Female");
	Main.playerTextures[9, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
	}
	else
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
	}
	else
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
	}
	else
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Hand_Female");
	Main.playerTextures[9, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Legs_Female");

	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
		Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
	}
	else
	{
		Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
		Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10_2");
	}
	else
	{
		Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}
	if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
	{
		Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10_2");
	}
	else
	{
		Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

      for (int i = 0; i < 51; i++)
			{
				Main.playerHairTexture[i] = ModContent.GetTexture($"RogueLineageRaces/Content/RaceTextures/Kasparan/Hair/Kasparan_Hair_1");
			}
			
	Main.ghostTexture = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Kasparan/Kasparan_Ghost");
}

/*
Player sheets are split into 15 different sections ([x, 0] to [x, 14]) and repeated 10 times for each default clothing style and each gender. There are a total of 10 repeats, 5 of which are used for male and 5 of which are used for female.
Clothing sheets are put into an if/else statement to detect whether The familiar clothing is equipped onto The player. If The player is not wearing familiar clothing, The respective clothing sheets will be set to a blank sheet. Otherwise, they will appear as clothing.

Main.playerTextures[0, 0]: The head sheet for clothing style 1 (MALE)
Main.playerTextures[0, 1]: The eye whites sheet for clothing style 1 (MALE)
Main.playerTextures[0, 2]: The eye iris sheet for clothing style 1 (MALE)
Main.playerTextures[0, 3]: The torso sheet for clothing style 1 (MALE)
Main.playerTextures[0, 4]: The clothing sleeves sheet for clothing style 1 (MALE)
Main.playerTextures[0, 5]: The hands sheet for clothing style 1 (MALE)
Main.playerTextures[0, 6]: The clothing shirt sheet for clothing style 1 (MALE)
Main.playerTextures[0, 7]: The arm sheet for clothing style 1 (MALE)
Main.playerTextures[0, 8]: The clothing singular sleeve sheet for clothing style 1 (MALE)
Main.playerTextures[0, 9]: The singular hand sheet for clothing style 1 (MALE)
Main.playerTextures[0, 10]: The legs sheet for clothing style 1 (MALE)
Main.playerTextures[0, 11]: The clothing pants sheet for clothing style 1 (MALE)
Main.playerTextures[0, 12]: The clothing shoes sheet for clothing style 1 (MALE)
Main.playerTextures[0, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
Main.playerTextures[0, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

Main.playerTextures[1, 0]: The head sheet for clothing style 2 (MALE)
Main.playerTextures[1, 1]: The eye whites sheet for clothing style 2 (MALE)
Main.playerTextures[1, 2]: The eye iris sheet for clothing style 2 (MALE)
Main.playerTextures[1, 3]: The torso sheet for clothing style 2 (MALE)
Main.playerTextures[1, 4]: The clothing sleeves sheet for clothing style 2 (MALE)
Main.playerTextures[1, 5]: The hands sheet for clothing style 2 (MALE)
Main.playerTextures[1, 6]: The clothing shirt sheet for clothing style 2 (MALE)
Main.playerTextures[1, 7]: The arm sheet for clothing style 2 (MALE)
Main.playerTextures[1, 8]: The clothing singular sleeve sheet for clothing style 2 (MALE)
Main.playerTextures[1, 9]: The singular hand sheet for clothing style 2 (MALE)
Main.playerTextures[1, 10]: The legs sheet for clothing style 2 (MALE)
Main.playerTextures[1, 11]: The clothing pants sheet for clothing style 2 (MALE)
Main.playerTextures[1, 12]: The clothing shoes sheet for clothing style 2 (MALE)
Main.playerTextures[1, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
Main.playerTextures[1, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)


Main.playerTextures[2, 0]: The head sheet for clothing style 3 (MALE)
Main.playerTextures[2, 1]: The eye whites sheet for clothing style 3 (MALE)
Main.playerTextures[2, 2]: The eye iris sheet for clothing style 3 (MALE)
Main.playerTextures[2, 3]: The torso sheet for clothing style 3 (MALE)
Main.playerTextures[2, 4]: The clothing sleeves sheet for clothing style 3 (MALE)
Main.playerTextures[2, 5]: The hands sheet for clothing style 3 (MALE)
Main.playerTextures[2, 6]: The clothing shirt sheet for clothing style 3 (MALE)
Main.playerTextures[2, 7]: The arm sheet for clothing style 3 (MALE)
Main.playerTextures[2, 8]: The clothing singular sleeve sheet for clothing style 3 (MALE)
Main.playerTextures[2, 9]: The singular hand sheet for clothing style 3 (MALE)
Main.playerTextures[2, 10]: The legs sheet for clothing style 3 (MALE)
Main.playerTextures[2, 11]: The clothing pants sheet for clothing style 3 (MALE)
Main.playerTextures[2, 12]: The clothing shoes sheet for clothing style 3 (MALE)
Main.playerTextures[2, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
Main.playerTextures[2, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

Main.playerTextures[3, 0]: The head sheet for clothing style 4 (MALE)
Main.playerTextures[3, 1]: The eye whites sheet for clothing style 4 (MALE)
Main.playerTextures[3, 2]: The eye iris sheet for clothing style 4 (MALE)
Main.playerTextures[3, 3]: The torso sheet for clothing style 4 (MALE)
Main.playerTextures[3, 4]: The clothing sleeves sheet for clothing style 4 (MALE)
Main.playerTextures[3, 5]: The hands sheet for clothing style 4 (MALE)
Main.playerTextures[3, 6]: The clothing shirt sheet for clothing style 4 (MALE)
Main.playerTextures[3, 7]: The arm sheet for clothing style 4 (MALE)
Main.playerTextures[3, 8]: The clothing singular sleeve sheet for clothing style 4 (MALE)
Main.playerTextures[3, 9]: The singular hand sheet for clothing style 4 (MALE)
Main.playerTextures[3, 10]: The legs sheet for clothing style 4 (MALE)
Main.playerTextures[3, 11]: The clothing pants sheet for clothing style 4 (MALE)
Main.playerTextures[3, 12]: The clothing shoes sheet for clothing style 4 (MALE)
Main.playerTextures[3, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
Main.playerTextures[3, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

Main.playerTextures[8, 0]: The head sheet for clothing style 5 (MALE)
Main.playerTextures[8, 1]: The eye whites sheet for clothing style 5 (MALE)
Main.playerTextures[8, 2]: The eye iris sheet for clothing style 5 (MALE)
Main.playerTextures[8, 3]: The torso sheet for clothing style 5 (MALE)
Main.playerTextures[8, 4]: The clothing sleeves sheet for clothing style 5 (MALE)
Main.playerTextures[8, 5]: The hands sheet for clothing style 5 (MALE)
Main.playerTextures[8, 6]: The clothing shirt sheet for clothing style 5 (MALE)
Main.playerTextures[8, 7]: The arm sheet for clothing style 5 (MALE)
Main.playerTextures[8, 8]: The clothing singular sleeve sheet for clothing style 5 (MALE)
Main.playerTextures[8, 9]: The singular hand sheet for clothing style 5 (MALE)
Main.playerTextures[8, 10]: The legs sheet for clothing style 5 (MALE)
Main.playerTextures[8, 11]: The clothing pants sheet for clothing style 5 (MALE)
Main.playerTextures[8, 12]: The clothing shoes sheet for clothing style 5 (MALE)
Main.playerTextures[8, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
Main.playerTextures[8, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

Main.playerTextures[4, 0]: The head sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 1]: The eye whites sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 2]: The eye iris sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 3]: The torso sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 4]: The clothing sleeves sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 5]: The hands sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 6]: The clothing shirt sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 7]: The arm sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 8]: The clothing singular sleeve sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 9]: The singular hand sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 10]: The legs sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 11]: The clothing pants sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 12]: The clothing shoes sheet for clothing style 1 (FEMALE)
Main.playerTextures[4, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
Main.playerTextures[4, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

Main.playerTextures[5, 0]: The head sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 1]: The eye whites sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 2]: The eye iris sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 3]: The torso sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 4]: The clothing sleeves sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 5]: The hands sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 6]: The clothing shirt sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 7]: The arm sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 8]: The clothing singular sleeve sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 9]: The singular hand sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 10]: The legs sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 11]: The clothing pants sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 12]: The clothing shoes sheet for clothing style 2 (FEMALE)
Main.playerTextures[5, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
Main.playerTextures[5, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)


Main.playerTextures[6, 0]: The head sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 1]: The eye whites sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 2]: The eye iris sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 3]: The torso sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 4]: The clothing sleeves sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 5]: The hands sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 6]: The clothing shirt sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 7]: The arm sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 8]: The clothing singular sleeve sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 9]: The singular hand sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 10]: The legs sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 11]: The clothing pants sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 12]: The clothing shoes sheet for clothing style 3 (FEMALE)
Main.playerTextures[6, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
Main.playerTextures[6, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

Main.playerTextures[7, 0]: The head sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 1]: The eye whites sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 2]: The eye iris sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 3]: The torso sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 4]: The clothing sleeves sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 5]: The hands sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 6]: The clothing shirt sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 7]: The arm sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 8]: The clothing singular sleeve sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 9]: The singular hand sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 10]: The legs sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 11]: The clothing pants sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 12]: The clothing shoes sheet for clothing style 4 (FEMALE)
Main.playerTextures[7, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
Main.playerTextures[7, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

Main.playerTextures[9, 0]: The head sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 1]: The eye whites sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 2]: The eye iris sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 3]: The torso sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 4]: The clothing sleeves sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 5]: The hands sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 6]: The clothing shirt sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 7]: The arm sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 8]: The clothing singular sleeve sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 9]: The singular hand sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 10]: The legs sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 11]: The clothing pants sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 12]: The clothing shoes sheet for clothing style 5 (FEMALE)
Main.playerTextures[9, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
Main.playerTextures[9, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
*/
		}
	}