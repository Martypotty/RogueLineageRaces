using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;

namespace RogueLineageRaces.Common.Races.Haseldan
{
	public class Haseldan : Race
	{
		public override string RaceSelectIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/HaseldanSelectIcon");
		public override string RaceDisplayMaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/HaseldanDisplayMale");
		public override string RaceDisplayFemaleIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/HaseldanDisplayFemale");
		
		public override string RaceDisplayName => "Haseldans Of Gaia";
		public override string RaceLore1 => "Haseldans are a race oriented around risking it/making a great come back.";
		public override string RaceLore2 => "Their stubbornness and strong will to live has helped them stay focused in battle and to withstand more pain.";
		
		public override string RaceEnvironmentIcon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Haseldan");
		public override string RaceEnvironmentOverlay2Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/Damaging");
		public override string RaceEnvironmentOverlay1Icon => ($"RogueLineageRaces/Common/UI/RaceDisplay/Environment/HaseldanEnvironment");
		
		public override string RaceAllDamageDisplayText => "[c/34EB93:+10%]";
		public override string RaceDamageReductionDisplayText => "[c/34EB93:+15%]";
		public override string RaceAbilityName => "Final Stand (Passive)";
		public override string RaceAbilityDescription1 => "Their health will slowly drain when at 20% or below. However, their damage and resistance will also skyrocket compared to before.";
		public override string RaceAbilityDescription2 => "You can cancel this ability by healing above 20%. When reaching 5% you will exit Final Stand.";
		public override string RaceAbilityDescription3 => "When you exit Final Stand via reaching 5% health, you will temporarily lose a great amount of endurance and mobility.";
		public override string RaceAbilityDescription4 => "You cannot re-enter Final Stand until you recover from 'Dazed'. Final Stand severely weakens/disables vanilla healing buffs.";
		public override string RaceAbilityDescription5 => "Your damage will be lowered during recovery. Your health regen is boosted when recovering.";

		public override string RaceAdditionalNotesDescription1 => "-Takes no knockback unless they have entered into a 'deep recovery' from Final Stand. Deep recovery is when a Haseldan falls below 5% of their max health and are attempting to recover from Final Stand.";
		public override string RaceAdditionalNotesDescription2 => "-It's damage bonus applies to everything. Summons, magic, grenades. Any damage type should work.";
		public override string RaceAdditionalNotesDescription3 => "-Life draining effects struggle to finish you off the more max health you have access to.";
		public override string RaceAdditionalNotesDescription4 => "-Frozen turtle shell and the Endurance buff have their normal benefits when you're not utilizing Final stand. [Final stand will cut down on their endurance.]";
		
		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.allDamage += 0.10f;
				player.endurance += 0.15f;
				player.noKnockback = true;
				 if (player.HasBuff(160))
                {
					player.AddBuff(80, 4);
					player.lifeRegen += (player.statLifeMax2 * 2 / 100);
					player.noKnockback = false;
					player.allDamage += 0.9f;
					player.endurance -= 0.40f;
					player.moveSpeed += 0.27f;
					player.runAcceleration += 0.0675f;
					player.jumpSpeedBoost += 10f;
                }
                else if (player.statLife <= (player.statLifeMax2 * 0.20))
				 {
				    player.lifeRegen -= (player.statLifeMax2 * 1 / 120);
					player.lifeRegen -= 5;
                    player.allDamage += 1.9f;
                    player.endurance += 0.60f;
					player.statDefense -= 50;
					player.bleed = true;
					player.AddBuff(2, 2);
					player.AddBuff(BuffID.WitheredWeapon, 500);
					player.AddBuff(BuffID.Stinky, 2);
					
					if (player.HasBuff(48))
			{
				player.lifeRegen -= 5;
			}
				if (player.HasBuff(89))
			{
				player.lifeRegen -= 4 / 3;
			}
					if (player.HasBuff(62)) // Frozen Turtle stuff
				  {
					player.endurance -= 0.19f;
				  }
				  
				  if (player.HasBuff(114)) // Endurance Potion
				  {
					player.endurance -= 0.070f;
				  }
				if (player.HasBuff(165))
			{
				player.lifeRegen -= 3;
			}
				if (player.HasBuff(173))
			{
				player.lifeRegen -= 9;
			}
			    if (player.HasBuff(174))
			{
				player.lifeRegen -= 20;
			}
			    if (player.HasBuff(175))
			{
				player.lifeRegen -= 28;
			}
			if (player.HasBuff(48))
			{
				if (player.HasBuff(89))
			{
				player.lifeRegen -= 1;
			}
				if (player.HasBuff(87))
			{
				player.lifeRegen -= 4 / 3;
			}
				if (player.HasBuff(165))
			{
				player.lifeRegen -= 6;
			}
				if (player.HasBuff(173))
			{
				player.lifeRegen -= 24;
			}
			    if (player.HasBuff(174))
			{
				player.lifeRegen -= 43;
			}
			    if (player.HasBuff(175))
			{
				player.lifeRegen -= 56;
			}
			}
           
					
				 }
				 
