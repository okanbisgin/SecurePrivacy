# SecurePrivacy 🚀

SecurePrivacy is a **full-stack user management system** built with **.NET 8 (C#) & Angular 17**, using **MongoDB** as the database. The project ensures GDPR compliance by managing user data securely.

---

## **📌 Features**
👉 User management (List, Add, Delete)  
👉 Secure API endpoints (CORS enabled)  
👉 MongoDB integration  
👉 Swagger API documentation  
👉 GDPR compliance  

---

## **📌 Project Setup**

### **1️⃣ Backend (.NET 8) Setup**
> 📂 Navigate to the backend folder and install dependencies.

```sh
cd SecurePrivacyBackend
dotnet restore
```
> 🚀 Start the backend server:

```sh
dotnet run
```
> 🛠 Test API with Swagger:
👉 **Open:** `http://localhost:5294/swagger/index.html`

---

### **2️⃣ Frontend (Angular 17) Setup**
> 📂 Navigate to the frontend folder and install dependencies.

```sh
cd angular-frontend
npm install
```
> 🚀 Start the Angular app:

```sh
ng serve
```
> 🔦 Open in browser:
👉 **`http://localhost:4200`**

---

## **📌 API Endpoints**
| Method | Endpoint | Description |
|--------|---------|-------------|
| `GET`  | `/users` | Get user list |
| `POST` | `/users` | Create a new user |

---

## **📌 CORS Configuration**
If the frontend cannot access the API due to CORS issues, update **`Program.cs`**:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});
app.UseCors("AllowAll");
```
Restart backend:
```sh
dotnet run
```

---

## **📌 Troubleshooting**
💡 **If something doesn’t work, try the following:**  
🔹 **Clear frontend cache:** `CTRL + SHIFT + R`  
🔹 **Check console errors:** Open Developer Tools (`F12` → Console)  
🔹 **Restart backend:** `dotnet run`  
🔹 **Ensure MongoDB is running:** `mongod --version`  

---

## **📌 License**
This project is licensed under the **MIT License**.  

---
