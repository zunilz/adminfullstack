# adminfullstack
Basic Admin View in Full Stack<br />

Sample app to provide better view of products based on user keyword tags.<br />
Manage keywords tagged to products. <br /><br />


Architecture :<br /><br />

Repository pattern is used in API project for data store operations.<br />
This layer is injected into Web API layer using DI.<br /><br />

Code first approach is used create application schema with EF Core.<br />

Frameworks & 3rd party tools/packages used :<br /><br />

.Net Core 3.1<br />
.Net EF Core 5<br />
Automapper<br />
Automapper DI<br />
Angular 12<br />
Angular Material 12<br /><br />

Assumptions :<br />

Product details are available in Product table<br />
Accessories of products are listed in ProductAccessories mapping table if any separate listing of Accessories are required in future.<br />
Initial deployment would be in Azure cloud. In case of cross platform migration, API app could be containerised and moved to respective cloud.<br />
<br />
Imp:<br />

Secure the Apps<br />
API Versioning<br />
Repository Service pattern<br />
Exception handling<br />
Lazy loading<br />
Interactive UI<br />