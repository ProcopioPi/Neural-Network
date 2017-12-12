using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Neural;
using System.Threading;
using Functions;

namespace Test
{
    public partial class Form1 : Form
    {
        Bitmap canvas;
        List<Input> inputs;
        Thread thread;
        NeuralNetwork net;

        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(700, 700);
          
            FillInputs();
        }

        private void FillInputs()
        {
            inputs = new List<Input>();
            inputs.Add(new Input(new double[] { 1, 1 }, new double[] { 0 }));
            inputs.Add(new Input(new double[] { -1, -1 }, new double[] { 0 }));

            inputs.Add(new Input(new double[] { -1, 1 }, new double[] { 1 }));
            inputs.Add(new Input(new double[] { 1, -1 }, new double[] { 1 }));
        }

        private void BuildNet()
        {
            List<Layer> layers;
            int hiddenNuerons, it;
            double rate, lower;
            double error;
            FunctionType Ftype;
            
            layers = new List<Layer>();
            hiddenNuerons = 7;
            rate = 0.5;
            Ftype = FunctionType.SIGMOID;

            layers.Add(new Layer(inputs[0].Features.Length, inputs[0].Features.Length, rate, Ftype));
            layers.Add(new Layer(hiddenNuerons, layers[layers.Count - 1].Neurons.Length, rate, Ftype));
            layers.Add(new Layer(inputs[0].DesiredValue.Length, layers[layers.Count - 1].Neurons.Length, rate, Ftype));

            net = new NeuralNetwork(layers.ToArray());
            net.SetTrainSet(inputs.ToArray());

            error = double.MaxValue;
            lower = double.MaxValue;

            it = 0;
            while (error > 0.001 && it++ < 10000000)
            {
                error = net.Train();
                if (error < lower )
                {
                    lower = error;
                }
                if (it % 50 == 0)
                {
                    MyDelegates.SetTextValue(LBL_IT, "epochs : " + it);
                    MyDelegates.SetTextValue(LBL_ERROR, "Error : " + Math.Round(error, 5));
                    MyDelegates.SetTextValue(LBL_LOWEST, "Lowest : " + Math.Round(lower, 9));
                    
                }

                if (it % 1000 == 0)
                {
                    try
                    {
                        ClassifySpace();
                       
                    }catch(Exception){}
                }
            }
        }

        private void PaintInput()
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                PaintPoint(inputs[i].Features[0], inputs[i].Features[1], inputs[i].DesiredValue[0]);
            }

            PCT_CANVAS.Image = canvas;
        }

        private void PointPaint(double x, double y, Pen pen)
        {
            y *= -10;
            x *= 10;
            x += canvas.Width / 2;
            y += canvas.Height / 2;

            Graphics.FromImage(canvas).DrawLine(pen, (float)x - 1, (float)y - 1, (float)x + 1, (float)y + 1);
            Graphics.FromImage(canvas).DrawLine(pen, (float)x + 1, (float)y - 1, (float)x + 1, (float)y + 1);

            Graphics.FromImage(canvas).FillEllipse(new SolidBrush(pen.Color), (float)x - 6, (float)y - 6, 12, 12);
        }

        private void PointPaint(float x, float y,Pen pen)
        {
            y *= -10;
            x *= 10;
            x += canvas.Width / 2;
            y += canvas.Height / 2;            

            Graphics.FromImage(canvas).DrawLine(pen, x - 1, y - 1, x + 1, y + 1);
            Graphics.FromImage(canvas).DrawLine(pen, x + 1, y - 1, x + 1, y + 1);
        }

       

        private void BTN_LEARN_Click(object sender, EventArgs e)
        {
            PaintInput();

            thread = new Thread(BuildNet);
            thread.Start();
        }

        private void PaintPoint(double x, double y, double value)
        {
            if (value > .5)
                PointPaint(x, y, Pens.Green);
            else

                PointPaint(x, y, Pens.Red);
        }

        //private void BTN_CLASSIFY_Click(object sender, EventArgs e)
        //{
        //    ClassifySpace();
        //}

        private void ClassifySpace()
        {
            double value;
            for (int x = -35; x < 35; x++)
            {
                for (int y = -35; y < 35; y++)
                {
                    if (x == 1 && y == 1)
                        Console.Write("here");
                    if (x == -1 && y == 1)
                        Console.Write("here");

                    value = net.ComputeNetworkOutput(new Input(new double[] { x, y }, new double[] { 1 }))[0];
                    PaintPoint(x, y, value);
                }
            }
            PaintInput();

            MyDelegates.SetBMPValue(PCT_CANVAS, canvas);
        }
    }
}
