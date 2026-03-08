using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc; // Nécessaire pour [FromForm]
using Microsoft.AspNetCore.Http; // Nécessaire pour IFormFile
using Eureka.Data;
using Eureka.Models;
using Eureka.Api.DTOs.Actualites;

namespace Eureka.Api.Endpoints;

public static class ActualiteEndpoints
{
    public static void MapActualiteEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/actualites").WithTags("Actualités");

        // 1. GET corrigé : 6 paramètres pour correspondre au record
        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Actualites
                .OrderByDescending(a => a.DateCreation)
                .Select(a => new ActualiteResponse(
                    a.Id, 
                    a.Titre, 
                    a.Description, 
                    a.Contenu, 
                    a.Categorie, 
                    a.DateCreation)) 
                .ToListAsync();
        });

        // 2. GET Image : fonctionne si ta classe ActualiteImage a bien 'Data' et 'ContentType'
        group.MapGet("/{id}/image", async (int id, AppDbContext db) =>
        {
            var image = await db.ActualiteImages
                .Where(img => img.ActualiteId == id)
                .Select(img => new { img.Data, img.ContentType })
                .FirstOrDefaultAsync();

            return image is not null 
                ? Results.File(image.Data, image.ContentType) 
                : Results.NotFound();
        });

        // 3. POST : Utilisation de [FromForm]
        group.MapPost("/", async ([FromForm] CreateActualiteRequest dto, AppDbContext db) =>
        {
            var actualite = new Actualite
            {
                Titre = dto.Titre,
                Categorie = dto.Categorie,
                Description = dto.Description,
                Contenu = dto.Contenu,
                DateCreation = DateTime.UtcNow // Bonne pratique d'initialiser la date
            };

            if (dto.Image is { Length: > 0 })
            {
                using var ms = new MemoryStream();
                await dto.Image.CopyToAsync(ms);
                actualite.Image = new ActualiteImage 
                { 
                    Data = ms.ToArray(), 
                    ContentType = dto.Image.ContentType 
                };
            }

            db.Actualites.Add(actualite);
            await db.SaveChangesAsync();

            return Results.Created($"/api/actualites/{actualite.Id}", actualite.Id);
        }).DisableAntiforgery();

        // 4. Dernières par catégorie
        group.MapGet("/dernieres-par-categorie", async (AppDbContext db) =>
        {
            var resultats = await db.Actualites
                  .GroupBy(a => a.Categorie)
                  .Select(groupe => groupe
                        .OrderByDescending(a => a.DateCreation) 
                        .FirstOrDefault() 
                  )
                  .ToListAsync();

            return Results.Ok(resultats);
        })
        .WithSummary("Récupère le dernier article publié pour chaque catégorie existante.");
    }
}