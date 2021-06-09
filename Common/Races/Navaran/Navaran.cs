using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;

namespace RogueLineageRaces.Common.Races.Navaran
{
	public class Navaran : Race
	{
		public override string RaceSelectIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/NavaranSelectIcon");
		public override string RaceDisplayMaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/NavaranDisplayMale");
		public override string RaceDisplayFemaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/NavaranDisplayFemale");
		
		public override string RaceDisplayName => "Navarans of an Entity";
		public override string RaceLore1 => "Navarans are a race" + "\noriented around the" + "\nusage of outside"  +  "\nsources to create a"  +  "\nchanging & frightful build.";
		public override string RaceLore2 => "An alien entity split into fragments" + "\nfor an unknown purpose, not much" + "\nis known about It besides It's copying" + "\nfrom & brutal battling with others.";
		
		public override string RaceEnvironmentIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Navaran");
		public override string RaceEnvironmentOverlay2Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/Multiple");
		public override string RaceEnvironmentOverlay1Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/NavaranEnvironment");
		
		public override string RaceAbilityName => "Advanced Emulate";
		public override string RaceAbilityDescription1 => "When afflicted by Poison, Burning, Sharpened, Stoned, and even Werewolf, press the ability button to gain a Flask ability + buff.";
		public override string RaceAbilityDescription2 => "Emulation lasts forever unless you cancel the flask buff that comes with it. Only one emulation can be active at a time.";
		public override string RaceAbilityDescription3 => "Flasks can be used to artificially cause the Emulation buffs that go alongside it to occur.";
		public override string RaceAbilityDescription4 => "Nanite flask buff + Dryad's Blessing and or a Water Candle effect grants you an upgraded version of Poison and Burning respectively.";
		public override string RaceAbilityDescription6 => "Not to be confused with non-Lesser Navaran emulation!";
		
		public override string RaceAdditionalNotesDescription1 => "-Without emulating something, Navaran is pretty basic. It may be best to get hit purposely by a Dart trap to emulate something from the Poison.";
		public override string RaceAdditionalNotesDescription2 => "-With emulation comes a couple of buffs! Not only do you gain a permanent [unless removed or emulated over] flask effect, but you also gain";
		public override string RaceAdditionalNotesDescription3 => "1-4 other buffs alongside it!";
		public override string RaceAdditionalNotesDescription4 => "Every flask buff has build-type buffs to go alongside them.";
		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				    if (player.HasBuff(74)) // Fire. Great for attracting fishies!.. Oh, and also for fighting off your enemies, too.
				{
					player.AddBuff(121, 2);
					player.AddBuff(74, 2);
					player.allDamage += 0.1f;
					player.meleeDamage -= 0.05f;
				}
				
				else if (player.HasBuff(79)) // Poison. Health regen based! Fairly weak emulation, though.
				{
					player.AddBuff(48, 2);
					player.AddBuff(2, 2);
					player.AddBuff(79, 2);
					player.allDamage += 0.05f;
					player.meleeDamage -= 0.05f;
				}
				
				else if (player.HasBuff(77)) //Nanites. Codeable nanobots?
                {
					player.AddBuff(14, 2);
					player.AddBuff(77, 2);
					player.AddBuff(62, 2);
					player.allDamage += 0.15f;
					player.meleeDamage -= 0.15f;
                }
				
				else if (player.HasBuff(76)) //Ichor. Defensive and Oppresive! >:D
				{
					player.AddBuff(115, 2);
					player.AddBuff(76, 2);
					player.allDamage -= 0.20f;
					player.statDefense += 18;
				}
				
				else if (player.HasBuff(75)) //Midas. For those looking to save on golfcar insurance.
				{
					player.AddBuff(93, 2);
					player.AddBuff(26, 2);
					player.AddBuff(75, 2);
					player.AddBuff(11, 2);
					player.allDamage -= 0.10f;
					player.statDefense += 8;
				}
				
				else if (player.HasBuff(71)) //Acid Venom. An upgrade to regular Poison.
				{
					player.AddBuff(71,2);
					player.AddBuff(58,2);
					player.AddBuff(48,2);
					player.lifeRegen -= 5;
					player.allDamage += 0.15f;
					player.meleeDamage -= 0.05f;
					player.AddBuff(2, 2);
				}
				
				else if (player.HasBuff(73)) //Cursed Flames. An upgrade to normal Fire.
				{
					player.AddBuff(73,2);
					player.AddBuff(121,2);
					player.AddBuff(123,2);
					player.AddBuff(111,2);
					player.allDamage += 0.15f;
					player.meleeDamage -= 0.05f;
				}
				
