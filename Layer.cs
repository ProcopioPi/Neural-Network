using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Functions;

namespace Neural
{
    public class Layer
    {
        private Neuron[] neurons;
        private double[] y;
       
        public Neuron[] Neurons
        {
            get { return neurons; }
        }

        //Layer constructor
        public Layer(int neuronCount, int weights, double learningRate,FunctionType type)
        {
            neurons = new Neuron[neuronCount];
            for (int n = 0; n < neurons.Length; n++)
            {
                neurons[n] = new Neuron(weights, learningRate, type);
            }
        }

        public void SetPattern(double[] features)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Inputs = new double[features.Length];

                //ingresa cada feature 
                for (int f = 0; f < features.Length; f++)
                {
                    neurons[i].Inputs[f] = features[f];
                }
            }
        }
        
        public void AdjustWeights()
        {            
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].AdjustWeights();
            }//*/        
        }

        //Compute the output of the layer
        public double[] ComputeOutputs()
        {
            y = new double[neurons.Length];

            for (int n = 0; n < neurons.Length; n++)
            {
                y[n] = neurons[n].Output();
            }

            return y;
        }
    }
}
