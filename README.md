# TastyTreats Restaurant Management System

Welcome to the **TastyTreats Restaurant Management System**! This project is designed to help manage various aspects of the TastyTreats restaurant, including user roles, menus, orders, and more. The application is built using ASP.NET Core with Entity Framework Core for database management.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Database Structure](#database-structure)


## Project Overview

The **TastyTreats Restaurant Management System** is a web-based application designed to streamline the operations of the TastyTreats restaurant. The system supports multiple user roles, such as Admin, Guest, and Customers, with features that allow managing menus, handling orders, and monitoring user interactions. This system aims to improve efficiency and customer satisfaction.

## Features

- **User Management**: Manage users with different roles (Admin, Staff, Customers).
- **Menu Management**: Create, update, and manage food items and categories.
- **Order Management**: Handle customer orders, track order status, and manage order items.
- **Cart System**: Customers can add items to their cart and proceed to checkout.
- **Security**: Secure user authentication and role-based access control.
- **Responsive Design**: Optimized for use on both desktop and mobile devices.

## Technologies Used

- **Backend**: ASP.NET Core 8.0
- **Frontend**: Razor Pages / MVC
- **Database**: Microsoft SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Language**: C#
- **IDE**: Visual Studio 2022

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer edition is recommended)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (Community edition or higher)

### Database Structure
*The database structure includes the following main entities*:

- **User**: Stores information about users, including their role (Admin, Staff, Customer).
- **Category**: Represents different food categories (e.g., Appetizers, Main Course).
- **Item**: Represents individual menu items, linked to a category.
- **Cart**: Represents a user's shopping cart.
- **CartItems**: Represents individual items within a user's cart.
- **Order**: Stores information about an order placed by a user.
- **OrderItems**: Stores details of items within an order.
