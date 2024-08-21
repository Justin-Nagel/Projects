Programming Project Year 2
This project was developed by a group of four students. We were required to create a Windows-Based Application that captures and stores student information into a database.

Instructions
The goal of this project is to develop an application that manages student information for the campus. The final product must be a fully functioning Windows-based application capable of capturing student details and storing them in an SQL relational database. The project must utilize a Multi-Layered Architecture, consisting of the following three tiers:

Presentation Layer: The Windows Forms GUI.
Business Logic Layer: Handles CRUD operations (Create, Read, Update, Delete) and File I/O.
Data Access Layer: Implements ADO.Net and manages the SQL Database.
Client Requirements
Login Form:

A Data Capturer should be presented with a login form requiring a username and password.
Store sample usernames and passwords in a text file (format of your choice).
Authenticate the login when a Data Capturer attempts to sign in.
If a Data Capturer does not have a username and password, they should be able to register as a new user. Store their login details in the text file.
Ensure all necessary validations are performed for the login form.
Main Application GUI:

Once logged in, the Data Capturer should be presented with a custom-designed Windows GUI to perform all CRUD operations.
Utilize ADO.Net to manage database interactions.
All data must be stored in an SQL Server database.
Student Information Management:

Create: Capture and store the following student details in the database:
Student Number
Student Name and Surname
Student Image
Date Of Birth
Gender
Phone Number
Address
Module Codes
Read: Display student information using a ListView or DataGridView.
Update: Allow updating of student information.
Delete: Enable deletion of student information.
Search: Implement a search functionality to find a student's information using their Student ID.
Module Information Management:

Create: Capture and store the following module details in the database:
Module Code
Module Name
Module Description
Links to relevant online resources (e.g., YouTube videos related to the module)
Read/Update/Delete: Implement CRUD operations for module information.
Search: Implement a search functionality for modules.
