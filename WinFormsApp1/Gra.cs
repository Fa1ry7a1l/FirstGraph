using System.Runtime.InteropServices.JavaScript;
using System.Security.AccessControl;

namespace WinFormsApp1;

public class Gra : Form
{
    private Graphics g;
    private Point _point;
    private double x_max = 20;
    private double x_min = 20;
    private double x_len = 20;
    private Func<double, double> f;
    private float step;

    private double y_min;
    private double y_max;
    private double y_len;
    private List<double> allY = new List<double>();
    private bool isFirstDrawn = false;

    public Gra(float minX, float maxX, Func<double, double> f, float step = 0.1f)
    {
        //InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        g = this.CreateGraphics();


        //this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
        //f = d => Math.Sin(d);
        this.step = step;
        this.x_max = maxX;
        this.x_min = minX;
        this.x_len = maxX - minX;
        this.f = f;


        //this.ResizeEnd += (sender, args) => Form1_Resize(sender, args);
        this.Paint += (sender, args) =>
        {
            if (!isFirstDrawn)
                Draw();
        };
        this.SizeChanged+= (sender, args) => Form1_Resize(sender, args);
    }

    private void Draw()
    {
        g.Clear(Color.White);
        Pen pen = new Pen(Color.SlateBlue);
        SolidBrush solid = new SolidBrush(Color.Green);


        double y;

        if (allY.Count == 0)
        {
            allY = new List<double>();

            for (double x = x_min; x < x_max; x += step)
            {
                y = f(x);
                allY.Add(y);
            }

            y_min = allY.Min();
            y_max = allY.Max();
            y_len = y_max - y_min;
        }
        /*Console.WriteLine(y_min);
        Console.WriteLine(y_max);*/

        Point previousPoint = new Point(0, (int)((allY[0] - y_min) / y_len) * Height);

        for (int i = 0; i < allY.Count; i++)
        {
            //g.FillEllipse(solid, (float)(step*i / x_len * Width), (float)((allY[i] - y_min) / y_len) * Height, 3, 3);
            Point newPoint = new Point((int)(step * i / x_len * Width),
                Height - 50 - (int)((allY[i] - y_min) / y_len * (Height - 50)));
            g.DrawLine(pen, previousPoint, newPoint);
            previousPoint = newPoint;
        }


        /*for (double i = 0; i < Width; i += 1)
        {
            y = f(i);
            Console.WriteLine(y);
            if (Math.Abs(y) <= y_max)
            {
                y = -y * Height / y_max + Height / 2;
                g.FillEllipse(solid, (float)i + Width / 2, (float)y, 3, 3);
            }
            //g.DrawEllipse(pen, (float)i, (float)y, 5, 5);
        }*/

        solid.Dispose();
        pen.Dispose();
    }

    private void Form1_Resize(object sender, System.EventArgs e)
    {
        //Refresh();

        Control control = (Control)sender;
        this.Size = new Size(control.Width, control.Height);
        //g = this.CreateGraphics();
        //Update();
        Draw();
    }

    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        Pen pen = new Pen(Color.SlateBlue);
        SolidBrush solid = new SolidBrush(Color.Red);
        g.FillEllipse(solid, e.X, e.Y, 5, 5);
        //g.DrawEllipse(pen, e.X, e.Y, 5, 5);

        solid.Dispose();
        pen.Dispose();
    }
}