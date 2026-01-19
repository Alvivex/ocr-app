import tensorflow as tf

mnist = tf.keras.datasets.mnist
(x_train, y_train), (x_test, y_test) = mnist.load_data()

# Normalize from 0-255 to 0 and 1
x_train = tf.keras.utils.normalize(x_train, axis=1)
x_test = tf.keras.utils.normalize(x_test, axis=1)
'''
'''
model = tf.keras.models.Sequential()
model.add(tf.keras.layers.Flatten(input_shape=(28, 28)))
model.add(tf.keras.layers.Dense(128, activation='relu'))
model.add(tf.keras.layers.Dense(128, activation='relu'))
model.add(tf.keras.layers.Dense(10, activation='softmax'))

model.compile(optimizer="adam", loss='sparse_categorical_crossentropy', metrics=['accuracy'])

model.fit(x_train, y_train, epochs=20)
model.save('numeric.model')

'''
def Get_Prediction(image):
    print("Getting Prediction...")
    model = tf.keras.models.load_model('handwritten.model')
    image = np.invert(np.array([image]))
    prediction = model.predict(image)
    print(np.argmax(prediction))

model = tf.keras.models.load_model('numeric.model')

for weight in model.weights[1]:
    tensor = weight
    print(tf.get_static_value(tensor))
'''

