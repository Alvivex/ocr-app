import pandas as pd
import numpy as np

data_frame = pd.read_csv("emnist-balanced-train.csv")

images = np.array(data_frame.iloc[:,1:])
labels = np.array(data_frame.iloc[:,0])

concat_data = []

for image in images:
    cnct = ""
    for value in image:
        cnct += str(value) + ","
    concat_data.append(cnct)

data = {
    'Labels': labels,
    'Images': concat_data
}

new_df = pd.DataFrame(data)
new_df.to_excel('Merged EMNIST Train.xlsx', index=False)
