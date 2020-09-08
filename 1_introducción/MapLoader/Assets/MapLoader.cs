using UnityEngine;
using System.IO;

public class MapLoader : MonoBehaviour
{
  StreamReader reader;

  void Start()
  {
    // crea el lector del archivo
    reader = new StreamReader("Data/mapa.txt");

    // pone toda la información del archivo en un string
    string mapData = reader.ReadToEnd();

    // se hace un split por línea
    string[] lineData = mapData.Trim().Split('\n');

    // se interpreta cada línea
    for (int i = 0; i < lineData.Length; i++)
    {
      string tileData = lineData[i];
      // se hace un split por comas
      string[] tileCoordinates = tileData.Split(',');

      // y se lee convierte cadda valor a entero
      int x = int.Parse(tileCoordinates[0]);
      int y = -int.Parse(tileCoordinates[1]);

      // se crea el tile en esas coordenadas
      GameObject tile = Instantiate(Resources.Load<GameObject>("Box"));
      tile.transform.position = new Vector2(x - 3.5f, y + 3.5f);
      tile.transform.parent = GameObject.Find("Map").transform;
    }
  }
}
