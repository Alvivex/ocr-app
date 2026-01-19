import numpy as np
import pandas as pd
import random as rnd
from matplotlib import pyplot as plt

def create_dataset():
    # Split dataset into images and labels
    train_data = pd.read_csv("emnist-balanced-test.csv")[0:5000]
    images = train_data.iloc[:,1:]
    labels = train_data.iloc[:,0]
    return train_data

class Dense_Layer():
    def __init__(self, in_size, out_size):
        self.weights = np.random.randn(out_size, in_size)
        self.biases = np.random.randn(out_size, 1)
    def forward(self, input_nodes):
        self.input_nodes = input_nodes
        return np.dot(self.weights, self.input_nodes) + self.biases
    def back_prop(self, inputValues):
        self.
        return

class Activation_Layer():
    def __init__ (self, function):
        self.function = function

    def forward(self, input):
        self.input = input
        return self.function(self.input)

def ReLU(input):
    relu = lambda x : np.maximum(0, x)
    return relu(input)

network = [
    Dense_Layer(8, 2),
    Activation_Layer(ReLU),
    Dense_Layer(2, 1),
    Activation_Layer(ReLU)
]

def train():
    output = [1, 0, 1, 0, 0, 0, 1, 0]
    for layer in network:
        output = layer.forward(output)
    print(output)

train()