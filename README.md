# Recruitment Base
Recruitment Base is a basic recruitment website for our team's finishing exercises
Technology Stack
1. ASP.NET Core 3.1
2. Identity Server 4
3. SQL Server

# How to run this Project
1. Clone this source code from Repository
2. Build solution to restore all Nuget Packages
3. Set startup project is Recruitment.Api
4. Set startup project is Recruitment.WebApp
5. Edit appsettings.json in Recruitment.Api and Recruitment.WebApp to set connection string to your database
6. Change current directory to Recruitment.Data and run `dotnet ef database update`` to generate database
7. Set startup project to multiple projects include: Recruitment.Api and Recruitment.WebApp
8. Run the project

# Login
I created some model account with roles: admin, recruitment below:

Username				| Password | Role(s)
--------				| -------- | --------
chinhtc@gmail.com		  abc123	 Admin
duynk006@gmail.com 		  abc123	 Admin
hiepdt004@gmail.com		  abc123	 Admin
dungpm003@gmail.com		  abc123	 Admin
linhpp002@gmail.com		  abc123	 Admin
QUANGHM004@gmail.com	  abc123	 Admin
tienlv005@gmail.com		  abc123	 Admin
anhnd026@gmail.com		  abc123	 Admin
anhntl028@gmail.com		  abc123	 Admin
anhntl029@gmail.com		  abc123	 Admin