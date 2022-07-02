# ReeResult
ReeResult Is the Newest Libraries For Implement Customize Result In Your Project With **.Net6**

I Try Too Update This Library And Add Multiple Attributes And i like Help Me To Upgrade Fast And Better.

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
Result.Fail<UserAddDto>("error");
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

Thanks For Using In This Library
