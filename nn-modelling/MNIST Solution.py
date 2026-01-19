# Neural network to solve MNIST database

'''
3 components:
1 - Store, configure and split dataset into train and test data
2 - Make a neural network using MNN module that takes 784 inputs and returns 10 outputs
3 - Train the network and format so that answers can be inputted and outputs are returned with an accuracy rating
'''
import numpy

import NNModular as mnn
import CSVtoImage as cti
import numpy as np
import pandas as pd
from matplotlib import pyplot as plt

def create_dataset():
    # Split the data into training and testing data
    train_data = pd.read_csv("mnist_train.csv")[0:1000]
    images = np.array(train_data.iloc[:,1:])
    labels = np.array(train_data.iloc[:,0])

    return zip(images, labels)

def create_network():
    network = [
        mnn.Dense(784, 10),
        mnn.Sigmoid(),
        mnn.Dense(10, 10),
        mnn.Sigmoid(),
        mnn.Dense(10, 10),
        mnn.Softmax()
    ]
    return network

def train_network(neural_network, train_dataset):
    learning_rate = 0.1
    epochs = 1000
    index = 0
    indices = []
    predictions = []

    for e in range(epochs):
        print("Epoch: ", e)
        index = 0

        for x, y in train_dataset:
            output = x.reshape(784, 1)
            # Forward pass
            for layer in neural_network:
                output = layer.forward(output)

            # backprop
            output = np.reshape(output, (10,))
            grad = np.reshape(np.subtract(output, generate_onehot(y)), (10, 1))
            accuracy = np.dot(output, generate_onehot(y))

            print("Image index: ", index, ", Accuracy: ", accuracy)

            for layer in reversed(network):
                grad = layer.backward(grad, learning_rate)
                # print("passed back")

            # The modulus value determines the sampling frequency
            if (index%10 == 0):
                predictions.append(accuracy)
                indices.append(index)
            index += 1

    plt.plot(indices, predictions)
    plt.show()

def generate_onehot(label):
    output_values = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    one_hot = []
    for value in output_values:
        if value == label:
            one_hot.append(1)
        else:
            one_hot.append(0)
    return one_hot

data = create_dataset()
network = create_network()

train_network(network, data)