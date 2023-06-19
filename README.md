# Ma.ShopsRUs
This project includes RESTful API services for customers, invoices, and discounts. 
The project is built with .NET Core 6 and uses SqlLite as the database. 
It can work with different databases according to the requirements.



# Requirements
1. <code>NetCore 6.0</code> Download: https://dotnet.microsoft.com/download
2. <code>Visual Studio 2022</code> Download: https://visualstudio.microsoft.com/tr/vs/

# Quick Start

<pre>
gh repo clone bermalmizgin/Ma.ShopsRUs 
dotnet run
dotnet build
</pre> 
  

# Visual Studio 2012
- Open the <code>Ma.ShopsRUs.sln</code> file with Visual Studio 2012
> Wait for NuGet packages to be restored.
You can run it with the <code>dotnet run</code> command.
You can build it with the <code>dotnet build</code> command
  

# Visual Studio Code
- After cloning 
  >run dontnet restore
  -  to restore all packages and dependencies
  >dotnet run
 
# Migration
<pre>
Visual Studio 2012 Package Manager Console Update-Database
or
dotnet ef database update
</pre>

# Using SQL Server
Change the <code>Startup.cs</code> file as follows:

<pre>
//services.ConfigureSqlLite(Configuration);
services.ConfigureSqlServer(Configuration);
</pre>
 
# Api
- You can access the API documentation at the following address: https://localhost:5001/swagger/index.html.


# İndirim oranlarının uygulanması
The discounts defined with <code>[POST] /api/discounts</code> are applied during the invoice creation process with the <code>[POST] /api/invoices</code> service.

<pre>
Discounts:
- If the user is an employee of the store, they receive a 30% discount.
- If the user is an affiliate of the store, they receive a 10% discount.
- If the user has been a customer for more than 2 years, they receive a 5% discount.
- A $5 discount is applied for every $100 in the invoice (e.g., you get a $45 discount for $990).
- Percentage-based discounts are not applicable for grocery shopping.
- A user can only receive one percentage-based discount on an invoice.
</pre>

# Unit Test
The tests are located in the <code>Ma.ShopsRUsTests</code> project.
You can run the tests with the <code>dotnet test</code> command.

Please let me know if you need any further assistance!