				else if (player.HasBuff(78)) //Confetti. The kind of buff that makes you boogy.
				{
					player.AddBuff(88, 2);
					player.AddBuff(63, 2);
					player.AddBuff(15, 2);
					player.AddBuff(109, 2);
					player.AddBuff(78, 2);
					player.allDamage += .25f; // The consequences for your actions, Woo!
					player.endurance -= 2.5f; // The consequences for your actions..
					
					player.maxRunSpeed += 1.4f; // Lightning boots+
					player.longInvince = true; // Cross Necklace
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
					player.AddBuff(74, 2);
					player.AddBuff(121, 2);
				}
				
				else if (player.HasBuff(20))
				{
					player.AddBuff(79, 2);
					player.AddBuff(48, 2);
				}
				
				else if (player.HasBuff(28))
                {
					player.AddBuff(77, 2);
                }
				
				else if (player.HasBuff(156))
				{
					player.AddBuff(115, 2);
					player.AddBuff(76, 2);
				}
				
				else if (player.HasBuff(159))
				{
					player.AddBuff(75, 2);
					player.AddBuff(93, 2);
					player.AddBuff(26, 2);
				}
				
				else if (player.HasBuff(165))
				{
					if (player.HasBuff(77))
					{
						player.AddBuff(71, 8);
						player.AddBuff(11, 180);
						player.AddBuff(59, 20);
						
						if (player.HasBuff(165))
						{
							player.AddBuff(71, 8);
						}
					}
				}
				
				else if (player.HasBuff(86))

				{
					if (player.HasBuff(77))
					{
						player.AddBuff(73, 8);
					    player.AddBuff(11, 180);
						player.AddBuff(59, 20);
						
						if (player.HasBuff(86))
						{
							player.AddBuff(73, 8);
						}
					}
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
                player.hairColor = new Color(169, 190, 184);
	            player.skinColor = new Color(163, 175, 163);
	            player.eyeColor = new Color(45, 45, 45);
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

	Main.playerTextures[0, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head");
	Main.playerTextures[0, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2");
	Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes");
	Main.playerTextures[0, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
	}
	else
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_1");
	}
	else
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
	}
	else
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand");
	Main.playerTextures[0, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs");

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

	Main.playerTextures[1, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head");
	Main.playerTextures[1, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2");
	Main.playerTextures[1, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes");
	Main.playerTextures[1, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
	}
	else
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
	}
	else
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
	}
	else
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand");
	Main.playerTextures[1, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs");

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

	Main.playerTextures[2, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head");
	Main.playerTextures[2, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2");
	Main.playerTextures[2, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes");
	Main.playerTextures[2, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
	}
	else
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
	}
	else
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
	}
	else
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand");
	Main.playerTextures[2, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs");

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

	Main.playerTextures[3, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head");
	Main.playerTextures[3, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2");
	Main.playerTextures[3, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes");
	Main.playerTextures[3, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
	}
	else
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
	}
	else
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
	}
	else
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand");
	Main.playerTextures[3, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs");

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

	Main.playerTextures[8, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head");
	Main.playerTextures[8, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2");
	Main.playerTextures[8, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes");
	Main.playerTextures[8, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
	}
	else
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
	}
	else
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
	}
	else
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand");
	Main.playerTextures[8, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs");

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

	Main.playerTextures[4, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head_Female");
	Main.playerTextures[4, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2_Female");
	Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_Female");
	Main.playerTextures[4, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
	}
	else
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
	}
	else
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
	}
	else
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand_Female");
	Main.playerTextures[4, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs_Female");

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

	Main.playerTextures[5, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head_Female");
	Main.playerTextures[5, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2_Female");
	Main.playerTextures[5, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_Female");
	Main.playerTextures[5, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
	}
	else
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
	}
	else
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
	}
	else
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand_Female");
	Main.playerTextures[5, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs_Female");

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

	Main.playerTextures[6, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head_Female");
	Main.playerTextures[6, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2_Female");
	Main.playerTextures[6, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_Female");
	Main.playerTextures[6, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
	}
	else
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
	}
	else
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
	}
	else
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand_Female");
	Main.playerTextures[6, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs_Female");

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

	Main.playerTextures[7, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head_Female");
	Main.playerTextures[7, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2_Female");
	Main.playerTextures[7, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_Female");
	Main.playerTextures[7, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
	}
	else
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
	}
	else
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
	}
	else
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand_Female");
	Main.playerTextures[7, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs_Female");

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

	Main.playerTextures[9, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Head_Female");
	Main.playerTextures[9, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_2_Female");
	Main.playerTextures[9, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Eyes_Female");
	Main.playerTextures[9, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
	}
	else
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
	}
	else
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
	}
	else
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Hand_Female");
	Main.playerTextures[9, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Legs_Female");

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


			
	Main.ghostTexture = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Navaran/Navaran_Ghost");
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