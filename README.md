# AdventOfCode2022

dotnet new sln
dotnet new console -n AdventOfCode
dotnet sln add AdventOfCode
dotnet new nunit -n AdventOfCode.Test
dotnet sln add AdventOfCode.Test
dotnet add ./AdventOfCode.Test/AdventOfCode.Test.csproj reference ./AdventOfCode/AdventOfCode.csproj