# ChallengeApp.Home

Módulo Home publicado como pacote `ChallengeApp.Home`.

## Desenvolvimento local no app host

```xml
<ProjectReference Include="../challenge-app-home/Home/Home.csproj" />
```

Ou execute `dotnet build -p:UseLocalModules=true`.

O CI valida build, testes, cobertura e o Example MAUI. O CD publica o pacote no GitHub Packages.
