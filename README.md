# 🔐 Security Feature Mini Project (ASP.NET Core MVC)

This project is a **Security Feature Mini Project** developed using **ASP.NET Core MVC** and **Entity Framework Core**, focusing on implementing **core web security concepts manually**, without relying on ASP.NET Identity.

The system demonstrates authentication, authorization, auditing, and administrative security controls commonly found in real-world enterprise applications.

---

## 🚀 Features

###  Authentication & Authorization
- Manual username/password authentication
- Password hashing using BCrypt
- Session-based login system
- Role-based access control (Admin & User)

###  User Management (Admin Only)
- Create users with assigned roles
- Lock and unlock user accounts
- Prevent admins from deleting their own accounts
- Search and filter users by username

###  Security & Auditing
- Login attempt audit logs
- Tracks successful and failed login attempts
- Account lockout after multiple failed attempts
- Audit trail for security monitoring

### 🖥 Dashboards
- Admin Dashboard with security management tools
- User Dashboard with restricted access
- Dynamic navigation based on user role

---

##  Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap 5
- BCrypt.Net (Password Hashing)

---

##  Screenshots

> Screenshots of the application can be found in the `/screenshots` folder and include:
- Login Page
- Admin Dashboard
- User Management
- Add User
- Audit Logs
- User Dashboard

---

##  Purpose of the Project

This project was built to:
- Demonstrate **web application security fundamentals**
- Show understanding of **authentication and authorization**
- Implement **manual security mechanisms**
- Strengthen portfolio for **IT graduate and internship applications**

---

##  Getting Started

1. Clone the repository
2. Update the database connection string
3. Run migrations
4. Start the application
5. Login with the seeded admin account

**Default Admin Credentials**
username : admin
password: Admin@123
