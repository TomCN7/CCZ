using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InvertedComparer : IComparer<int>
{
	public int Compare(int x, int y)
	{
		if (y.CompareTo(x) == 0)
	            return 1;
		return y.CompareTo (x);
	}
}

public class Base {
	public class Coord
	{
		public int x, y;
	};

	public bool FindPath(int nCost, int nCurX, int nCurY, int nRow, int nCol, 
	              int [,]nMapCost, bool [,]bReachable, int [,]nFromX, int [,]nFromY)
	{
		bool bResult = false;
		int [,]nCostIntermediate = new int[nRow,nCol];
		SortedList<int, Coord> myList = new SortedList<int, Coord>(new InvertedComparer());

		int []nDirX = new int[4]{-1, 0, 0, 1};
		int []nDirY = new int[4]{0, -1, 1, 0};

		for (int i = 0; i < nRow; ++i)
			for (int j = 0; j < nCol; ++j)
		{
			bReachable[i,j] = false;
			nCostIntermediate[i,j] = -1;
		}

		if (nCurX < 0 || nCurX >= nRow)
			goto Exit0;
		if (nCurY < 0 || nCurY >= nCol)
			goto Exit0;
		if (nCost < 0)
			goto Exit0;

		nFromX [nCurX, nCurY] = -1; nFromY [nCurX, nCurY] = -1;
		nCostIntermediate[nCurX, nCurY] = nCost;

		Coord item = new Coord(); item.x = nCurX; item.y = nCurY;
		myList.Add(nCost, item);

		while (myList.Count > 0)
		{
			int nCurCost = myList.Keys[0];
			Coord temp = myList.Values[0];
			myList.RemoveAt(0);

			if (bReachable[temp.x, temp.y]) continue;

			bReachable[temp.x, temp.y] = true;
			for (int i = 0; i < 4; ++i)
			{
				int nTempCost = 0;
				int x = temp.x + nDirX[i], y = temp.y + nDirY[i];
				if (x < 0 || x >= nRow) continue;
				if (y < 0 || y >= nCol) continue;

				nTempCost = nCurCost - nMapCost[x, y];
				if (nTempCost < 0) continue;
				if (nCostIntermediate[x, y] >= 0 && nCostIntermediate[x, y] >= nTempCost) continue;

				nFromX[x, y] = temp.x; nFromY[x, y] = temp.y;
				nCostIntermediate[x, y] = nTempCost;

				Coord newItem = new Coord(); newItem.x = x; newItem.y = y;
				myList.Add(nTempCost, newItem);
			}
		}

		bResult = true;
	Exit0:
		return bResult;
	}
}