				 if (player.statLife <= (player.statLifeMax2 * 0.35))
                {
                   player.endurance += 0.05f;
                }

				 if (player.statLife <= (player.statLifeMax2 * 0.05))
                {
					player.lifeRegen += 3;
					player.allDamage -= 0.35f;
					player.statDefense -= 40;
					player.AddBuff(160, 1800);
					player.AddBuff(163, 80);
		            player.AddBuff(BuffID.WitheredWeapon, 1800);
					player.AddBuff(BuffID.BetsysCurse, 1800);
                }
				if (player.statLife <= (player.statLifeMax2 * 0.035))
				{
                if (player.lifeRegenCount <= 0) //life regen protection
                {
                    player.lifeRegenCount = 10;
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
                player.hairColor = new Color(78, 50, 0);
             	player.skinColor = new Color(255, 255, 54);
	            player.eyeColor = new Color(155, 115, 0);
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

	Main.playerTextures[0, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head");
	Main.playerTextures[0, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2");
	Main.playerTextures[0, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes");
	Main.playerTextures[0, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
	}
	else
	{
		Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_1");
	}
	else
	{
		Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
	}
	else
	{
		Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[0, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand");
	Main.playerTextures[0, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs");

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

	Main.playerTextures[1, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head");
	Main.playerTextures[1, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2");
	Main.playerTextures[1, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes");
	Main.playerTextures[1, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
	}
	else
	{
		Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
	}
	else
	{
		Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
	}
	else
	{
		Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[1, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand");
	Main.playerTextures[1, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs");

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

	Main.playerTextures[2, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head");
	Main.playerTextures[2, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2");
	Main.playerTextures[2, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes");
	Main.playerTextures[2, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
	}
	else
	{
		Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
	}
	else
	{
		Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
	}
	else
	{
		Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[2, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand");
	Main.playerTextures[2, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs");

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

	Main.playerTextures[3, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head");
	Main.playerTextures[3, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2");
	Main.playerTextures[3, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes");
	Main.playerTextures[3, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
	}
	else
	{
		Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
	}
	else
	{
		Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
	}
	else
	{
		Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[3, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand");
	Main.playerTextures[3, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs");

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

	Main.playerTextures[8, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head");
	Main.playerTextures[8, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2");
	Main.playerTextures[8, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes");
	Main.playerTextures[8, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
	}
	else
	{
		Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
	}
	else
	{
		Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
	}
	else
	{
		Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[8, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand");
	Main.playerTextures[8, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs");

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

	Main.playerTextures[4, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head_Female");
	Main.playerTextures[4, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2_Female");
	Main.playerTextures[4, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_Female");
	Main.playerTextures[4, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
	}
	else
	{
		Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
	}
	else
	{
		Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
	}
	else
	{
		Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[4, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand_Female");
	Main.playerTextures[4, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs_Female");

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

	Main.playerTextures[5, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head_Female");
	Main.playerTextures[5, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2_Female");
	Main.playerTextures[5, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_Female");
	Main.playerTextures[5, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
	}
	else
	{
		Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
	}
	else
	{
		Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
	}
	else
	{
		Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[5, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand_Female");
	Main.playerTextures[5, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs_Female");

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

	Main.playerTextures[6, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head_Female");
	Main.playerTextures[6, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2_Female");
	Main.playerTextures[6, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_Female");
	Main.playerTextures[6, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
	}
	else
	{
		Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
	}
	else
	{
		Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
	}
	else
	{
		Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[6, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand_Female");
	Main.playerTextures[6, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs_Female");

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

	Main.playerTextures[7, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head_Female");
	Main.playerTextures[7, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2_Female");
	Main.playerTextures[7, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_Female");
	Main.playerTextures[7, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
	}
	else
	{
		Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
	}
	else
	{
		Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
	}
	else
	{
		Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[7, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand_Female");
	Main.playerTextures[7, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs_Female");

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

	Main.playerTextures[9, 0] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Head_Female");
	Main.playerTextures[9, 1] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_2_Female");
	Main.playerTextures[9, 2] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Eyes_Female");
	Main.playerTextures[9, 3] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Torso_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
	}
	else
	{
		Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 5] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hands_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
	}
	else
	{
		Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 7] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Arm_Female");

	if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
	}
	else
	{
		Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	}

	Main.playerTextures[9, 9] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Hand_Female");
	Main.playerTextures[9, 10] = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Legs_Female");

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
	Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
    Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

	Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
	Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

for (int i = 0; i < 51; i++)
			{
				Main.playerHairTexture[i] = ModContent.GetTexture($"RogueLineageRaces/Content/RaceTextures/Haseldan/Hair/Human_Hair_{i + 1}");
			}
	Main.ghostTexture = ModContent.GetTexture("RogueLineageRaces/Content/RaceTextures/Haseldan/Haseldan_Ghost");
}
	}
}