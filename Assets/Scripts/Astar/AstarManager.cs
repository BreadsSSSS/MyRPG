using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AstarManager : MonoBehaviour
{
    public static AstarManager instance;
    //wide & hight
    private int mapW = 10;
    private int mapH = 10;
    //地图相关的所有格子对象容器
    //private AstarNode[,] nodes;
    private Dictionary<(int, int), AstarNode> nodes = new Dictionary<(int, int), AstarNode>();

    public Tilemap tilemap;

    //开启列表
    public List<AstarNode> openList = new List<AstarNode>();
    //关闭列表
    public List<AstarNode> closeList = new List<AstarNode>();

    public AstarNode nowNode;
    public Tile nowTile;
    // bool has;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        tilemap = GameObject.FindObjectOfType<Tilemap>();
        //nowTile = (Tile)tilemap.GetTile(new Vector3Int(0, 0, 0));
        //has = tilemap.HasTile(new Vector3Int(0, 0, 0));
        InitMapInfo();
    }
    public void InitMapInfo()
    {
        //mapW = w;
        //mapH = h;
        //tiles = new Tile[mapW * 2, mapH * 2];
        //nodes = new AstarNode[mapW * 2, mapH * 2];
        //nowTile = (Tile)tilemap.GetTile(new Vector3Int(0, 0, 0));
        for (int i = 0; i < mapH *2; i++)
        {
            for (int j = 0; j < mapW*2; j++)
            {
                int row;
                int col;
                if( i >= mapH )
                {
                    row = i - mapH;
                }
                else
                {
                    row = i;
                }
                if( j <= mapW)
                {
                    col = j - mapW;
                }
                else
                {
                    col = j;
                }
                Vector3Int pos = tilemap.WorldToCell(new Vector3Int(i, j, 0));
                nowTile = (Tile)tilemap.GetTile(pos);
                //has = tilemap.HasTile(new Vector3Int(i, j, 0));
                if (nowTile != null)
                {
                    AstarNode node = new AstarNode(row, col, Can_Walk.walk);
                    nodes.Add((i, j), node);
                    //nowNode = node;
                }
                //AstarNode node = new AstarNode(i,j, UnityEngine.Random.Range(0,100) < 20 ? Can_Walk.stop : Can_Walk.walk);
                else
                {
                    AstarNode node = new AstarNode(i, j, Can_Walk.stop);
                    nodes.Add((i, j), node);
                    //nowNode = node;
                }
            }
        }
    }

    //要计算f消耗所以传入父对象
    public List<AstarNode> FindPath(Vector2 starPos, Vector2 endPos)
    {
        //(是否合法位置)
        if (starPos.x < -mapW || starPos.y < -mapH ||
            starPos.x > mapW || starPos.y > mapH ||
            endPos.x < -mapW || endPos.y < -mapH ||
            endPos.x > mapW || endPos.y > mapH)
        {
            return null;
        }
        //AstarNode start = nodes[(int)starPos.x, (int)starPos.y];
        AstarNode start = new AstarNode((int)starPos.x, (int)starPos.y);
        //AstarNode end = nodes[(int)endPos.x, (int)endPos.y];
        AstarNode end = new AstarNode((int)endPos.x, (int)endPos.y);

        if (nodes.ContainsKey((start.x, start.y)))
        {
            start = nodes[(start.x, start.y)];
        }
        if(nodes.ContainsKey((end.x, end.y)))
        {
            end = nodes[(end.x, end.y)];
        }
        if (start.type == Can_Walk.stop || end.type == Can_Walk.stop)
        {
            Debug.Log("无法开始或者阻挡");
            return null;
        }
        //清空开始和关闭列表
        closeList.Clear();
        openList.Clear();

        //把开始点放入关闭列表
        start.Father = null;
        start.f = 0;
        start.g = 0;
        start.h = 0;
        closeList.Add(start);

        while (true)
        {
            //从起点开始找周围的点，放入开启列表中
            //right upx-1，y+1;
            //FindeNearNodeToOpenList(start.x - 1, start.y + 1, 1.4f, start, end);
            //up x y+1
            FindeNearNodeToOpenList(start.x, start.y + 1, 1, start, end);
            //right up x+1 , y+1
            //FindeNearNodeToOpenList(start.x + 1, start.y + 1, 1.4f, start, end);
            //left x-1,y
            FindeNearNodeToOpenList(start.x - 1, start.y, 1, start, end);
            //right x+1,y
            FindeNearNodeToOpenList(start.x + 1, start.y, 1, start, end);
            //left down x-1,y-1
            //FindeNearNodeToOpenList(start.x - 1, start.y - 1, 1.4f, start, end);
            //down x,y-1
            FindeNearNodeToOpenList(start.x, start.y - 1, 1, start, end);
            //right down x+1,y-1
            //FindeNearNodeToOpenList(start.x + 1, start.y - 1, 1.4f, start, end);

            if (openList.Count == 0)
            {
                Debug.Log("no path");
                return null;
            }
            //从开启列表中选择消耗最少的点
            openList.Sort(openListSort);

            //放入关闭列表，然后从开启列表移除
            closeList.Add(openList[0]);
            //找到新的起点
            start = openList[0];
            openList.RemoveAt(0);

            //如果是终点
            if (start == end)
            {
                List<AstarNode> path = new List<AstarNode>();
                path.Add(end);
                while (end.Father != null)
                {
                    path.Add(end.Father);
                    end = end.Father;
                }
                path.Reverse();
                return path;
            }
        }
    }

    public int openListSort(AstarNode a, AstarNode b)
    {
        if (a.f > b.f)
            return 1;
        else if (a.f == b.f)
            return 1;
        else
            return -1;
    }

    public void FindeNearNodeToOpenList(int x, int y, int g, AstarNode FatherNode, AstarNode EndNode)
    {
        //判断边界
        if (x < -mapW || x > mapW ||
            y < -mapH || y > mapH)
            return;
        //在范围内后，取点

        AstarNode node = new AstarNode(x, y);

        if (nodes.ContainsKey((x, y)))
        {
            node = nodes[(x, y)];
        }

        //判断这些点是否合法
        if (node == null ||
            node.type == Can_Walk.stop ||
            closeList.Contains(node) ||
            openList.Contains(node))
            return;

        //计算f值,f = g+h
        node.Father = FatherNode;
        //我离起点的距离，就是父节点的距离+我离父节点的距离
        node.g = g;
        node.h = Mathf.Abs(EndNode.x - node.x) + Mathf.Abs(EndNode.y - node.y);
        node.f = node.g + node.h;

        //全部通过后放入开启列表
        openList.Add(node);
    }
}