namespace WinForms_2DTransformations;

partial class MatrixTransformationsForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.WindowState = FormWindowState.Maximized;
        this.ClientSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - 20);
        this.Text = "Matrix Transformations Window";
        this.Paint += OnPaint;
        this.MouseMove += OnMouseMove;
        this.KeyDown += OnKeyDown;
        this.MouseClick += OnMouseClick;
        this.DoubleBuffered = true;

        Point UIStart = new Point(50, 40);
        int UIIntervalX = 30;
        int UIIntervalY = 30;
        int labelsWidth = 50;
        int textBoxesWidth = 100;
        
        _lbMoveX = new Label();
        _lbMoveX.Location = UIStart;
        _lbMoveX.Width = labelsWidth;
        _lbMoveX.Text = "Move X";

        _tbMoveX = new TextBox();
        _tbMoveX.Location = new Point(UIStart.X + labelsWidth + UIIntervalX, UIStart.Y);
        _tbMoveX.Width = textBoxesWidth;
        _tbMoveX.Text = 0.ToString();
        _tbMoveX.TextChanged += Tb_OnTextChanged;
        _tbMoveX.Name = "_tbMoveX";
        
        _lbMoveY = new Label();
        _lbMoveY.Location = new Point(UIStart.X, _lbMoveX.Location.Y + UIIntervalY);
        _lbMoveY.Width = labelsWidth;
        _lbMoveY.Text = "Move Y";
        
        _tbMoveY = new TextBox();
        _tbMoveY.Location = new Point(UIStart.X + labelsWidth + UIIntervalX, _tbMoveX.Location.Y + UIIntervalY);
        _tbMoveY.Width = textBoxesWidth;
        _tbMoveY.Text = 0.ToString();
        _tbMoveY.TextChanged += Tb_OnTextChanged;
        _tbMoveY.Name = "_tbMoveY";
        
        _lbRotate = new Label();
        _lbRotate.Location = new Point(UIStart.X, _lbMoveY.Location.Y + UIIntervalY);
        _lbRotate.Width = labelsWidth;
        _lbRotate.Text = "Rotate";
        
        _tbRotate = new TextBox();
        _tbRotate.Location = new Point(_tbMoveY.Location.X, _tbMoveY.Location.Y + UIIntervalY);
        _tbRotate.Width = textBoxesWidth;
        _tbRotate.Text = 0.ToString();
        _tbRotate.TextChanged += Tb_OnTextChanged;
        _tbRotate.Name = "_tbRotate";
        
        _lbScaleX = new Label();
        _lbScaleX.Location = new Point(UIStart.X, _lbRotate.Location.Y + UIIntervalY);
        _lbScaleX.Width = labelsWidth;
        _lbScaleX.Text = "Scale X";
        
        _tbScaleX = new TextBox();
        _tbScaleX.Location = new Point(_tbRotate.Location.X, _tbRotate.Location.Y + UIIntervalY);
        _tbScaleX.Width = textBoxesWidth;
        _tbScaleX.Text = 1.ToString();
        _tbScaleX.TextChanged += Tb_OnTextChanged;
        _tbScaleX.Name = "_tbScaleX";
        
        _lbScaleY = new Label();
        _lbScaleY.Location = new Point(UIStart.X, _lbScaleX.Location.Y + UIIntervalY);
        _lbScaleY.Width = labelsWidth;
        _lbScaleY.Text = "Scale Y";
        
        _tbScaleY = new TextBox();
        _tbScaleY.Location = new Point(_tbScaleX.Location.X, _tbScaleX.Location.Y + UIIntervalY);
        _tbScaleY.Width = textBoxesWidth;
        _tbScaleY.Text = 1.ToString();
        _tbScaleY.TextChanged += Tb_OnTextChanged;
        _tbScaleY.Name = "_tbScaleY";
        
        _checkBoxReflectOx = new CheckBox();
        _checkBoxReflectOx.Location = new Point(_tbScaleY.Location.X, _tbScaleY.Location.Y + UIIntervalY);
        _checkBoxReflectOx.Text = "Reflect OX";
        _checkBoxReflectOx.CheckStateChanged += CheckBoxReflectOnCheckStateChanged;
        _checkBoxReflectOx.Name = "_checkBoxReflectOx";
        
        _checkBoxReflectOy = new CheckBox();
        _checkBoxReflectOy.Location = new Point(_checkBoxReflectOx.Location.X, _checkBoxReflectOx.Location.Y + UIIntervalY);
        _checkBoxReflectOy.Text = "Reflect OY";
        _checkBoxReflectOy.CheckStateChanged += CheckBoxReflectOnCheckStateChanged;
        _checkBoxReflectOy.Name = "_checkBoxReflectOy";

        _btnReset = new Button();
        _btnReset.Location = new Point(_checkBoxReflectOy.Location.X, _checkBoxReflectOy.Location.Y + UIIntervalY);
        _btnReset.Width = textBoxesWidth;
        _btnReset.Text = "Reset";
        _btnReset.Click += BtnResetOnClick;
        _btnReset.Name = "_btnReset";
        
        
        this.Controls.Add(_lbMoveX);
        this.Controls.Add(_tbMoveX);
        
        this.Controls.Add(_lbMoveY);
        this.Controls.Add(_tbMoveY);
        
        this.Controls.Add(_lbRotate);
        this.Controls.Add(_tbRotate);
        
        this.Controls.Add(_lbScaleX);
        this.Controls.Add(_tbScaleX);
        
        this.Controls.Add(_lbScaleY);
        this.Controls.Add(_tbScaleY);
        
        this.Controls.Add(_checkBoxReflectOx);
        this.Controls.Add(_checkBoxReflectOy);
        
        this.Controls.Add(_btnReset);
    }

    #endregion
}