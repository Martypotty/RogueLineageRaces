using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;

namespace RogueLineageRaces.Common.Races.Vind
{
	public class Vind : Race
	{
		public override string RaceSelectIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/VindSelectIcon");
		public override string RaceDisplayMaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/VindDisplayMale");
		public override string RaceDisplayFemaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/VindDisplayFemale");
		
		public override string RaceDisplayName => "Vinds of the Plane";
		public override string RaceLore1 => "Vinds are a race" + "\noriented around mages" + "\nand inhibiting some-"  +  "\nones battle plan"  +  "\nconstantly.";
		public override string RaceLore2 => "Originating from the Plane of Wind" + "\nbefore moving to Gaia, there" + "\naren't many of them left who still" + "\nlive at the Castle in the Sky.";
		
		public override string RaceEnvironmentIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Vind");
		public override string RaceEnvironmentOverlay2Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/Multiple");
		public override string RaceEnvironmentOverlay1Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/VindEnvironment");
		
		public override string RaceAbilityName => "Tempest Twist (Active)";
		public override string RaceAbilityDescription1 => "You swap between a Health Nebula and 2 Mana Nebulas; starting with the Health Nebula.";
		public override string RaceAbilityDescription2 => "The Health Nebula lasts for 2.5 seconds before swapping. The Mana Nebulas last for 3.5 seconds.";
		public override string RaceAbilityDescription3 => "During the Health Nebula you become nearly immune to damage and will reflect back upclose attacks against enemies.";
		public override string RaceAbilityDescription4 => "During the Mana Nebulas you become faster.";
		public override string RaceAbilityDescription5 => "Both swaps have thorns and movement, however they have over 2x the amount during their respective turns. ";
		
		public override string RaceMagicDamageDisplayText => "[c/34EB93:+10%]";
		public override string RaceSummonDamageDisplayText => "[c/34EB93:+20%]";
        public override string RaceRegenerationDisplayText => "[c/34EB93:Life/120]";
		public override string RaceManaRegenerationDisplayText => "[c/34EB93:+30]";
		public override string RaceAdditionalNotesDescription4 => "Contrary to popular belief, Vinds do not have mana regen in rogue.. Don't ask why I gave Fischerans it. They don't either.";
		public override string RaceAdditionalNotesDescription5 => "Lore seen in the Race's description is mostly an attempt of what I remember. I may look up some of vohl's videos later to correct it.";
		public override string RaceAdditionalNotesDescription1 => "-Like Dullahans, their health regeneration increases based on their max health.";
		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{	
                 player.lifeRegen += (player.statLifeMax2 / 120);
				 player.manaRegenBonus += 30;
                 player.magicDamage += .1f;
                 player.minionDamage += 0.2f;
		
				if (player.HasBuff(186))
				{
				  player.moveSpeed += 0.15f;
				  player.thorns += 0.75f;
				    //
				    if (player.HasBuff(204))
					{
						player.AddBuff(203, 210);
						player.AddBuff(173, 1);
						player.thorns += 1.25f;
						player.AddBuff(170, 1);
						player.endurance += 1f;
						player.AddBuff(88, 1021);
						player.longInvince = false;
					}
					
					else if (player.HasBuff(203))
					{
						player.AddBuff(177, 1);
						player.moveSpeed += 0.25f;
						player.AddBuff(88, 1021);
					}
					
					else
					{
						player.AddBuff(88, 1021);
					}
					
					if (player.HasBuff(137))
					{
					}
					
					else
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, Mod.GetSoundSlot(SoundType.Custom, "Sounds/" + this.Name + "_Tempestdone"));
					//
					}
					
				    //
				
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
				if (player.HasBuff(88))
				{
				}
				
				else

                {
					player.AddBuff(186, 356);
					player.AddBuff(137, 4);
					player.AddBuff(204, 150);
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, Mod.GetSoundSlot(SoundType.Custom, "Sounds/" + this.Name + "_TempestGo"));
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
                player.hairColor = new Color(85, 85, 85);
	            player.skinColor = new Color(235, 185, 235);
	            player.eyeColor = new Color(195, 135, 195);
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

    Main.playerTextures[0, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head");
	Main.playerTextures[0, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso");
	
	if (player.HasBuff(186))
	{
		
	if (player.HasBuff(204))
	{
	     Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Orange1");
	}
	else if (player.HasBuff(203))
	{
		Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Orange");
	}
	}
	else
	{
		Main.playerTextures[0, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2");
	    Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes");
	}
	


	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
	}
	else
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_1");
	}
	else
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
	}
	else
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand");
	Main.playerTextures[0, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs");

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

	Main.playerTextures[1, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head");
	Main.playerTextures[1, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2");
	Main.playerTextures[1, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes");
	Main.playerTextures[1, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
	}
	else
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
	}
	else
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
	}
	else
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand");
	Main.playerTextures[1, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs");

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

	Main.playerTextures[2, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head");
	Main.playerTextures[2, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2");
	Main.playerTextures[2, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes");
	Main.playerTextures[2, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
	}
	else
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
	}
	else
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
	}
	else
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand");
	Main.playerTextures[2, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs");

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

	Main.playerTextures[3, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head");
	Main.playerTextures[3, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2");
	Main.playerTextures[3, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes");
	Main.playerTextures[3, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
	}
	else
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
	}
	else
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
	}
	else
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand");
	Main.playerTextures[3, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs");

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

	Main.playerTextures[8, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head");
	Main.playerTextures[8, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2");
	Main.playerTextures[8, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes");
	Main.playerTextures[8, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
	}
	else
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
	}
	else
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
	}
	else
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand");
	Main.playerTextures[8, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs");

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

	Main.playerTextures[4, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso_Female");
	Main.playerTextures[4, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head_Female");
	if (player.HasBuff(186))
	{
	if (player.HasBuff(204))
	{
	     Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Orange1");
	}
	else if (player.HasBuff(203))
	{
		Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Orange");
	}
	}
	else
	{
		Main.playerTextures[4, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2_Female");
	    Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_Female");
    }
	
	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
	}
	else
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
	}
	else
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
	}
	else
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand_Female");
	Main.playerTextures[4, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs_Female");

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

	Main.playerTextures[5, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head_Female");
	Main.playerTextures[5, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2_Female");
	Main.playerTextures[5, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_Female");
	Main.playerTextures[5, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
	}
	else
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
	}
	else
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
	}
	else
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand_Female");
	Main.playerTextures[5, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs_Female");

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

	Main.playerTextures[6, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head_Female");
	Main.playerTextures[6, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2_Female");
	Main.playerTextures[6, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_Female");
	Main.playerTextures[6, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
	}
	else
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
	}
	else
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
	}
	else
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand_Female");
	Main.playerTextures[6, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs_Female");

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

	Main.playerTextures[7, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head_Female");
	Main.playerTextures[7, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2_Female");
	Main.playerTextures[7, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_Female");
	Main.playerTextures[7, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
	}
	else
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
	}
	else
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
	}
	else
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand_Female");
	Main.playerTextures[7, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs_Female");

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

	Main.playerTextures[9, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Head_Female");
	Main.playerTextures[9, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_2_Female");
	Main.playerTextures[9, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Eyes_Female");
	Main.playerTextures[9, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
	}
	else
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
	}
	else
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
	}
	else
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Hand_Female");
	Main.playerTextures[9, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Legs_Female");

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
				Main.playerHairTexture[i] = ModContent.GetTexture($"RogueLineageRaces/Content/RaceTextures/Vind/Hair/Human_Hair_{i + 1}");
			}
			
	Main.ghostTexture = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Vind/Vind_Ghost");
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