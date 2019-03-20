using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshGen : MonoBehaviour
{

    private NavMeshSurface[] surfaces;
    private NavMeshLink[] links;

    private GameObject[] floorTiles;
    private GameObject[] floorLinks;
    // Start is called before the first frame update

    public void GenNavMesh()
    {
        floorTiles = GameObject.FindGameObjectsWithTag("HexTile");
        floorLinks = GameObject.FindGameObjectsWithTag("HexLink");

        Debug.Log("floortiles length = " + floorTiles.Length);


        surfaces = new NavMeshSurface[floorTiles.Length];
        links = new NavMeshLink[floorLinks.Length];

        for (int i = 0; i < floorTiles.Length; i++)
        {
            surfaces[i] = floorTiles[i].GetComponent<NavMeshSurface>();
        }

        for (int i = 0; i < floorLinks.Length; i++)
        {
            links[i] = floorLinks[i].GetComponent<NavMeshLink>();
        }


        Debug.Log("surfaces length = " + surfaces.Length);

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
            
        }

        for (int i = 0; i < links.Length; i++)
        {
            links[i].UpdateLink();

        }

    }

    public void UpdateLinks()
    {
        for (int i = 0; i < links.Length; i++)
        {
            links[i].UpdateLink();

        }
    }
}
