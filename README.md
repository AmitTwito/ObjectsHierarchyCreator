# ObjectsHierarchyCreator


A simple C# .NET 5 WebApi simple backend service that gets a list of objects with id, name and parent and returns back the object heirarchal structure as a list of ancestors.



## How to run:
- Clone the repo
- Open cmd and ```cd``` into the repo'ss folder
- In the cmd, run ```dotnet build``` and wait for it to finish
- Then, run '''cd ObjectsHierarchyCreator.PL'''
- run ```dotnet run```
- The port will be displayed in the cmd logs. On default it is 5000
- Open the browser and go to ```http://localhost:<port>/swagger```

## JWT secret key
For the authentication functionality, you can set you own secret key - open the ```appsettings.json``` in ```ObjectsHierarchyCreator.PL``` and set the JWTKey as needed.

## Auth
In the swagger, first use the ```/api/auth/token``` method. The body is an object with 'username' and 'password'. For this simple purpose you can use 'admin' and '123'.
You can add more ```User``` objets in the file ```AccessControlRepository.cs``` file under ```ObjectsHierarchyCreator.DAL```.
Then, take the token from the response and click on ```Authorize``` button in the top right corner in swagger, and enter 'Bearer <TOKEN>' in the value field.
