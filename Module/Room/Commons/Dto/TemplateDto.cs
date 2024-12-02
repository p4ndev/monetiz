namespace Monetizacao.Modules.Room.Dtos;

public struct TemplateDto {
    public long         uid;
    public long         gid;
    public string       stamp;

    public string       action;
    public string       image;

    public DateTime     starts;
    public DateTime     ends;
}