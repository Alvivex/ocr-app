import mysql.connector

mydb = mysql.connector.connect(
    host="alvivex",
    user="yourusername",
    password="yourpassword"
)

mycursor = mydb.cursor()
mycursor.execute("CREATE DATABASE mydatabase")