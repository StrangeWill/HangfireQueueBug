# Readme

Reproduction project for Hangfire Bug #2384

Pull project, run `docker compose up -d`, `dotnet run` and go check out hangfire, it'll have two jobs, `DoWork` should be in the priority queue, it is not, `DoWorkWithAttribute` should be in the default queue, it is not.