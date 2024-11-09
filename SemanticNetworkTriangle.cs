namespace Semantic_Network_Triangle
{
    public class SemanticNetworkTriangle
    {
        struct Pair {
            int Key;
            int Value;

            public Pair(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        public static readonly int nCol = 26;
        public static readonly int nRow = 13;

        bool isCalculate = false;
        bool err = false;
        public bool Error => err;

        Dictionary<int, int> history = new Dictionary<int, int>(nRow);
        public Dictionary<int, int> History => new Dictionary<int, int>(history);

        List<int> root = new List<int>();
        public List<int> Root => new List<int>(root);

        HashSet<Pair> border = new HashSet<Pair>();

        int[,] data = new int[nRow, nCol];
        public int[,] Data => (int[,])data.Clone();

        static bool IsInvalidValue(double value, double self)
        {
            if (value <= 0 || double.IsNaN(value) || double.IsInfinity(value) || value == self)
                return true;
            else
                return false;
        }

        double _A = 0;
        public double A
        {
            get => _A;
            set
            {
                double tmp = value % 360;
                if (IsInvalidValue(tmp, _A))
                    return;
                _A = tmp;
                UpdateRow(0, tmp);
            }
        }

        double _B = 0;
        public double B
        {
            get => _B;
            set
            {
                double tmp = value % 360;
                if (IsInvalidValue(tmp, _B))
                    return;
                _B = tmp;
                UpdateRow(1, tmp);
            }
        }

        double _C = 0;
        public double C
        {
            get => _C;
            set
            {
                double tmp = value % 360;
                if (IsInvalidValue(tmp, _C))
                    return;
                _C = tmp;
                UpdateRow(2, tmp);
            }
        }

        double _a = 0;
        public double a
        {
            get => _a;
            set
            {
                if (IsInvalidValue(value, _a))
                    return;
                _a = value;
                UpdateRow(3, value);
            }
        }

        double _b = 0;
        public double b
        {
            get => _b;
            set
            {
                if (IsInvalidValue(value, _b))
                    return;
                _b = value;
                UpdateRow(4, value);
            }
        }

        double _c = 0;
        public double c
        {
            get => _c;
            set
            {
                if (IsInvalidValue(value, _c))
                    return;
                _c = value;
                UpdateRow(5, value);
            }
        }

        double _S = 0;
        public double S
        {
            get => _S;
            set
            {
                if (IsInvalidValue(value, _S))
                    return;
                _S = value;
                UpdateRow(6, value);
            }
        }

        double _hA = 0;
        public double hA
        {
            get => _hA;
            set
            {
                if (IsInvalidValue(value, _hA))
                    return;
                _hA = value;
                UpdateRow(7, value);
            }
        }

        double _hB = 0;
        public double hB
        {
            get => _hB;
            set
            {
                if (IsInvalidValue(value, _hB))
                    return;
                _hB = value;
                UpdateRow(8, value);
            }
        }

        double _hC = 0;
        public double hC
        {
            get => _hC;
            set
            {
                if (IsInvalidValue(value, _hC))
                    return;
                _hC = value;
                UpdateRow(9, value);
            }
        }

        double _P = 0;
        public double P
        {
            get => _P;
            set
            {
                if (IsInvalidValue(value, _P))
                    return;
                _P = value;
                UpdateRow(10, value);
            }
        }

        double _R = 0;
        public double R
        {
            get => _R;
            set
            {
                if (IsInvalidValue(value, _R))
                    return;
                _R = value;
                UpdateRow(11, value);
            }
        }

        double _r = 0;
        public double r
        {
            get => _r;
            set
            {
                if (IsInvalidValue(value, _r))
                    return;
                _r = value;
                UpdateRow(12, value);
            }
        }

        void UpdateRow(int row, double value)
        {
            if (double.NaN.Equals(value))
                return;
            for (int i = 0; i < nCol; i++)
            {
                double curr = data[row, i];
                if (curr == 1)
                    break;
                else if (curr == -1)
                    data[row, i] = 1;
            }
            if (!isCalculate)
                root.Add(row);
        }

        int TriggerCol(int col)
        {
            int result = 0;
            int row = -1;
            for (int i = 0; i < nRow; i++)
            {
                if (data[i, col] == -1)
                {
                    result++;
                    row = i;
                }
            }
            return result == 1 ? row : -1;
        }

        public SemanticNetworkTriangle()
        {
            data[0, 0] = data[1, 0] = data[3, 0] = data[4, 0] = -1;
            data[1, 1] = data[2, 1] = data[4, 1] = data[4, 1] = -1;
            data[0, 2] = data[2, 2] = data[3, 2] = data[5, 2] = -1;
            data[3, 3] = data[4, 3] = data[5, 3] = data[6, 3] = -1;
            data[3, 4] = data[6, 4] = data[7, 4] = -1;
            data[4, 5] = data[6, 5] = data[8, 5] = -1;
            data[5, 6] = data[6, 6] = data[9, 6] = -1;
            data[0, 7] = data[1, 7] = data[2, 7] = -1;
            data[2, 8] = data[3, 8] = data[4, 8] = data[6, 8] = -1;
            data[1, 9] = data[3, 9] = data[5, 9] = data[6, 9] = -1;
            data[0, 10] = data[4, 10] = data[5, 10] = data[6, 10] = -1;
            data[3, 11] = data[4, 11] = data[5, 11] = data[10, 11] = -1;
            data[0, 12] = data[3, 12] = data[11, 12] = -1;
            data[1, 13] = data[4, 13] = data[11, 13] = -1;
            data[2, 14] = data[5, 14] = data[11, 14] = -1;
            data[3, 15] = data[4, 15] = data[5, 15] = data[6, 15] = data[11, 15] = -1;
            data[6, 16] = data[10, 16] = data[12, 16] = -1;
            data[2, 17] = data[4, 17] = data[7, 17] = -1;
            data[1, 18] = data[5, 18] = data[7, 18] = -1;
            data[2, 19] = data[3, 19] = data[8, 19] = -1;
            data[0, 20] = data[5, 20] = data[8, 20] = -1;
            data[0, 21] = data[4, 21] = data[9, 21] = -1;
            data[1, 22] = data[3, 22] = data[9, 22] = -1;
            data[0, 23] = data[3, 23] = data[4, 23] = data[5, 23] = -1;
            data[1, 24] = data[3, 24] = data[4, 24] = data[5, 24] = -1;
            data[2, 25] = data[3, 25] = data[4, 25] = data[5, 25] = -1;
        }

        static double DegreeToRadian(double x) => x * Math.PI / 180;

        public void Calculate()
        {
            err = false;
            isCalculate = true;
            bool tryAgain = false;
            for (int col = 0; col < nCol; col++)
            {
                if (history.Keys.Contains(col))
                    continue;
                int row = TriggerCol(col);
                if (row == -1)
                    continue;
                if (_a != 0 && _b != 0 && _c != 0)
                    if (!(_a < _b + _c && _b < _a + _c && _c < _a + _b))
                    {
                        err = true;
                        break;
                    }
                tryAgain = true;
                try
                {
                    switch (col)
                    {
                        case 0:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(Math.Sin(DegreeToRadian(_B)) * _a / _b) * (180 / Math.PI);
                                        }
                                        break;
                                    case 1:
                                        {
                                            B = Math.Asin(Math.Sin(DegreeToRadian(_A)) * _b / _a) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = _b * Math.Sin(DegreeToRadian(_A)) / Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = _a * Math.Sin(DegreeToRadian(_B)) / Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 1:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Asin(Math.Sin(DegreeToRadian(_C)) * _b / _c) * (180 / Math.PI);
                                        }
                                        break;
                                    case 2:
                                        {
                                            C = Math.Asin(Math.Sin(DegreeToRadian(_B)) * _c / _b) * (180 / Math.PI);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = _c * Math.Sin(DegreeToRadian(_B)) / Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = _b * Math.Sin(DegreeToRadian(_C)) / Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 2:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(Math.Sin(DegreeToRadian(_C)) * _a / _c) * (180 / Math.PI);
                                        }
                                        break;
                                    case 2:
                                        {
                                            C = Math.Asin(Math.Sin(DegreeToRadian(_A)) * _c / _a) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = _c * Math.Sin(DegreeToRadian(_A)) / Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = _a * Math.Sin(DegreeToRadian(_C)) / Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 3:
                            {
                                switch (row)
                                {
                                    case 3:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 4:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }

                                    case 5:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 6:
                                        {
                                            double p = (_a + _b + _c) / 2;
                                            S = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 4:
                            {
                                switch (row)
                                {
                                    case 3:
                                        {
                                            a = 2 * _S / _hA;
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = _hA / 2 * _a;
                                        }
                                        break;
                                    case 7:
                                        {
                                            hA = 2 * _S / _a;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 5:
                            {
                                switch (row)
                                {
                                    case 4:
                                        {
                                            b = 2 * _S / _hB;
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = _hB / 2 * _b;
                                        }
                                        break;
                                    case 8:
                                        {
                                            hB = 2 * _S / _b;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 6:
                            {
                                switch (row)
                                {
                                    case 5:
                                        {
                                            c = 2 * _S / _hC;
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = _hC / 2 * _c;
                                        }
                                        break;
                                    case 9:
                                        {
                                            hC = 2 * _S / _c;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 7:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = 180 - _B - _C;
                                        }
                                        break;
                                    case 1:
                                        {
                                            B = 180 - _A - _C;
                                        }
                                        break;
                                    case 2:
                                        {
                                            C = 180 - _B - _A;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 8:
                            {
                                switch (row)
                                {
                                    case 2:
                                        {
                                            C = Math.Asin(2 * _S / (_a * _b)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = 2 * _S / (_b * Math.Sin(DegreeToRadian(_C)));
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = 2 * _S / (_a * Math.Sin(DegreeToRadian(_C))); ;
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = 0.5 * _a * _b * Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 9:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Asin(2 * _S / (_c * _a)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = 2 * _S / (_c * Math.Sin(DegreeToRadian(_B)));
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = 2 * _S / (_a * Math.Sin(DegreeToRadian(_B)));
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = 0.5 * _a * _c * Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 10:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(2 * _S / (_c * _b)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = 2 * _S / (_c * Math.Sin(DegreeToRadian(_A)));
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = 2 * _S / (_b * Math.Sin(DegreeToRadian(_A)));
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = 0.5 * _b * _c * Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 11:
                            {
                                switch (row)
                                {
                                    case 3:
                                        {
                                            a = _P - _b - _c;
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = _P - _a - _c;
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = _P - _a - _b;
                                        }
                                        break;
                                    case 10:
                                        {
                                            P = _a + _b + _c;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 12:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(_a / (2 * _R)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = 2 * _R * Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                    case 11:
                                        {
                                            R = _a / (2 * Math.Sin(DegreeToRadian(_A)));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 13:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Asin(_b / (2 * _R)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = 2 * _R * Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                    case 11:
                                        {
                                            R = _b / (2 * Math.Sin(DegreeToRadian(_B)));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 14:
                            {
                                switch (row)
                                {
                                    case 2:
                                        {
                                            C = Math.Asin(_c / (2 * _R)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = 2 * _R * Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                    case 11:
                                        {
                                            R = _c / (2 * Math.Sin(DegreeToRadian(_C)));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 15:
                            {
                                switch (row)
                                {
                                    case 3:
                                        {
                                            a = 4 * _S * _R / (_b * _c);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = 4 * _S * _R / (_a * _c);
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = 4 * _S * _R / (_b * _a);
                                        }
                                        break;
                                    case 6:
                                        {
                                            S = _a * _b * _c / (4 * _R);
                                        }
                                        break;
                                    case 11:
                                        {
                                            R = _a * _b * _c / (4 * _S);
                                        }
                                        break;
                                }
                            }
                            break;
                        case 16:
                            {
                                switch (row)
                                {
                                    case 6:
                                        {
                                            S = _P * _r / 2;
                                        }
                                        break;
                                    case 10:
                                        {
                                            P = (2 * _S) / _r;
                                        }
                                        break;
                                    case 12:
                                        {
                                            r = (2 * _S) / _P;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 17:
                            {
                                switch (row)
                                {
                                    case 2:
                                        {
                                            C = Math.Asin(_hA / _b) * (180 / Math.PI);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = _hA / Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                    case 7:
                                        {
                                            hA = _b * Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 18:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Asin(_hA / _c) * (180 / Math.PI);
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = _hA / Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                    case 7:
                                        {
                                            hA = _c * Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 19:
                            {
                                switch (row)
                                {
                                    case 2:
                                        {
                                            C = Math.Asin(_hB / _a) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = _hB / Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                    case 8:
                                        {
                                            hB = _a * Math.Sin(DegreeToRadian(_C));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 20:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(_hB / _c) * (180 / Math.PI);
                                        }
                                        break;
                                    case 5:
                                        {
                                            c = _hB / Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                    case 8:
                                        {
                                            hB = _c * Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 21:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Asin(_hC / _b) * (180 / Math.PI);
                                        }
                                        break;
                                    case 4:
                                        {
                                            b = _hC / Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                    case 9:
                                        {
                                            hC = _b * Math.Sin(DegreeToRadian(_A));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 22:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Asin(_hC / _a) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = _hC / Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                    case 9:
                                        {
                                            hC = _a * Math.Sin(DegreeToRadian(_B));
                                        }
                                        break;
                                }
                            }
                            break;
                        case 23:
                            {
                                switch (row)
                                {
                                    case 0:
                                        {
                                            A = Math.Acos(((_b * _b) + (_c * _c) - (_a * _a)) / (2 * _b * _c)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            a = Math.Sqrt((_b * _b) + (_c * _c) - (2 * _b * _c * Math.Cos(DegreeToRadian(_A))));
                                        }
                                        break;
                                    case 4:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 5:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                }
                            }
                            break;
                        case 24:
                            {
                                switch (row)
                                {
                                    case 1:
                                        {
                                            B = Math.Acos(((_a * _a) + (_c * _c) - (_b * _b)) / (2 * _a * _c)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 4:
                                        {
                                            b = Math.Sqrt((_a * _a) + (_c * _c) - (2 * _a * _c * Math.Cos(DegreeToRadian(_B))));
                                        }
                                        break;
                                    case 5:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                }
                            }
                            break;
                        case 25:
                            {
                                switch (row)
                                {
                                    case 2:
                                        {
                                            C = Math.Acos(((_a * _a) + (_b * _b) - (_c * _c)) / (2 * _a * _b)) * (180 / Math.PI);
                                        }
                                        break;
                                    case 3:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 4:
                                        {
                                            if (!border.Add(new Pair(row, col))) throw new Exception();
                                            continue;
                                        }
                                    case 5:
                                        {
                                            c = Math.Sqrt((_a * _a) + (_b * _b) - (2 * _a * _b * Math.Cos(DegreeToRadian(_C))));
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                    history[col] = row;
                } catch (Exception ex)
                {
                    err = true;
                    System.Diagnostics.Debug.WriteLine(ex);
                    return;
                }                
            }
            Debug(this);
            if (tryAgain)
                Calculate();
            if (!(_a < _b + _c && _b < _a + _c && _c < _a + _b) && err)
                err = true;
        }

        public static void Debug(SemanticNetworkTriangle semanticNetwork)
        {
            bool first = true;
            for (int row = 0; row < nRow; row++)
            {
                if (first)
                {
                    for (int col = 0; col < nCol; col++)
                    {
                        System.Diagnostics.Debug.Write($"{string.Format("{0,3}", col)}\t");
                    }
                    System.Diagnostics.Debug.Write("\n");
                    first = false;
                }
                for (int col = 0; col < nCol; col++)
                {
                    System.Diagnostics.Debug.Write($"{string.Format("{0,3}", semanticNetwork.data[row, col])}\t");
                }
                System.Diagnostics.Debug.Write("\n");
            }
            System.Diagnostics.Debug.Write("\n");
        }
    }
}