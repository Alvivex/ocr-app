import pandas as pd
import pypyodbc as podbc

con1 = podbc.connect("Driver={SQL Server};"
                     "Server=ALVIVEX\SQLEXPRESS;"
                     "Database=EMNIST_Database;"
                     "Trusted_Connection=yes;")
#data_test
data_train = pd.read_sql_table("EMNIST_Merged_Balanced_Test", con1)