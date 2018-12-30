
rmdir /S /Q Data\Migrations

dotnet ef migrations add Devices -c DeviceDataContext -o Data/Migrations/Devices
dotnet ef migrations script -c DeviceDataContext -o Data/Migrations/Devices.sql
dotnet ef database update -c DeviceDataContext


dotnet run /seed
pause
