namespace psd_api.Dtos
{
    public class InputMetaDto
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public string OutputPath { get; set; } = "";
        public List<InputFileMetaDto>? Files { get; set; } 
    }

    public class InputFileMetaDto
    {
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public List<string>? Masks { get; set; }
    }
}