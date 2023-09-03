# IglesiaALDia

This is a finance management web application intended for Churchs and the way they work in Cuba.

## Features

- User management.
- Keep a list of people in the church and it's missions.
- Keep track of the predication themes in the Dominical School.
- Manage the missions of the church.
- Manage the finance accounts, incomes and expenses.
- Manage a storage of products intended to help people, keep tracks of product purchases and deliveries to the final purpose.
- Output several reports to facilitate the analysis of the information. (In migration process)

## Technical requirements

- .Net Framework 4.5
- Microsoft SQL server

## Install

- Create a database called "finanzas" in your SQL server.
- Run in the database the script [DatabaseStructureCreation.sql](data/DatabaseStructureCreation.sql) to create the database tables.
- Run in the database the script [BasicData.sql](data/BasicData.sql) to add initial data to the database.
- The administrator credentials are: USER: `admin`, PASSWORD: `admin123*`
