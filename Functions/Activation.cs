using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functions
{
    public class Activation
    {
        private FunctionType functionType;
        private Functions.FunctionType type;

        public Activation(Functions.FunctionType type)
        {
            this.type = type;
        }

        public double Activate(double x)
        {
            double result;
            result = 0;
            switch (functionType)
            {
                case FunctionType.SIGMOID:
                    result = Sigmoid(x);
                    break;
                case FunctionType.HYPERBOLIC:
                    result = HyperbolicTangent(x);
                    break;
                case FunctionType.SIN:
                    result = Sin(x);
                    break;
                case FunctionType.LEAKY_RELU:
                    result = RELU(x);
                    break;
                case FunctionType.SOFT_PLUS:
                    result = SoftPlus(x);
                    break;
                case FunctionType.LOGISTIC:
                    result = Logistic(x);
                    break;
            }

            return result;
        }

        public double Derivative(double x)
        {
            double result;
            result = 0;
            switch (functionType)
            {
                case FunctionType.SIGMOID:
                    result = SigmoidDerivative(x);
                    break;
                case FunctionType.HYPERBOLIC:
                    result = HyperbolicTangentDerivative(x);
                    break;
                case FunctionType.SIN:
                    result = Cos(x);
                    break;
                case FunctionType.LEAKY_RELU:
                    result = RELUDerivative(x);
                    break;
                case FunctionType.SOFT_PLUS:
                    result = DSoftPlus(x);
                    break;
                case FunctionType.LOGISTIC:
                    result = LogisticDerivative(x);
                    break;
            }

            return result;
        }

        private double SoftPlus(double x)
        {
            return Math.Log(Math.Exp(x) + 1);
        }

        private double DSoftPlus(double x)
        {
            return Logistic(x);
        }

        private double Logistic(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        private double LogisticDerivative(double x)
        {
            double fx;

            fx = Math.Exp(x);
            return fx / ((1 + fx) * (1 + fx));//fx * (1 - fx); 
        }

        private double RELU(double x)
        {
            if (x == 0)
                return .0001;

            if (x < 0)
                return x * .01;
            else
                return x;
        }

        private double RELUDerivative(double x)
        {
            if (x < 0)
                return 0.01;
            else
                return 1;
        }

        private double Sin(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;
            return Math.Sin(x);
        }

        private double Cos(double x)
        {
            if (x < -45.0) return 1.0;
            else if (x > 45.0) return 0.0;

            return Math.Cos(x);
        }

        private double Sigmoid(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;

            else return 1.0 / (1.0 + Math.Exp(-x));
        }

        private double SigmoidDerivative(double x)
        {
            return x * (1 - x);
        }

        private double HyperbolicTangent(double x)
        {
            if (x < -45.0) return -1.0;
            else if (x > 45.0) return 1.0;

            else return Math.Tanh(x);
        }

        private double HyperbolicTangentDerivative(double x)
        {
            // tanh derivative
            double th = HyperbolicTangent(x);
            return 1 - (th * th);
        }
    }
}
