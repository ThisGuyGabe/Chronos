using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.GameInput;
using Chronos;

namespace Chronos
{
    public class ChronosPlayer : ModPlayer
    {
        public bool ichorThrower = false;
        public bool flameThrower = false;
        public bool chromeThrower = false;

        public override void ResetEffects()
        {
            ichorThrower = false;
            flameThrower = false;
            chromeThrower = false;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.Next(3) == 1)
            {
                if (target.life > 0)
                {
                    if (ichorThrower) // Use 'if (ichorThrower)' instead of 'if (ichorThrower = true)'
                    {
                        target.AddBuff(BuffID.Ichor, 1200); // 120 frames = 2 seconds
                    }
                    else if (flameThrower)
                    {
                        target.AddBuff(BuffID.CursedInferno, 1200); // 120 frames = 2 seconds
                    }
                }
            }
            if (chromeThrower && IsWorldEvilMonster(target.type))
            {
                int lifeSteal = 20;
                Player.statLife += lifeSteal;
                Player.HealEffect(lifeSteal);
            }
        }

        private bool IsWorldEvilMonster(int npcType)
        {
            // Replace these IDs with the appropriate IDs for your world evil monsters
            int[] worldEvilMonsterIDs = { NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.BloodCrawler, NPCID.FaceMonster, NPCID.BigCrimera, NPCID.LittleCrimera, NPCID.Crimera , NPCID.Herpling, NPCID.FloatyGross, NPCID.Crimslime, NPCID.CrimsonAxe, NPCID.IchorSticker, NPCID.BigEater, NPCID.LittleEater, NPCID.EaterofSouls, NPCID.Corruptor, NPCID.CorruptSlime, NPCID.DarkMummy };

            return worldEvilMonsterIDs.Contains(npcType);
        }
    }
}