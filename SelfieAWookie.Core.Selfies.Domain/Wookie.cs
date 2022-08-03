using System.Text.Json.Serialization;

namespace SelfieAWookie.Core.Selfies.Domain;

public class Wookie
{
    public int Id { get; set; }
    
    public List<Selfie> Selfies { get; set; }
}