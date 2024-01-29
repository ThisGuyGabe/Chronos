using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            if (Main.rand.NextBool(3))
            {
                if (target.life > 0)
                {
                    if (ichorThrower)
                    {
                        target.AddBuff(BuffID.Ichor, 1200);
                    }
                    else if (flameThrower)
                    {
                        target.AddBuff(BuffID.CursedInferno, 1200);
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

        private static bool IsWorldEvilMonster(int npcType)
        {
            int[] worldEvilMonsterIDs = { NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.BloodCrawler, NPCID.FaceMonster, NPCID.BigCrimera, NPCID.LittleCrimera, NPCID.Crimera, NPCID.Herpling, NPCID.FloatyGross, NPCID.Crimslime, NPCID.CrimsonAxe, NPCID.IchorSticker, NPCID.BigEater, NPCID.LittleEater, NPCID.EaterofSouls, NPCID.Corruptor, NPCID.CorruptSlime, NPCID.DarkMummy };

            return worldEvilMonsterIDs.Contains(npcType);
        }
    }
}