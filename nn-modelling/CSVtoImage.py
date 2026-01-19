# Copy and pasted from stack overflow. LINK:
# https://stackoverflow.com/questions/68725934/how-to-read-save-and-display-images-encoded-in-csv-format

import numpy as np
import pandas as pd
from matplotlib import pyplot as plt

# Read csv file
data_frame = pd.read_csv(r"C:\Users\turbo\Downloads\emnist-balanced-test.csv\emnist-balanced-test.csv")

#def format_image(df):
    #sample_image()

def display_image(df, index):
    # read pixels
    images = np.array(df.iloc[:, 1:])
    labels = np.array(df.iloc[:, 0])

    # reshape 784 rows to 28 height x 28 width
    sample_image = images[index,:].reshape(28,28)

    # plot image
    #plt.imshow(sample_image)
    #plt.axis('off')
    #plt.show()
    # plot it's label
    #print(labels[index])

# save image
#plt.savefig("./image{}_label{}".format(index,labels[index]))

