##Programming Year 2

This is a project worked on in a group of 4 students, we were required to create a _Windows Based Application_ that captures and stored student information into a database.

_Instructions_


Create an application which will be responsible for managing student information for the campus. The end product must be a fully functioning Windows Based application which will capture details of students and details of the modules that the students do and store in an SQL Relational Database. In your project, you need to utilize the Multi Layered Architecture. Your application must comprise of the following 3-tiers:
a)Presentation Layer [Your Windows Forms GUI]
b)Business Logic Layer [CRUD functions that will be necessary to implement a persistent storage application: Create, Read, Update and Delete, File I/O]
c)Data Access Layer [ADO.Net and SQL Database]

#Requirements from client
1)A Data Capturer should be presented with a Login Form which will require their Username and Password. Store sample Usernames and Passwords on a text file [in any format of your choosing]. The login should be verified and authenticated when a Data Capturer attempts to login. If a Data Capturer does not have a Username and Password, they should be able to register as a new user and their login details stored on the text file. Make sure all necessary validations are done for the Login Form.
2)Once the Data Capturer logs on the application, they should be presented with a Windows GUI of your design in order to perform all CRUD operations. Utilize ADO.Net to achieve this. All information MUST be stored on a database using SQL Server.
3)When capturing student information, on Create, the application should capture the following student information to the database:
▪ Student Number
▪ Student Name and Surname
▪ Student Image
▪ Date Of Birth
▪ Gender
▪ Phone
▪ Address
▪ Module Codes
4) On Read, make sure student information can be displayed in a ListView or DataGridView. On Update, it must be possible to change student’s information. On Delete, it must be possible to delete student’s information. The application must also have a Search functionality to search a particular student’s information using the Student’s ID.
5) When capturing module information, on Create, the application should capture the following module information to the database:
▪ Module Code
▪M odule Name
▪ Module Description
▪ Links to particular online resources (use YouTube videos that relate to each module)
6)The rest of the other CRUD operations must apply for displaying, updating, deleting and searching for a module to and from the database.
