namespace WinForms_2DTransformations;

public partial class MatrixTransformationsForm : Form
{
    private readonly Point _coordinateOrigin;

    private readonly Pen _coordinateLinesPen = new Pen(Color.CornflowerBlue, 3);
    private readonly Pen _shapeLinesPen = new Pen(Color.Black, 4);
    private Pen _rotationPointPen = new Pen(Color.Red, 2);
    
    public MatrixTransformationsForm()
    {
        InitializeComponent();
        _coordinateOrigin = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        e.Graphics.DrawLine(_coordinateLinesPen, new Point(0, ClientSize.Height / 2), 
            new Point(ClientSize.Width, ClientSize.Height / 2));
        e.Graphics.DrawLine(_coordinateLinesPen, new Point(ClientSize.Width / 2, 0), 
            new Point(ClientSize.Width / 2, ClientSize.Height));
        
        e.Graphics.TranslateTransform(_coordinateOrigin.X, _coordinateOrigin.Y);
        if (RotationPoint is not null)
        {
            e.Graphics.DrawEllipse(_rotationPointPen, RotationPoint.Value.X - 1, RotationPoint.Value.Y - 1,
                2, 2);
        }

        Point[] vertexes = VertexesTransform();

        for (int i = 0; i < vertexes.Length - 1; ++i)
        {
            e.Graphics.DrawLine(_shapeLinesPen, vertexes[i], vertexes[i + 1]);
        }
        
        e.Graphics.DrawLine(_shapeLinesPen, vertexes[0], vertexes[^1]);
    }
}