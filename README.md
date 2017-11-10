# Example of REST API Using MongoDB, .NET Core 2.0 and JWT Authentication

### Technologies:

- .NET Core 2.0;
- MongoDB;
- JWT Authentication.

### Running this solution:

First download or clone the project in a local directory:

Then you must create a local or cloud MongoDB instance. In this instance, it's necessary the creation of a **ProductDb**
database and two collections, **Product** and **User**. You can use this commands bellow so you can incluse the user:

```javascript
db.User.insert({"Name": "Joao Teste", "Login": "joao", "Password": "1234"})
```

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/mongodb.png "MongoDB Configuration")

It's necessary to configure **appsettings.Development.json** with your instance of MongoDB:

```javascript
"ConnectionString": "mongodb://localhost:27017",
```

Next, you can open you project in Visual Studio or Visual Studio Code. You can type these two commands (to restore nuget package components and run the API):

```mongodb
dotnet restore
```

```javascript
dotnet run
```

Now, if everything is all right, your API will be working. You must run the command bellow so you can create as authentication token:

```javascript
http://localhost:5000/api/Auth
```

Remember: it's necessary define **user** and **password** in payload:

```javascript
{
	"Login": "joao",
	"Password": "1234"
}
```

The result is like this:

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanok.png "Postman Token")

You must use this token so you can use GET, POST, PUT, DELETE verbs. For every of these REST verbs, you must put the generated token in **Authorization Header**, with the word **Bearer** like this:

```javascript
Header: Authorization
Value: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2FvIiwianRpIjoiMTFlYWFlODMtZTA4NS00NjA1LTlhNGQtZWI5ZjEzZjdhMDk5IiwiTWVtYmVyc2hpcElkIjoiMTExIiwiZXhwIjoxNTEwMTk0NjQ5LCJpc3MiOiJpc3N1ZXJUZXN0IiwiYXVkIjoiYmVhcmVyVGVzdCJ9.mN3uPfdK19xeMbOoeFfhtuFSpXrGUZ7eR6muM7Nz_fo
```

To use POST, so you can insert some Products, use this URL bellow:

```javascript
http://localhost:5000/api/Products
```

With this payloads:

```javascript
{
    "Code": "COD1",
    "Name": "Produto 1",
    "Active": true,
    "ImageUrl": "http://download.gamezone.com/uploads/image/data/1102202/League_of_Legends_Rune_Wars_Renekton.jpg",
	"Description": "Descrição do Produto 1"
}
```
```javascript
{
    "Code": "COD2",
    "Name": "Produto 2",
    "Active": true,
    "ImageUrl": "http://images.nintendolife.com/news/2014/08/weirdness_yoshis_real_name_is_both_silly_and_scientific/attachment/0/900x.jpg",
	"Description": "Descrição do Produto 2"	
}
```
```javascript
{
    "Code": "COD3",
    "Name": "Produto 3",
    "Active": true,
    "ImageUrl": "http://da-v4-mbl.digitalbrandsinc.netdna-cdn.com/wp-content/uploads/2012/08/snails-612x320.jpg",
	"Description": "Descrição do Produto 3"	
}
```

Now you can list the products inserted. Use this URL:

```javascript
https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanok.png
```

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanok.png "Postman Product List")


Remember, we are using a JWT Token Authentication. The definition of the expiration is 1 minute. Because of this, you maybe get **Error 401 - Unauthorized**. It's perfectly normal: 


![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanUnauthorized.png "Postman Product List")

You just generate another token and put it on Header Authorization.


