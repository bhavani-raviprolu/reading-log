# READING LOG

This is a sample application build using .NET Core. **Reading Log** is a log to maintain the books read by students on a daily basis. The two main roles of the 
application are
* Admin - To manage users and books
* Parent - Can add books read by their kids (Student)


## Technology Stack

This application has been built on the following tech stack

* .NET Core 3.1
* Entity Framework Core
* MS SQL Express
* AutoMapper
* Google OAuth

## Setup

### Prerequisite 

* Visual Studio 2019 Community Edition (Though this document focus on VS 2019 Community Edition - any edition of Visual Studio or Visual Studio Code can also be used)
* MS SQL Express 2019
* Git
* .NET 5.0
* Google Client ID and Client Secret for OAuth (https://developers.google.com/identity/gsi/web/guides/get-google-api-clientid)

### Steps
Here are the steps to run the application

* Clone this repository (```git clone https://github.com/bhavani-raviprolu/reading-log.git```)
* Setting of DB
  * Open MS SQL Server 2019 and create a new database **ReadingLogDb**
  * Execute the script located at **MySchool.ReadingLog.API/SqlScripts/V1__Initial.sql**
  * Run the following script (modify values to insert an admin record)

```
USE [ReadingLogDb]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[EmailAddress]
           ,[Role]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           (<FirstName, nvarchar(30),>
           ,<LastName, nvarchar(30),>
           ,<EmailAddress, nvarchar(30),>
           ,1
           ,'system'
           ,getdate()
           ,'system'
           ,getdate())
GO
```

* Running the solution
  * Open **MySchool.ReadingLog.API.sln** using Visual Studio 2019
  * Go to MySchool.ReadingLog.API.appsettings.json to update ClientId and ClientSecret
  * Go to Debug -> Start without Debugging
