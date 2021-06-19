# adminfullstack
Basic Admin View in Full Stack

Sample app to provide better view of products based on user keyword tags.
Manage keywords tagged to products. 


Architecture :

Repository pattern is used in API project for data store operations.
This layer is injected into Web API layer using DI.

Code first approach is used create application schema with EF Core.

Frameworks & 3rd party tools/packages used :

.Net Core 3.1
.Net EF Core 5
Automapper
Automapper DI
Angular 12
Angular Material 12

Assumptions :

Product details are available in Product table
Accessories of products are listed in ProductAccessories mapping table if any separate listing of Accessories are required in future.
Initial deployment would be in Azure cloud. In case of cross platform migration, API app could be containerised and moved to respective cloud.

Imp:

API Versioning
Repository Service pattern
Exception handling