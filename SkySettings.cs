using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SkyGrid {
    [Label("Sky Grid")]
    class SkyConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Label("Set Grid Size")]
        [Range(2, 20)]
        [DefaultValue(4)]
        [Slider]
        public int gridSize;
        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
            return true;
        }
    }
}
