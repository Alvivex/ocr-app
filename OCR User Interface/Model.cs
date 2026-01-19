using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Markup;

namespace OCR_User_Interface
{
    internal class Model
    {
        public static double[,] weights1;
        public static double[] biases1;
        public static double[,] weights2;
        public static double[] biases2;
        public static double[,] weights3;
        public static double[] biases3;

        public static string modelFilePath;

        public Model(string mfp)
        {
            modelFilePath = mfp;
            LoadNetwork();
        }

        public static void LoadNetwork()
        {
            string fullText = File.ReadAllText(modelFilePath);

            string[] splitText = fullText.Split('|');

            // Splitting string further
            // Referencing starts at 1 for splitText
            string[] subSplit0 = splitText[1].Split(','); // weights1
            string[] subSplit1 = splitText[2].Split(','); // biases1
            string[] subSplit2 = splitText[3].Split(','); // weights2
            string[] subSplit3 = splitText[4].Split(','); // biases2
            string[] subSplit4 = splitText[5].Split(','); // weights3
            string[] subSplit5 = splitText[6].Split(','); // biases3

            //===========================
            // Assigning weights1
            //===========================

            weights1 = new double[784, 128];

            for (int i = 0; i < subSplit0.Length; i++)
            {
                subSplit0[i] = subSplit0[i].Replace("[", "");
                subSplit0[i] = subSplit0[i].Replace("]", "");

                string[] values = subSplit0[i].Split(' ');
                int cw1 = 0;

                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = values[j].Trim();
                    if (values[j] != String.Empty)
                    {
                        weights1[i, cw1] = Convert.ToDouble(values[j]);
                        cw1++;
                    }
                }
            }

            //===========================
            // Assigning biases1
            //===========================

            biases1 = new double[128];

            int cb1 = 0;
            for (int i = 0; i < subSplit1.Length; i++)
            {
                subSplit1[i] = subSplit1[i].Trim();
                if (subSplit1[i] != String.Empty)
                {
                    biases1[cb1] = Convert.ToDouble(subSplit1[i]);
                    cb1++;
                }
            }

            //===========================
            // Assigning weights2
            //===========================

            weights2 = new double[128, 128];


            for (int i = 0; i < subSplit2.Length; i++)
            {
                subSplit2[i] = subSplit2[i].Replace("[", "");
                subSplit2[i] = subSplit2[i].Replace("]", "");

                string[] values = subSplit2[i].Split(' ');
                int cw2 = 0;

                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = values[j].Trim();
                    if (values[j] != String.Empty)
                    {
                        weights2[i, cw2] = Convert.ToDouble(values[j]);
                        cw2++;
                    }
                }
            }


            //===========================
            // Assigning biases2
            //===========================

            biases2 = new double[128];

            int cb2 = 0;
            for (int i = 0; i < subSplit3.Length; i++)
            {
                subSplit3[i] = subSplit3[i].Trim();
                if (subSplit3[i] != String.Empty)
                {
                    biases2[cb2] = Convert.ToDouble(subSplit3[i]);
                    cb2++;
                }
            }

            //===========================
            // Assigning weights3
            //===========================

            weights3 = new double[128, 47];


            for (int i = 0; i < subSplit4.Length; i++)
            {
                subSplit4[i] = subSplit4[i].Replace("[", "");
                subSplit4[i] = subSplit4[i].Replace("]", "");

                string[] values = subSplit4[i].Split(' ');
                int cw3 = 0;

                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = values[j].Trim();
                    if (values[j] != String.Empty)
                    {
                        weights3[i, cw3] = Convert.ToDouble(values[j]);
                        cw3++;
                    }
                }
            }


            //===========================
            // Assigning biases3
            //===========================

            biases3 = new double[47];

            int cb3 = 0;
            for (int i = 0; i < subSplit5.Length; i++)
            {
                subSplit5[i] = subSplit5[i].Trim();
                if (subSplit5[i] != String.Empty)
                {
                    biases3[cb3] = Convert.ToDouble(subSplit5[i]);
                    cb3++;
                }
            }
        }

        public double[] ForwardPass(double[] inputLayer)
        {
            double[] layer1 = new double[128];
            double[] layer2 = new double[128];
            double[] layer3 = new double[47];

            //_________________________________________________________
            // From input layer to layer 1
            for (int i = 0; i < 784; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    layer1[j] += (weights1[i, j] * inputLayer[i]);
                }
            }

            // Add biases
            for (int i = 0; i < layer1.Length; i++)
            {
                layer1[i] += biases1[i];
            }

            // Relu
            for (int i = 0; i < 128; i++)
            {
                layer1[i] = ReLU(layer1[i]);
            }
            //_____________________________________________________________

            // From layer 1 to layer 2
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    layer2[j] += (weights2[i, j] * layer1[i]);
                }
            }

            // Add biases
            for (int i = 0; i < layer2.Length; i++)
            {
                layer2[i] += biases2[i];
            }

            for (int i = 0; i < 128; i++)
            {
                layer2[i] = ReLU(layer2[i]);
            }
            //_____________________________________________________________________

            // From layer 2 to layer 3 (output)
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    layer3[j] += (weights3[i, j] * layer2[i]);
                }
            }

            // Add biases
            for (int i = 0; i < layer3.Length; i++)
            {
                layer3[i] += biases3[i];
            }
            
            double esum = ExpSum(layer3);

            for (int i = 0; i < 47; i++)
            {
                layer3[i] = Softmax(esum, layer3[i]);
            }
            
            //____________________________________________________________________

            return layer3;
        }

        public static double ReLU(double input)
        {
            if (input <= 0)
            {
                return 0;
            }

            else
            {
                return input;
            }
        }

        public static double Softmax(double expSum, double input)
        {
            return (Math.Exp(input) / expSum);
        }

        public static double ExpSum(double[] inputArray)
        {
            double expSum = 0;
            // Summing inputArray
            for (int i = 0; i < inputArray.Length; i++)
            {
                expSum += Math.Exp(inputArray[i]);
            }

            return expSum;
        }
    }
}
