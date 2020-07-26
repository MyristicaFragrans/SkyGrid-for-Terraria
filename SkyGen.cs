using System.Collections.Generic;
using System.Net.Mail;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.World.Generation;
using Terraria.ModLoader.Config;
using Terraria.ID;
using System.Linq;

namespace SkyGrid {
    class SkyGen : ModWorld {
        private static int[] exclude = new int[] { TileID.Trees, TileID.ChristmasTree, TileID.PineTree, TileID.PalmTree, TileID.MushroomTrees,
        TileID.BlueDungeonBrick, TileID.PinkDungeonBrick, TileID.GreenDungeonBrick, TileID.LihzahrdAltar, TileID.LihzahrdBrick, TileID.LihzahrdFurnace, 21}; //21 are all chests
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            tasks.Add(new PassLegacy("SkyGrid", delegate (GenerationProgress progress) {
                progress.Message = "Making a grid";
                for(int x = 0; x < Main.maxTilesX; x++) {
                    for (int y = 0; y < Main.maxTilesY; y++) {
                        if (x % GetInstance<SkyConfig>().gridSize != 0 || y % GetInstance<SkyConfig>().gridSize != 0) {
                            if(!exclude.Contains(Main.tile[x,y].type) && !hasWater(x,y)) {
                                WorldGen.KillTile(x, y);
                                WorldGen.KillWall(x, y);
                            }

                        }

                    }
                    progress.Set(x / (float)Main.maxTilesX);
                }
            }));
        }
        private static bool hasWater(int x, int y) {
            if (Main.tile[x, y].liquid > 0) return true;
            if ( x != 0 && Main.tile[x - 1, y].liquid > 0) return true;
            if ( x < Main.maxTilesX - 1 && Main.tile[x + 1, y].liquid > 0) return true;
            if ( y != 0 && Main.tile[x, y - 1].liquid > 0) return true;
            //explicitly excluding blocks where water is BELOW
            return false;
        }
    }
}
