using Students;

var builder = WebApplication.CreateBuilder(args);

var catalogAssembly = typeof(StudentsModule).Assembly;

var app = builder.Build();

app.Run();