import cv2
import tensorflow as tf
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

#=====================================================================
# ASSIGNING DATA
train_data = pd.read_csv(r"C:\Users\turbo\Downloads\emnist-balanced-train.csv\emnist-balanced-train.csv")
test_data = pd.read_csv(r"C:\Users\turbo\Downloads\emnist-balanced-test.csv\emnist-balanced-test.csv")

# Slicing up data into chunks
x_train = train_data.iloc[:, 1:]
y_train = train_data.iloc[:, 0]

x_test = test_data.iloc[:, 1:]
y_test = test_data.iloc[:, 0]

# Normalizing inputs
x_train = tf.keras.utils.normalize(x_train, axis=1)
x_test = tf.keras.utils.normalize(x_test, axis=1)
#=====================================================================

# TRAINING
model = tf.keras.models.Sequential()
model.add(tf.keras.layers.Input(784)) # Input layer
model.add(tf.keras.layers.Dense(128, activation='relu')) # Layer 1
model.add(tf.keras.layers.Dense(128, activation='relu')) # Layer 2
model.add(tf.keras.layers.Dense(47, activation='softmax')) # Output layer

model.compile(optimizer="adam", loss='sparse_categorical_crossentropy', metrics=['accuracy']) # Extra optimisers

model.fit(x_train, y_train, epochs=20) # Train for 100 epochs
model.save('handwritten3.model') # Save the model

#=====================================================================
# TESTING
#model1 = tf.keras.models.load_model('handwritten.model')
#fr"C:\Users\turbo\OneDrive\Documents\School\Computing Docs\NEA\Data\9.png"

'''
for i in range(0, 9):
    # Retrieve test image
    img = cv2.imread()[:, :, 0]
    plt.imshow(img, cmap=plt.cm.binary) # Plot on graph

    img = np.invert(np.array([img])) # Change color scheme to white on black
    img = np.reshape(img, (1, 784)) # Reshape to a flat array to input into the
    img = tf.keras.utils.normalize(img, axis=1) # Normalize inputs from 0-255 to 0-1

    prediction = model.predict(img) # Make a prediction
    print("The digit is: ", np.argmax(prediction)) # Display prediction
    plt.show() # Display the graph
'''
