
# Trips Log App

A multi-step ASP.NET Core MVC web application for tracking your travel adventures. Add trips, optional accommodation details, and things to do — all with a clean and responsive Bootstrap interface.

## Features

- View and manage a list of trips.
- Add new trips with a guided three-step form:
  1. **Destination & Dates** – Enter required trip details and optional accommodation.
  2. **Accommodation Details** – If accommodation is provided, add phone/email (optional).
  3. **Things To Do** – Add up to three optional activities or notes for your trip.
- Server-side and client-side validation for required fields.
- Data stored in SQL Server using Entity Framework Core.
- Clean, mobile-friendly Bootstrap 5 UI.

## Getting Started

1. **Clone the Repository**  
   `git clone https://github.com/kishankumar2607/Trips-Log-App.git`  
   `cd Trips-Log-App`

2. **Configure the Database**  
   Update `appsettings.json` with your SQL Server connection string.  
   Example for LocalDB:  
   ```json
   "ConnectionStrings": {
     "DefaultConnection": `Server=(localdb)\mssqllocaldb;Database=TripLogAppDatabase;Trusted_Connection=True;MultipleActiveResultSets=true`
   }
   ```

3. **Apply Entity Framework Migrations**  
   `Add-Migration Message & Update-Database`

4. **Run the Application**    
   Open your browser at the URL shown in the console (e.g., https://localhost:5001).

## Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- Bootstrap 5  

## Project Structure

```
TripsLogApp/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── appsettings.json
└── ...
```

