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
import random as rnd
from matplotlib import pyplot as plt

def create_dataset():
    # Split the data into training and testing data
    train_data = pd.read_csv("mnist_train.csv")[0:5000]

    images = train_data.iloc[:,1:]
    labels = train_data.iloc[:,0]

    return train_data

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

    images = np.array(train_dataset.iloc[:, 1:])
    labels = np.array(train_dataset.iloc[:, 0])

    indices = []
    confidences = []
    index = 0
    for e in range(epochs):
        print("____________________Epoch:", e, "___________________________")

        for x, y in zip(images, labels):
            output = x.reshape(784, 1)
            # Forward pass
            for layer in neural_network:
                output = layer.forward(output)

            # backprop
            output = np.reshape(output, (10,))
            grad = np.reshape(np.subtract(output, generate_onehot(y)), (10, 1))

            #print("Prediction: ", np.dot(output, generate_onehot(y)))

            for layer in reversed(network):
                grad = layer.backward(grad, learning_rate)
                # print("passed back")
            if (index%1000 == 0):
                confidences.append(np.dot(output, generate_onehot(y)))
                indices.append(index)
            index += 1


    display_graph(indices, confidences)
def generate_onehot(label):
    output_values = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    one_hot = []
    for value in output_values:
        if value == label:
            one_hot.append(1)
        else:
            one_hot.append(0)
    return one_hot

def display_graph(x_indices, y_confidence):
    plt.plot(x_indices, y_confidence, color='green')
    plt.show()

def test_network(network, index):
    test_data = pd.read_csv("mnist_train.csv")[5000:]
    #cti.display_image(train_data, index)

    images = np.array(test_data.iloc[:,1:])
    labels = np.array(test_data.iloc[:, 0])

    output = images[index].reshape(784, 1)
    for layer in network:
        output = layer.forward(output)

    output = np.reshape(output, (10,))
    #print("Prediction: ", get_prediction(output), "Confidence: ", np.dot(output, generate_onehot(labels[index])))
    #print("Actual value: ", labels[index])
    return np.dot(output, generate_onehot(labels[index]))

def get_prediction(prediction_array):
    possible_outputs = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    for i in range(0, 9):
        if prediction_array[i] == max(prediction_array):
            return possible_outputs[i]

def test_accuracy(network, iterations):
    accuracy = 0
    print("Calculating accuracy...")
    for i in range(0, iterations-1):
        test_value = test_network(network, rnd.randint(500, 1000))
        accuracy += test_value
        print("test: ", i, ", confidence: ", test_value, ", avg accuracy: ",accuracy / (i+1))

data = create_dataset()
network = create_network()

train_network(network, data)
test_accuracy(network, 10)
#test_network(network, 5)