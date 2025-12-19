namespace Dto.Contact;

public class GetContactDto
{
    public int ContactId { get; set; }
    public string ContactMap { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
}