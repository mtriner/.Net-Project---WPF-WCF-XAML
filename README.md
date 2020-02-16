# AegisInterviewProject

## Database Configuration
- Go to Server\FinalAegisWCFServiceApp\Service1.svc.cs 
- Line 125 set MSSQL ConnectionString
- Run this SQL
```
CREATE DATABASE Aegis;
Go
Use Aegis;
Go
CREATE TABLE Customer (
    ID uniqueidentifier,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
	  State varchar(2),
	  ZipCode varchar(10),
	  PRIMARY KEY (ID)
);
```
## Server Setup
- Open Server\FinalAegisWCFServiceApp.sln in Visual Studio
- Run the solution

## Client Setup
- After server setup is completed
- Open Client\AegisWPF.sln in Visual Studio
- Run the solution

## User Stories
- User Stories are attached as a .docx
