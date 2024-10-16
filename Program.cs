
using ApiGap.Repository;
using Microsoft.EntityFrameworkCore;
using ApiGap.Data;
using ApiGap.Repository.Interfaces;
using ApiGap.Services;
using ApiGap.Services.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace ApiGap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var connectionString = builder.Configuration.GetConnectionString("Database");

            builder.Services.AddEntityFrameworkMySql().AddDbContext<ApiGapDBContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            //jwt
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // se um dia eu colocar isso em prod, mudar para true
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true, // Verifica se o token ainda é válido
                    ClockSkew = TimeSpan.Zero // Evita tolerância padrão de 5 minutos
                };
            });

            // aqui são as politicas (policy) de autorização
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy =>
                    policy.RequireRole("COLLABORATOR")); // Permite apenas administradores - lembrar de mudar para "ADMINISTRATOR"

                options.AddPolicy("RequireManagerRole", policy =>
                    policy.RequireRole("Gerente")); // Permite apenas gerentes

                options.AddPolicy("RequireCollaboratorRole", policy =>
                    policy.RequireRole("Colaborador")); // Permite apenas colaboradores

                options.AddPolicy("RequireStandardUserRole", policy =>
                    policy.RequireRole("Usuário Padrão")); // Permite apenas usuários padrão
            });



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // aqui é o Middleware  da autenticação

            app.UseAuthorization(); // aqui é o Middleware da autorização


            app.MapControllers();

            app.Run();
        }
    }
}
