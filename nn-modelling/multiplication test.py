import NNModular as nnm
import random as rnd
import numpy as np

def create_network():
    network = [
        nnm.Dense(2, 10),
        nnm.Sigmoid(),
        nnm.Dense(10, 1),
        nnm.Softmax()
    ]
    return network

def create_dataset():
    dataset = []
    answers = []

    for i in range(1, 100):
        num1 = rnd.randint(1, 100)
        num2 = rnd.randint(1, 100)
        dataset.append([num1, num2])
        answers.append(num1 * num2)

    return zip(dataset, answers)


def train_network(neural_network, dataset):
    # Training the neural network
    
    # Setting control variables
    epochs = 1
    learning_rate = 0.1

    for e in range(epochs):
        #print("_____________________Epoch: ", e+1,"_______________________")
        error = 0
        for x, y in dataset:
            output = x
            for layer in network:
                output = layer.forward(output)

            print(output)
            break
            '''
            # Calculating error and doing backpropagation
            error = nnm.mse(y, output)

            grad = nnm.mse_prime(y, output)
            for layer in reversed(network):
                grad = layer.backward(grad, learning_rate)

            error /= len(x)
            #print('error=%f' % (error), 'x=',x,' ,ypred=', output)
        #dnn.Display.function_graph(dataset, network)
            '''

network = create_network()
dataset = create_dataset()

train_network(network, dataset)