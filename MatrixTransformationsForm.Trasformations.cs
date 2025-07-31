namespace WinForms_2DTransformations;

public partial class MatrixTransformationsForm
{
     private double[,] _defaultTransformMatrix =
     {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1} 
     };

     private double[,] _currentTransformMatrix =
     {
         {1, 0, 0},
         {0, 1, 0},
         {0, 0, 1} 
     };
     
     private readonly double[,] _defaultVertexes = 
        {
            {-50, -30, 1},
            {-50, 30, 1},
            {0, 30, 1},
            {0, 60, 1},
            {50, 0, 1},
            {0, -60, 1},
            {0, -30, 1}
        };
        
        private Point[] VertexesTransform()
        {
            Point[] output = new Point[_defaultVertexes.GetLength(0)];

            double[,] newVertexes = MatrixOperations.MultiplyMatrices(_defaultVertexes, _defaultTransformMatrix);
            
            for (int j = 0; j < _defaultVertexes.GetLength(0); j++)
            {
                newVertexes[j, 0] /= newVertexes[j, 2];
                newVertexes[j, 1] /= newVertexes[j, 2];
                newVertexes[j, 2] = 1;
            }

            for (int i = 0; i < _defaultVertexes.GetLength(0); i++)
            {
                output[i] = new Point((int)newVertexes[i, 0], (int)newVertexes[i, 1]);
            }

            return output;
        }
        
        private void SetTransformElements()
        {
            
            if (RotationPoint is not null)
            {
                Scale();
                
                RotateAroundPoint(RotationPoint.Value.X, RotationPoint.Value.Y);

                _defaultTransformMatrix = MatrixOperations.CopyMatrix(_currentTransformMatrix);
                MatrixOperations.ResetToIdentityMatrix(_currentTransformMatrix);
                
                Translate(Dx, Dy);
            }

            else
            {
                Scale();
                
                Rotate();

                _defaultTransformMatrix = MatrixOperations.CopyMatrix(_currentTransformMatrix);
                MatrixOperations.ResetToIdentityMatrix(_currentTransformMatrix);

                _defaultTransformMatrix[2, 0] = Dx;
                _defaultTransformMatrix[2, 1] = Dy;
                
                //Translate(Dx, Dy);
            }
            
            if (_checkBoxReflectOx.Checked)
                ReflectOx();
            
            if (_checkBoxReflectOy.Checked)
                ReflectOy();
            
            Invalidate();
        }

        private void Rotate()
        {
            double radians = Angle * Math.PI / 180;
            double[,] rotateMatrix =
            {
                {Math.Cos(radians), -Math.Sin(radians), 0},
                {Math.Sin(radians), Math.Cos(radians), 0},
                {0, 0, 1}
            };
            
            _currentTransformMatrix = MatrixOperations.MultiplyMatrices(_currentTransformMatrix, rotateMatrix);
        }
        
        private void RotateAroundPoint(double cx, double cy)
        {
            double radians = Angle * Math.PI / 180;
            
            double[,] translateToOriginMatrix =
            {
                {1, 0, 0},
                {0, 1, 0},
                {-cx, -cy, 1}
            };
            
            double[,] rotateMatrix =
            {
                {Math.Cos(radians), -Math.Sin(radians), 0},
                {Math.Sin(radians), Math.Cos(radians), 0},
                {0, 0, 1}
            };
            
            double[,] translateBackMatrix =
            {
                {1, 0, 0},
                {0, 1, 0},
                {cx, cy, 1}
            };
            
            _currentTransformMatrix = MatrixOperations.MultiplyMatrices(_currentTransformMatrix, translateToOriginMatrix);
            _currentTransformMatrix = MatrixOperations.MultiplyMatrices(_currentTransformMatrix, rotateMatrix);
            _currentTransformMatrix = MatrixOperations.MultiplyMatrices(_currentTransformMatrix, translateBackMatrix);
        }
        
        private void Translate(double dx, double dy)
        {
            double[,] translateMatrix =
            {
                {1, 0, 0},
                {0, 1, 0},
                {dx, dy, 1}
            };
            _currentTransformMatrix = MatrixOperations.MultiplyMatrices(_currentTransformMatrix, translateMatrix);
        }

        private void Scale()
        {
            _currentTransformMatrix[0, 0] *= ScaleX;
            _currentTransformMatrix[1, 1] *= ScaleY;
        }

        private void ReflectOx()
        {
            double[,] reflectMatrix =
            {
                {1, 0, 0},
                {0, -1, 0},
                {0, 0, 1}
            };
            _defaultTransformMatrix = MatrixOperations.MultiplyMatrices(_defaultTransformMatrix, reflectMatrix);
        }
        
        private void ReflectOy()
        {
            double[,] reflectMatrix =
            {
                {-1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };
            _defaultTransformMatrix = MatrixOperations.MultiplyMatrices(_defaultTransformMatrix, reflectMatrix);
        }
}