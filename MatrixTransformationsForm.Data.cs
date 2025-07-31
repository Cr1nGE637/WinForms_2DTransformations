namespace WinForms_2DTransformations;

public partial class MatrixTransformationsForm
{
    #region Properties Declaration

    private double _angle = 0;
    private double Angle
    {
        get => _angle;
        set
        {
            _angle = value % 360;
            SetTransformElements();
        }
    }
    
    private double _scaleX = 1;
    private double ScaleX
    {
        get => _scaleX;
        set
        {
            _scaleX = value;
            SetTransformElements();
            
        }
    }
    
    private double _scaleY = 1;
    private double ScaleY
    {
        get => _scaleY;
        set
        {
            _scaleY = value;
            SetTransformElements();
        }
    }
    
    private double _dx = 0;
    private double Dx
    {
        get => _dx;
        set
        {
            _dx = value;
            SetTransformElements();
        }
    }
    
    private double _dy = 0;
    private double Dy
    {
        get => _dy;
        set
        {
            _dy = value;
            SetTransformElements();
        }
    }

    private Point? RotationPoint { get; set; } = null;

    #endregion
}