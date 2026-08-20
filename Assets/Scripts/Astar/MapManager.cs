using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager:SigonTon<MapManager>
{
    public static MapManager instance;
    //存储网格信息
    private Tilemap tilemap;

    public Block[,] mapArr;

    public int RowCount;//行
    public int ColCount;//列

    public GameObject perfabB;

    //初始化地图信息
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        Init();
    }
    public void Init()
    {
        tilemap = GameObject.Find("Grid/Background").GetComponent<Tilemap>();

        //地图大小 可以修改
        RowCount = 12;
        ColCount = 20;

        mapArr = new Block[RowCount, ColCount];

        List<Vector3Int> tempPosArr = new List<Vector3Int>();//临时记录瓦片地图每个格子的位置

        //遍历瓦片地图
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if(tilemap.HasTile(pos))
            {
                tempPosArr.Add(pos);
            }
        }

        //Object perfabOBJ = Resources.LoadAssetAtPath("Model/block");
        //Object perfabOBJ = Resources.Load("block");
        for(int i = 0; i < tempPosArr.Count; i++)
        {
            int row = i / ColCount;
            int col = i % ColCount;
            Block b = Instantiate(perfabB).AddComponent<Block>();
            b.RowIndex = row;
            b.ColIndex = col;
            b.transform.position = tilemap.CellToWorld(tempPosArr[i]) + new Vector3(0.5f,0.5f,0);
            mapArr[row, col] = b;
        }
    }
}
