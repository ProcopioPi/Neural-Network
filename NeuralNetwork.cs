using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Functions;

namespace Neural
{
    public class NeuralNetwork
    {
        #region Properties
        private Layer[] layers;
        private double[] networkOutput;
        private double[] errorDifference;
        private double learningRate;
        private double error = 0;
        private List<Input> trainSet;
        private Input input;
        
        public Layer[] Layers
        {
            get { return layers; }
        }

        public double[] NetworkOutput
        {
            get { return networkOutput; }
        }

        public double Error
        {
            get { return error; }
        }

        //public NeuralNetwork(string file)
        //{
        //    LoadNetwork(file);
        //}
        
        #endregion

        //Contructor of network, receives declared layers
        public NeuralNetwork(Layer[] layers)
        {
            this.layers = layers;
            //FunctionType = type;
        }
                       
        //STEP TWO : SET PATTERNS and scramble them 
        public void SetTrainSet(Input[] inputs)
        {
            //batch mode would be here
            double[] test;

            test = new double[inputs.Length];
            trainSet = new List<Input>();
            
            trainSet.AddRange(inputs);
            trainSet = trainSet.OrderBy(item => Util.Instance.Rand.Next()).ToList();         
        }

        public double Train()
        {
            //double[] test;
            double batchError;
            int patterns;            

            //test = new double[trainSet.Count];
            batchError = 0;
            patterns = 0;
            while (patterns < trainSet.Count)
            {
                FeedForward(trainSet[patterns]);//HERE WE USE RANDOM PATTERNS

                ComputeNetworkOutput();

                //BATCH is base on the sumation of all ONLINE MODES   
                batchError += CostFunction();

                ComputeDeltaErrors();

                AdjustWeights();

                patterns++;
            }

            error = ((double)batchError * 100) / trainSet.Count;

            return error;
        }

        //assign inputs to every layer
        private void FeedForward(Input input)
        {
            this.input = input;

            layers[0].SetPattern(input.Features);       //Feature vector in input layer

            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].SetPattern(layers[i - 1].ComputeOutputs());    //Inputs to hidden layers we just need final outputs
            }
        }

        public double[] ComputeNetworkOutput(Input input)
        {
            this.input = input;

            layers[0].SetPattern(input.Features);       //Feature vector in input layer

            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].SetPattern(layers[i - 1].ComputeOutputs());    //Inputs to hidden layers we just need final outputs
            }

            return layers[layers.Length - 1].ComputeOutputs();
        }

        //STEP THREE
        private double[] ComputeNetworkOutput()
        {
            networkOutput = layers[layers.Length-1].ComputeOutputs();  //Salida de las neuronas de la última capa
            return networkOutput;
        }

        private double CostFunction()
        {
            double error = 0;
            double[] desiredValue = input.DesiredValue;

            errorDifference = new double[networkOutput.Length];
            for (int i = 0; i < networkOutput.Length; i++)
            {
                errorDifference[i] = (networkOutput[i] - desiredValue[i]);
                error += Math.Pow(errorDifference[i], 2);
            }

            return error/2; 
        }

        //STEP FOUR
        private void ComputeDeltaErrors()
        {
            //Neuron next;
            //Neuron current;
            int lastLayer;                       
            
            //last layer computation
            lastLayer = layers.Length - 1;
            Parallel.For(0, layers[lastLayer].Neurons.Length, i =>
            {
                layers[lastLayer].Neurons[i].ComputeDeltaError(errorDifference[i]);
            });

            //hidden layers delta calculation
            //next = null;
            //current = null;
            for (int i = layers.Length - 2; i >= 0; i--)    //desde la penultima a la primera
            {
                for (int neurons = 0; neurons < layers[i].Neurons.Length; neurons++)//cada neurona de la capa
                {
                    for (int extNeurons = 0; extNeurons < layers[i + 1].Neurons.Length; extNeurons++)
                    {
                        //current = layers[i].Neurons[neurons];       //neurona a la que se le calcula el delta
                        //next = layers[i + 1].Neurons[extNeurons];   //neurona de la siguiente capa
                        //current.ComputeDeltaError(next.DeltaError * next.Weights[neurons]);

                        layers[i].Neurons[neurons].ComputeDeltaError(layers[i + 1].Neurons[extNeurons].DeltaError * layers[i + 1].Neurons[extNeurons].Weights[neurons]);
                    }
                }
            }
        }

        //STEP FIVE
        private void AdjustWeights()
        {
            int j = (layers.Length - 1) ;
            Parallel.For(0, layers.Length-1, i =>
            {
                j = (layers.Length - 1) - i;
                layers[j].AdjustWeights();
            });
        }

        public void SaveNetwork(string fileName)
        {
            // create a writer and open the file
            TextWriter textWriter = new StreamWriter(fileName+".NN");

            textWriter.WriteLine(this.learningRate);
            textWriter.WriteLine(this.error);
            textWriter.WriteLine(layers.Length);//layersN
            textWriter.WriteLine(layers[0].Neurons.Length); // neurons
            textWriter.WriteLine(layers[0].Neurons[0].Weights.Length);//features
            textWriter.WriteLine(layers[layers.Length-1].Neurons.Length);//outputs

            for (int i = 0; i < layers.Length; i++)//recorre capas
            {
                for (int j = 0; j < layers[i].Neurons.Length; j++)//recorre neuronas
                {
                    for (int w = 0; w < layers[i].Neurons[j].Weights.Length; w++)//recorre pesos
                    {
                        // write a line of text to the file
                        textWriter.WriteLine(layers[i].Neurons[j].Weights[w]);
                    }
                    textWriter.WriteLine(layers[i].Neurons[j].Bias);
                }

                textWriter.WriteLine();
            }
            // close the stream
            textWriter.Close();                        
        }
        
        public void LoadNetwork(string network)
        {
            //TextReader textReader = new StreamReader(network);

            //this.learningRate = double.Parse(textReader.ReadLine());
            //this.error = double.Parse(textReader.ReadLine());
            //int layersN = int.Parse(textReader.ReadLine());
            //int neurons = int.Parse(textReader.ReadLine());
            //int features = int.Parse(textReader.ReadLine());
            //int outputs = int.Parse(textReader.ReadLine());

            //this.layers = new Layer[layersN];

            //layers[0] = new Layer(neurons, features, learningRate);
            //for (int l = 1; l < layersN - 1; l++)
            //{
            //    layers[l] = new Layer(neurons, neurons, learningRate);      // HIDDEN LAYERS
            //}
            //layers[layersN - 1] = new Layer(outputs, neurons, learningRate);

            //for (int i = 0; i < layers.Length; i++)
            //{
            //    for (int j = 0; j < layers[i].Neurons.Length; j++)
            //    {
            //        for (int w = 0; w < layers[i].Neurons[j].Weights.Length; w++)
            //        {
            //            // write a line of text to the file
            //            layers[i].Neurons[j].Weights[w] = double.Parse(textReader.ReadLine());
            //        }
            //        layers[i].Neurons[j].Bias = double.Parse(textReader.ReadLine());
            //    }
            //    string str = textReader.ReadLine();//el espacio que separa cada capa
            //}

            //textReader.Close();
        }
    }
}
