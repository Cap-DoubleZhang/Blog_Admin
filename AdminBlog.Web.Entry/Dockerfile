#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdminBlog.Web.Entry/AdminBlog.Web.Entry.csproj", "AdminBlog.Web.Entry/"]
COPY ["AdminBlog.Web.Core/AdminBlog.Web.Core.csproj", "AdminBlog.Web.Core/"]
COPY ["AdminBlog.Application/AdminBlog.Application.csproj", "AdminBlog.Application/"]
COPY ["AdminBlog.Core.Enum/AdminBlog.Core.Enum.csproj", "AdminBlog.Core.Enum/"]
COPY ["AdminBlog.Common/AdminBlog.Common.csproj", "AdminBlog.Common/"]
COPY ["AdminBlog.Dtos/AdminBlog.Dtos.csproj", "AdminBlog.Dtos/"]
COPY ["AdminBlog.User/AdminBlog.User.csproj", "AdminBlog.User/"]
COPY ["AdminBlog.Core/AdminBlog.Core.csproj", "AdminBlog.Core/"]
COPY ["AdminBlog.MapperConfig/AdminBlog.MapperConfig.csproj", "AdminBlog.MapperConfig/"]
COPY ["AdminBlog.Database.Migrations/AdminBlog.Database.Migrations.csproj", "AdminBlog.Database.Migrations/"]
COPY ["AdminBlog.EntityFramework.Core/AdminBlog.EntityFramework.Core.csproj", "AdminBlog.EntityFramework.Core/"]
RUN dotnet restore "AdminBlog.Web.Entry/AdminBlog.Web.Entry.csproj"
COPY . .
WORKDIR "/src/AdminBlog.Web.Entry"
RUN dotnet build "AdminBlog.Web.Entry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminBlog.Web.Entry.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminBlog.Web.Entry.dll"]