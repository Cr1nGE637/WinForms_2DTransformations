namespace WinForms_2DTransformations;

public partial class MatrixTransformationsForm
{
    #region Collection Data Elements Declaration

    private Label _lbMoveX;
    private TextBox _tbMoveX;
    private Label _lbMoveY;
    private TextBox _tbMoveY;
    private Label _lbRotate;
    private TextBox _tbRotate;
    private Label _lbScaleX;
    private TextBox _tbScaleX;
    private Label _lbScaleY;
    private TextBox _tbScaleY;

    private Button _btnReset;

    private CheckBox _checkBoxReflectOx;
    private CheckBox _checkBoxReflectOy;
    
    #endregion
    
    private void Tb_OnTextChanged(object? sender, EventArgs e)
    {
        if (sender is not TextBox textBox) return;

        double changedValue = 0.0;

        try
        {
            changedValue = double.Parse(textBox.Text);
        }
        
        catch (Exception exception)
        {
            return;
        }
        
        switch (textBox.Name)
        {
            case "_tbMoveX":
                Dx = changedValue;
                break;            
            
            case "_tbMoveY":
                Dy = -changedValue;
                break;
            
            case "_tbRotate":
                Angle = -changedValue;
                break;
            
            case "_tbScaleX":
                ScaleX = changedValue;
                break;
            
            case "_tbScaleY":
                ScaleY = changedValue;
                break;
            
            default:
                throw new Exception("Invalid input data");
        }
    }

    private void OnMouseClick(object? sender, MouseEventArgs e)
    {
        this.ActiveControl = null;
        _sPressed = _sxPressed = _syPressed = false;
        _gPressed = _gxPressed = _gyPressed = false;
        _rPressed = false;

        if (e.Button == MouseButtons.Middle)
        {
            RotationPoint = new Point(e.Location.X - ClientSize.Width / 2, e.Location.Y - ClientSize.Height / 2);
            Invalidate();
        }

        if (e.Button == MouseButtons.Right)
        {
            RotationPoint = null;
            Invalidate();
        }
    }

    private void BtnResetOnClick(object? sender, EventArgs e)
    {
        _tbMoveX.Text = "0";
        _tbMoveY.Text = "0";
        _tbRotate.Text = "0";
        _tbScaleX.Text = "1";
        _tbScaleY.Text = "1";
        
        this.ActiveControl = null;
        _sPressed = _sxPressed = _syPressed = false;
        _gPressed = _gxPressed = _gyPressed = false;
        _rPressed = false;
        _checkBoxReflectOx.Checked = false;
        _checkBoxReflectOy.Checked = false;
        RotationPoint = null;
        Invalidate();
    }
    
    private void CheckBoxReflectOnCheckStateChanged(object? sender, EventArgs e)
    {
        SetTransformElements();
    }
}