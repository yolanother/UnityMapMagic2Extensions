// Built by Songoku from the Messy Community

using UnityEngine;

namespace DoubTech.MapMagic2Extensions.Navmesh
{
    public class NavmeshGenerator : MonoBehaviour
    {
        public Terrain Terrain;
        public TerrainTile TerrainTile;
        public NavMeshSurface[] surfaces;
        public InputField Eingabe;
        public InputField Ausgabe;
        public MapMagic.Core.MapMagicObject MMObject;
        private int Value;
        private int Value2;

        public void GenerateTerrain()
        {
            int.TryParse(Eingabe.text, out Value);
            MMObject.graph.defaults["NoiseSeed"] = Value;
            Wert2 = (int) MMObject.graph.defaults["NoiseSeed"];
            Ausgabe.text = Value2.ToString();
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