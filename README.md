# Inlogic SignUpStream - CT

SignUp and Subscribe to particular plan with Promo code discounts


## Prerequisites

Before running the project, make sure you have the following installed on your machine:

Angular: 18.2.11

.Net core: 8.0

SQL server: 2022

Node js: 22.11.0

## Setup Instructions

### 1. Clone the repository

Open your terminal or command prompt and execute the following command to clone the repository:
git clone https://github.com/karan-ct/SignUpStream

### 2. Open Visual Studio

Navigate to the cloned project directory.

Locate the appsettings.json file and change the connection string to match your SQL Server configuration.

Open Package Manager Console and select SignUpStream.Data as Default Project

Run the following command in the Package Manager Console to create tables and seed default data in the database:

-> Update-Database

## Created Tables

### These are Identity tables created by Identity itself.

> > AspNetRoleClaims

> > AspNetRoles

> > AspNetUserClaims

> > AspNetUserLogins

> > AspNetUserRoles

> > AspNetUsers

> > AspNetUserTokens

### Tables created by us.

> > PricePlan

> > Subscription

> > PromoCode

## Seeded Data

The following data will be seeded into the database:

### PricePlan Table

Price: 200, Discount: 0, MembershipPlanType: 1

Price: 200, Discount: 20, MembershipPlanType: 2

### Coupons Table

Code: "BRANCH-10", Discount: 10

Code: "BRANCH-15", Discount: 15

Code: "BRANCH-20", Discount: 20

### 3 Run your Backend

Use project SignUpStream.API for launch the project

### 4 Open Visual Studio Code

Launch Visual Studio Code.

Open the angular folder within your cloned repository.

Open the integrated terminal in Visual Studio Code.

Run the following command to install all dependencies:

-> npm install

### 5 Run your Frontend

Run following command:

-> ng serve / npm start