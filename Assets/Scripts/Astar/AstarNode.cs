using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarNode 
{
    //格子对象坐标
    public int x;
    public int y;
    //寻路消耗
    public int f;
    //里起点的距离
    public int g;
    //里终点的距离
    public int h;

    //父对象
    public AstarNode Father;

    public Can_Walk type;

    public AstarNode(int row, int col)
    {
        x = row;
        y = col;
        Father = null;
    }

    public AstarNode(int row,int col,AstarNode father) 
    {
        x = row;
        y = col;
        Father = father;
    }

    public AstarNode(int row, int col, AstarNode father, Can_Walk type)
    {
        x = row;
        y = col;
        Father = father;
        this.type = type;
    }
    public AstarNode(int row, int col, Can_Walk type)
    {
        x = row;
        y = col;
        Father = null;
        this.type = type;
    }
    public int GetG()
    {
        int _g = 0;
        AstarNode father = this.Father;
        while(father != null)
        {
            _g++;
            father = father.Father;
        }
        return _g;
    }

    public int GetH(AstarNode end)
    {
        return (int)(Mathf.Abs(x - end.x) + MathF.Abs(y - end.y));
    }
}
//public class AstarPoint 
//{
//    //格子对象坐标
//    public int RowIndex;
//    public int ColIndex;
//    //寻路消耗
//    public int f;
//    //里起点的距离
//    public int g;
//    //里终点的距离
//    public int h;

//    //父对象
//    public AstarNode Father;

//    //public Can_Walk type;

//    public AstarPoint(int row, int col)
//    {
//        RowIndex = row;
//        ColIndex = col;
//        Father = null;
//    }

//    public AstarPoint(int row, int col, AstarNode father)
//    {
//        RowIndex = row;
//        ColIndex = col;
//        Father = father;
//    }

//    public int GetG()
//    {
//        int _g = 0;
//        AstarPoint father = this.Father;
//        while (father != null)
//        {
//            _g++;
//            father = father.Father;
//        }
//        return _g;
//    }

//    public int GetH(AstarNode end)
//    {
//        return (int)(Mathf.Abs(RowIndex - end.RowIndex) + MathF.Abs(ColIndex - end.ColIndex));
//    }
//}

//public class Astar
//{
//    public int rowCount;
//    public int colCount;
//    public List<AstarNode> open;
//    public Dictionary<string, AstarNode> close;
//    public AstarNode start;
//    public AstarNode end;
//    public Astar(int rowCount, int colCount)
//    {
//        this.rowCount = rowCount;
//        this.colCount = colCount;
//        open = new List<AstarNode>();
//        close = new Dictionary<string, AstarNode>();
//    }

//    //找到open 表格的路径
//    public AstarNode isInOpen(int rowIndx , int colIndex)
//    {
//        for(int i = 0; i < open.Count; i++)
//        {
//            if (open[i].RowIndex == rowIndx && open[i].ColIndex == colIndex)
//            {
//                return open[i];
//            }
//        }
//        return null;
//    }

//    public bool isInClose(int rowIndx , int colIndex)
//    {
//        if (close.ContainsKey($"{rowIndx}_{colIndex}"))
//        {
//            return true;
//        }
//        return false;
//    }
//    /*
//    1.将起点添加到open表
//    2.查找open中最小的f值
//    3.将open中最小f值的点移除，添加到colse中
//    4.将当前的路径点周围的点添加到open中（上下左右）
//    5.判断是否在open中，如不过在从步骤2继续执行逻辑
//    */
//    public bool FindPath(AstarNode start,AstarNode end,Action<List<AstarNode>> findCallBack)
//    {
//        this.start = start;
//        this.end = end;
//        open = new List<AstarNode>();
//        close = new Dictionary<string, AstarNode>();
//        open.Add(start);
//        while (true)
//        {
//            //获取最小f的点
//            AstarNode current = GetMinFNodeInOpen();
//            if(current == null) 
//            {
//                //没路了
//                return false;
//            }
//            else
//            {
//                //从open中移除，添加到close中
//                open.Remove(current);
//                close.Add($"{current.RowIndex}_{current.ColIndex}", current);
                
//            }
//        }
//    }

//    public void AddAroundInOpen(AstarNode current)
//    {
//        //上
//        if(current.RowIndex -1 >= 0)
//        {

//        }
//        //下
//        if (current.RowIndex +1 < rowCount)
//        {

//        }
//        //左
//        if(current.ColIndex -1 >= 0)
//        {

//        }
//        //右
//        if(current.ColIndex +1 < colCount)
//        {

//        }
//    }

//    public void AddOpen(AstarNode current,int row,int col)
//    {
//        //不在open和close对应可行走，加入open
//        //if(isInClose(row,col) == false && isInOpen(row,col)==null &&)
//    }
//    public AstarNode GetMinFNodeInOpen()
//    {
//        if(open.Count == 0)
//        {
//            return null;
//        }
//        return open[0];
//    }
//}
public enum Can_Walk
{
    walk,
    stop,
}