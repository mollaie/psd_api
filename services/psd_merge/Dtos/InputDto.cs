namespace psd_merge.Dtos;

public class InputDto
{
    public int Width { get; set; } 
    public int Height { get; set; }
    public List<InputFileDto>? Files { get; set; }
    public string OutputPath { get; set; } = "";

}

public sealed class InputFileDto
{

    public FileStream? FileInput { get; set; }
    public string Name { get; set; } = "";
        
    public List<byte[]>? Masks { get; set; }
}

public enum FileType
{
    Layer = 1,
    Mask = 2
}