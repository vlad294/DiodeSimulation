﻿using System.Collections.Generic;

namespace PICSolver.Abstract
{
    public interface IGrid2D
    {
        void InitializeGrid(int n, int m, double left, double right, double bottom, double top);
        double CellSquare { get; }
        double Hx { get; }
        double Hy { get; }
        double Hxy { get; }
        double[] X { get; }
        double[] Y { get; }
        int N { get; }
        int M { get; }
        int UpperCell(int cellId);
        int FindCell(double x, double y);
        bool IsOutOfGrid(double x, double y);
        double GetCellX(int cellId);
        double GetCellY(int cellId);
        KeyValuePair<double, double> GetCell(int cellId);
    }
}