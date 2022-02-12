// Built by Songoku from the Messy Community

#if MAPMAGIC2 && NAVMESHCOMPONENTS
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace DoubTech.MapMagic2Extensions.Navmesh
{
    public class NavmeshGenerator : MonoBehaviour
    {
        public Terrain Terrain;
        public TerrainTile TerrainTile;
        public NavMeshSurface[] surfaces;
        public InputField input;
        public InputField output;
        public MapMagic.Core.MapMagicObject MMObject;
        private int Value;
        private int Value2;

        public void GenerateTerrain()
        {
            int.TryParse(input.text, out Value);
            MMObject.graph.defaults["NoiseSeed"] = Value;
            Wert2 = (int) MMObject.graph.defaults["NoiseSeed"];
            output.text = Value2.ToString();
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