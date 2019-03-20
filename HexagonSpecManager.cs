using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HexagonSpecManager : MonoBehaviour
{

    NavmeshGen navMeshGen;

    public int width = 6;
    public int height = 6;

    public HexagonCellGen hexPrefab;


    HexagonCellGen[] cells;

    public Text cellLabelPrefab;

    Canvas gridCanvas;

    HexagonMesh hexagonMesh;

    public GameObject HexagonPlatform;

    public int heightmod;

    

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexagonMesh = GetComponentInChildren<HexagonMesh>();

        navMeshGen = new NavmeshGen();

        cells = new HexagonCellGen[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
                

            }
        }

       navMeshGen.GenNavMesh();

    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexagonGridGen.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexagonGridGen.outerRadius * 1.5f);

        HexagonCellGen cell = cells[i] = Instantiate<HexagonCellGen>(hexPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = Hexcoords.FromOffsetCoordinates(x, z);

        /*
        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();
         */
        
        GameObject platform =  Instantiate(HexagonPlatform);
        platform.transform.SetParent(transform, false);
        platform.transform.localPosition = position;
        platform.transform.rotation = Quaternion.Euler(0, 30, 0);
        platform.transform.localPosition = new Vector3(platform.transform.position.x, RndRange(heightmod) , platform.transform.position.z);
        HeightCheck(platform);
        
    }

    void Start()
    {
        hexagonMesh.Triangulate(cells);
    }

    public int RndRange(int R)
    {
        R = Random.Range(R * -1, R);
        return R;
    }

    void HeightCheck(GameObject pillar)
    {
        if(pillar.transform.position.y <= (-1 * ((heightmod / 2) - 1 )))
        {
            pillar.SetActive(false);
        }
    }

}
