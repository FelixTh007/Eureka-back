namespace Eureka.Models;

public class Actualite{
      public int Id { get; set; }
      public string Titre { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public string Contenu { get; set; } = string.Empty;
      public string Categorie { get; set; } = string.Empty;
      public DateTime DateCreation { get; set; } = DateTime.UtcNow;
      
      
      public ActualiteImage? Image { get; set; }
}

