cd BL
dotnet publish --configuration Release --output ..\build

cd ..\DataAccess
dotnet publish --configuration Release --output ..\build

cd ..\MongoDbDataAccess
dotnet publish --configuration Release --output ..\build

cd ..\UI
dotnet publish --configuration Release --output ..\build