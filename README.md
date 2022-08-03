## 👨‍💻 This is a Student Manage Form - Small Desktop Application

### 📺 Demo Video


https://user-images.githubusercontent.com/59244522/182657260-b5f8b352-3792-4c44-910c-e67bfae4b25a.mp4


### 🏷️ Prerequisites

- Have **Visual Studio** installed
- Have **SQL Server** installed

### 🏷️ Installation

1.  Fork, Clone or Download this Repository.
2.  Open Project in `Visual Studio IDE`.
3.	Connect to the SQL Server.

![Screenshot 2022-08-03 214553](https://user-images.githubusercontent.com/59244522/182658710-98b0621a-d42b-4468-9509-88169dbecc0d.png)

4.  Create a New Database. (Databases  → New Database ) - Name the Database as Student.
5.	Create the following Table in the Student Database.
       
         CREATE TABLE Student ( ID INT PRIMARY KEY, Name VARCHAR (50), Age INT, GPA FLOAT, Address VARCHAR (50) );

6.	Add a New Connection in `Visual Studio IDE`.
       
         Server Explorer → Data Connection → Add Connection

7.	Select the `Server` & `Database` which you want to connect.
8.	Go to the Properties and Copy the Connection String. 
9.  Paste it within `@"YourConnectionString"` Tag Inside the `getConnectionString()`.
10. Set `ConnectionString` Properly.
11. **Run** Project.


### `'C# Beginning😎'`

---
#### 📌 in 2022;


![c-sharp](https://user-images.githubusercontent.com/59244522/182662336-a2356491-c124-459a-b762-6fa2e433577e.png)


