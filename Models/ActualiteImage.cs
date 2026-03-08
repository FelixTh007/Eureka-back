namespace Eureka.Models;

public class ActualiteImage
{
    public int Id { get; set; }
    public byte[] Data { get; set; } 
    public string ContentType { get; set; } = string.Empty;
    public int ActualiteId { get; set; }
}

