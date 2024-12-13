﻿using CarWashBackend.Models;
using CarWashBackend.Models.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWashBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CarwashContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(CarwashContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Usuario) || string.IsNullOrEmpty(loginDto.Contrasena))
            {
                return BadRequest("Usuario o contraseña no proporcionados.");
            }

            // Obtener el usuario junto con su rol y los permisos del rol
            var usuario = await _context.Usuarios
                .Include(u => u.role) // Incluir el rol
                .ThenInclude(r => r.permisos) // Incluir los permisos del rol
                .FirstOrDefaultAsync(u => u.usuario == loginDto.Usuario);

            if (usuario == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }

            if (usuario.contrasena != loginDto.Contrasena)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }

            // Crear los claims para el JWT
            var claims = new List<Claim>
            {
                new Claim("usuario", usuario.usuario),
                new Claim("usuarioId", usuario.id)
            };

            // Añadir el rol y los permisos como claims
            claims.Add(new Claim("Rol", usuario.role.nombre)); // Añadir el nombre del rol

            foreach (var permiso in usuario.role.permisos)
            {
                claims.Add(new Claim("Permiso", permiso.nombre)); // Añadir los permisos
            }

            // Generación del token JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Retornar el token JWT en la respuesta
            return Ok(new { Token = tokenString });
        }
    }
}
