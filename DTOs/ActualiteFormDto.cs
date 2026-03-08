namespace Eureka.Api.DTOs.Actualites;

public record CreateActualiteRequest(string Titre, string Description, string Contenu, string Categorie, IFormFile? Image);
public record ActualiteResponse(int Id, string Titre, string Description, string Contenu, string Categorie, DateTime DateCreation);