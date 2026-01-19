import tensorflow as tf

def SaveAsTextFile():
    model = tf.keras.models.load_model('handwritten3.model')
    f = open("savefile3.txt", "w")
    counter = 1
    for i in range(0, 6):
        f.write("|" + "\n")
        for tensor in model.weights[i]:
            value = str(tf.get_static_value(tensor))
            if i % 2 == 0:
                f.write(value + "," + "\n")
            else:
                if counter % 8 == 0:
                    f.write(value + "," + "\n")
                else:
                    f.write(value + ",")
            counter += 1

    print(counter)
    f.close()

SaveAsTextFile()