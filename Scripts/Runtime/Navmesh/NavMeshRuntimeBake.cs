// Built by Songoku from the Messy Community

#if MAPMAGIC2 && NAVMESHCOMPONENTS
using UnityEngine;
using MapMagic.Terrains;
using MapMagic.Products;
using Unity.AI.Navigation;
using UnityEngine.UI;

namespace DoubTech.MapMagic2Extensions.Navmesh
{
    public class NavMeshRuntimeBake : MonoBehaviour
    {
        public Terrain Terrain;
        public TerrainTile TerrainTile;
        public NavMeshSurface[] surfaces;
        public InputField Valueinput;
        public MapMagic.Core.MapMagicObject MMObject;
        private int Value;

        public void GenerateTerrain()
        {
            int.TryParse(Valueinput.text, out Value);
            MMObject.graph.defaults["NoiseSeed"] = Value;
            MMObject.graph.defaults["PositionSeed"] = Value;
            MMObject.ClearAll();
            MMObject.StartGenerate();
            TerrainTile.OnTileApplied += BuildNavMesh;
        }

        private void BuildNavMesh(TerrainTile tile, TileData data, StopToken stop)
        {
            for (int i = 0; i < surfaces.Length; i++)
                surfaces[i].BuildNavMesh();
        }
    }
}
#endif