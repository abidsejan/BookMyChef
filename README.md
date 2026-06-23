## 🍽️ BookMyChef

**BookMyChef** is a C# Windows Forms (.NET Framework) desktop application designed to connect clients with chefs, caterers, and event agencies for booking food services efficiently.

The system supports multiple user roles with dedicated dashboards and functionality, making event food management simple and organized.

## 🚀 Features

### 👤 User Roles
- **Admin**
- **Client**
- **Chef**
- **Caterer**
- **Event Agency**

### 🔑 Core Functionalities
- User authentication (Sign In / Sign Up)
- Role-based dashboards
- Profile creation & update
- Chef, caterer & event agency service listings
- Event package browsing
- Booking management
- Payment processing
- Booking history tracking
- Admin analytics & management

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET Framework
- **UI:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server
- **IDE:** Visual Studio
- **Version Control:** Git & GitHub

## 📁 Project Structure

```

BookMyChef/
│
├── BookMyChef.sln
├── BookMyChef/
│   ├── Forms/
│   ├── Properties/
│   ├── Program.cs
│   └── App.config
│
├── README.md
└── .gitignore

````

## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/abidsejan/BookMyChef.git
````

### 2️⃣ Open in Visual Studio

* Open `BookMyChef.sln`
* Ensure **.NET Framework** is installed

### 3️⃣ Database Setup

* Create a SQL Server database named:

  ```
  BookMyChef
  ```
* Update the connection string in `App.config`:

  ```xml
  data source=YOUR_SERVER_NAME;
  database=BookMyChef;
  integrated security=SSPI;
  ```

### 4️⃣ Run the Project

* Press **F5** or click **Start**

## 📌 Future Enhancements

* Email notifications
* Online payment gateway integration
* Password encryption & security improvements
* Reporting & analytics dashboard
* UI/UX improvements

## 👥 Contributors

* **Mohammad Abid Hasan - UI Design, Sign in, Sign up, Client Forms**
* **Niyamul Islam Nishad - Chef, Caterer, Event Agency Forms**
* **Safayet Gazi Sopan - Admin Forms**

## 📜 License

This project is developed for **educational purposes**.
You may modify and extend it as needed.

## ⭐ Support

If you find this project helpful, feel free to ⭐ the repository!
