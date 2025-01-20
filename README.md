# RepositoryPattern

# Let’s Keep Repositories Away for a Moment.
let’s talk a bit about the traditional way to get data from this layer. Traditionally, you would directly call the dbContext object to read and write data. This is fine. But is it really ideal for the long run? When you use the dbContext directly, what you are doing is that, the Entity Framework Core is being tightly coupled within your application. So, Tommorow when there is something newer and better than EFCore, you would find it really annoying to implement the new tech and make the corresponding changes. Right?

One more disadvantage of directly using the dbContext directly is that you would be exposing the DbContext, which is totally insecure.

This is the reason to use Repository Pattern in ASP.NET Core Applications.

# Practical Use-Case of Repositories
While Performing CRUD Operations with Entity Framework Core, you might have noticed that the basic essence of the code keeps the same. Yet we write it multiple times over and over. The CRUD Operations include Create, Read, Update, and Delete. So, why not have a class / interface setup where you can generalize each of these op
