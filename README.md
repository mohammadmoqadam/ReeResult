# ReeResult


ReeResult Is the Newest Libraries For Implement Customize Result In Your Project With **.Net6**

I Try Too Update This Library And Add Multiple Attributes And i like Help Me To Upgrade Fast And Better.

[You Can See And Get from Nuget](https://www.nuget.org/packages/ReeResult "You Can See And Get from Nuget")

`Install-Package ReeResult`




I Write A few features In Librariy




```csharp
Result.Ok();
```

 ```csharp
Result.Fail("error occured");
```



```csharp
Result.Ok<UserAddDto>(new UserAddDto() { UserName = "john" });
```

```csharp
Result.Fail<UserAddDto>("error occured");
```


```csharp
var result = new Result();
result.AddReason("reason");
result.AddError("error");
result.AddError("error2");
```

```csharp
var result = new Result()
.AddReason("reason")
.AddError("error")
.AddError("error2");
```

```csharp
var result = new Result<UserAddDto>();
result.AddValue(new UserAddDto() { UserName = "john" });
```

#Result.HttpResponse

in package return standard result with custome http status code

```csharp
var result = new Result<UserAddDto>();
result.AddError("Error Occured", System.Net.HttpStatusCode.Unauthorized);
return result;
```
for use this attribute just add  **[ApiResult]** attribute in top of controller.

 or add in startup with below sample
 
 ```csharp
services.AddControllers(options =>
 {
   options.Filters.Add(typeof(ReeResult.HttpResponse.ApiResultAttribute));
});
```


Thanks For Using In This Library
