cd HdProduction.Infrastructure.MySql
dotnet ef migrations %1 %2
cd ..

cd HdProduction.Infrastructure.PostgresSql
dotnet ef migrations %1 %2
cd ..

cd HdProduction.Infrastructure.SqlServer
dotnet ef migrations %1 %2
cd ..

cd HdProduction.Infrastructure.Sqlite
dotnet ef migrations %1 %2
cd ..