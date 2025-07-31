namespace WinForms_2DTransformations;

public partial class MatrixTransformationsForm
{
    #region Hot Keys Bools

    private bool _sPressed = false;
    private bool _sxPressed = false;
    private bool _syPressed = false;
    
    private bool _gPressed = false;
    private bool _gxPressed = false;
    private bool _gyPressed = false;

    private bool _rPressed = false;

    #endregion
    
    private Point _previousMouseLocation;
    private const double MouseScaleSensitivity = 0.03;
    private const double MouseRotateSensitivity = 0.2;


    private void OnMouseMove(object? sender, MouseEventArgs e)
    {
        if (_sPressed)
        {
            Point currentMouseLocation = e.Location;
            
            double currentVector = Math.Sqrt(Math.Pow(currentMouseLocation.X, 2) + Math.Pow(currentMouseLocation.Y, 2));
            double previousVector = Math.Sqrt(Math.Pow(_previousMouseLocation.X, 2) + Math.Pow(_previousMouseLocation.Y, 2));
            
            if (_sxPressed)
            {
                double deltaX = (currentMouseLocation.X - _previousMouseLocation.X) * MouseScaleSensitivity;
                _tbScaleX.Text = (double.Parse(_tbScaleX.Text) + deltaX).ToString();
                _previousMouseLocation = e.Location;
                return;
            }
            
            if (_syPressed)
            {
                double deltaY = (currentMouseLocation.Y - _previousMouseLocation.Y) * MouseScaleSensitivity;
                _tbScaleY.Text = (double.Parse(_tbScaleY.Text) + deltaY).ToString();
                _previousMouseLocation = e.Location;
                return;
            }
            
            Point deltaVector = new Point(currentMouseLocation.X - _previousMouseLocation.X, 
                currentMouseLocation.Y - _previousMouseLocation.Y);
            
            
            double delta = Math.Sqrt(Math.Pow(deltaVector.X, 2) + Math.Pow(deltaVector.Y, 2)) * MouseScaleSensitivity;

            if (currentVector > previousVector)
            {
                _tbScaleX.Text = (double.Parse(_tbScaleX.Text) + delta).ToString();
                _tbScaleY.Text = (double.Parse(_tbScaleY.Text) + delta).ToString();
            }
            else
            {
                _tbScaleX.Text = (double.Parse(_tbScaleX.Text) - delta).ToString();
                _tbScaleY.Text = (double.Parse(_tbScaleY.Text) - delta).ToString();
            }
        }
        
        if (_gPressed)
        {
            Point currentMouseLocation = e.Location;
            Point deltaVector;
            
            if (_gxPressed)
            {
                deltaVector = new Point(currentMouseLocation.X - _previousMouseLocation.X, 0);
            }
            
            else if (_gyPressed)
            {
                deltaVector = new Point(0, -(currentMouseLocation.Y - _previousMouseLocation.Y));
            }

            else
            {
                deltaVector = new Point(currentMouseLocation.X - _previousMouseLocation.X,
                    -(currentMouseLocation.Y - _previousMouseLocation.Y));
            }
            
            _tbMoveX.Text = (double.Parse(_tbMoveX.Text) + deltaVector.X).ToString();
            _tbMoveY.Text = (double.Parse(_tbMoveY.Text) + deltaVector.Y).ToString();
        }

        if (_rPressed)
        {
            Point currentMouseLocation = e.Location;
            Point deltaVector = new Point(currentMouseLocation.X - _previousMouseLocation.X, 0);
            
            _tbRotate.Text = (double.Parse(_tbRotate.Text) + deltaVector.X * MouseRotateSensitivity).ToString();
        }
        
        _previousMouseLocation = e.Location;
    }
    
    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.S:
                _sPressed = true;
                _gPressed = _gxPressed = _gyPressed = false;
                break;
            case Keys.X:
                if (_sPressed)
                    _sxPressed = true;
                else if (_gPressed)
                    _gxPressed = true;
                break;
            case Keys.Y:
                if (_sPressed)
                    _syPressed = true;
                else if (_gPressed)
                    _gyPressed = true;
                break;
            case Keys.G:
                _gPressed = true;
                _sPressed = _sxPressed = _syPressed = false;
                break;
            case Keys.C:
                _tbMoveX.Text = _tbMoveY.Text = 0.ToString();
                Invalidate();
                break;
            case Keys.R:
                _rPressed = true;
                _sPressed = _gPressed = false;
                break;
            case Keys.Q:
                BtnResetOnClick(new object(),  EventArgs.Empty);
                break;
        }
    }
}