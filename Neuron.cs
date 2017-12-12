using System;
using Functions;

namespace Neural
{
    public class Neuron
    {
        #region Properties

        private double[] inputs;
        private double[] weights;
        private double outputY;
        private double bias;
        private double deltaError;
        private double learningRate;
        private int size;
        private static Random rand;
        private Activation function;
                
        #endregion

        #region Fields

        public double DeltaError
        {
            get { return deltaError; }
            set { deltaError = value; }
        }

        public double[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }
         
        public double Bias
        {
            get { return bias; }
            set { bias = value; }
        }
        
        public double[] Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        #endregion

        //so there wont be a problem
        public Neuron(int weightsNumber, double learningRate, FunctionType type)
        {
            rand = Util.Instance.Rand;
            InitializeWeights(weightsNumber);
            this.learningRate = learningRate;
            function = new Activation(type);
        }

        private void InitializeWeights(int weightsNumber)
        {
            double total;
            int i;

            this.weights = new double[weightsNumber];
            i = 0;
            total = 0;
            while(i < weightsNumber)
            {
                this.weights[i] = rand.NextDouble()-0.5;
                total += this.weights[i];
                i++;
            }
            this.bias = rand.NextDouble() - 0.5;

            total += this.bias;

            while (i < weightsNumber)
            {
                this.weights[i] /= total;
                i++;
            }

            this.bias /= total;           
            this.size = weights.Length;
        }
        
        public double DotProduct(double[] input)
        {
            double sumation = 0;
            int i = 0;
            while( i < size)
            {
                sumation += this.weights[i] * input[i];
                i++;
            }

            return sumation + bias;
        }

        public double Derivative(double x)
        {
            return function.Derivative(x);
        }

        public void ComputeDeltaError(double x)
        {
            deltaError = DerivY() * x;
        }

        public double DerivY()
        {
            return function.Derivative(outputY);
        }

        public double Output()
        {
            double sum;
           
            sum = DotProduct(inputs);
            outputY = function.Activate(sum);
            return outputY;
        }

        private double ComputeIncrement(int i)
        {
            //deltaError = con el delta de la derecha y peso de la derecha o la diferencia
            //inputs[i] entrada a la neurona del peso de la izquierda
            return -(deltaError * inputs[i] * learningRate);
        }
        
        public void AdjustWeights()
        {
            int i;
           
            i = 0;
            while (i < weights.Length)
            {
                weights[i] += ComputeIncrement(i);
                i++;
            }

            bias -= deltaError * learningRate;
        }
    }
}
