using Terraria.ModLoader;

namespace RogueLineageRaces
{
    public class RogueLineageRaces : Mod
    {
        public static RogueLineageRaces Instance { get; private set; }
        public override void Load()
        {
            MrPlagueRaces.Core.Loadables.LoadableManager.Autoload(this);
        }
        public override void Unload()
        {
            MrPlagueRaces.Common.Races.RaceLoader.Races.Clear();
            MrPlagueRaces.Common.Races.RaceLoader.RacesByLegacyIds.Clear();
            MrPlagueRaces.Common.Races.RaceLoader.RacesByFullNames.Clear();
        }
    }
}