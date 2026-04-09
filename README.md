Student Management Service 
A robust C# Windows Forms application designed to manage student records in a SQL Server database.
This project demonstrates the implementation of a 2-tier architecture, separating the User Interface logic from the Data Access logic using a dedicated Datahandler class.
Key Features
1. View All Records: Fetches and displays the entire Student table in a DataGridView
2.  Search: Efficiently retrieves a specific student record using their unique numeric StudentID.
3.  Smart Update: A "Delta-Update" feature that allows users to change specific fields (like Year or Grade) while automatically preserving existing data for empty fields.
4.  Safe Deletion: Implements numeric parsing and confirmation prompts to prevent accidental data loss.

Technical StackLanguage: 
C# (.NET Framework).Database: Microsoft SQL Server (Transact-SQL).
Architecture: Object-Oriented Programming (OOP) with a "Data Access Object" pattern.
Database SchemaThe system interacts with a table named Student within the BCDatabase1 catalog. 
