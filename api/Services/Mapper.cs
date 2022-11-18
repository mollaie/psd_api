using System.Reflection.Metadata.Ecma335;
using psd_api.Dtos;
using psd_merge.Dtos;
namespace psd_api.Services
{
    public class Mapper
    {
        private readonly InputMetaDto _metaDto;
        public Mapper(InputMetaDto metaDto)
        {
            _metaDto = metaDto;
        }

        public async Task<InputDto> Map()
        {

                var dto = new InputDto
                {
                    Width = _metaDto.Width,
                    Height = _metaDto.Height,
                    OutputPath = _metaDto.OutputPath,
                    Files = _metaDto.Files != null ? await  ReadLayers(_metaDto.Files): null
                    
                };
                return dto;
            
        }

        private async Task<List<InputFileDto>> ReadLayers(List<InputFileMetaDto> files)
        {
            var result = new List<InputFileDto>();

            foreach (var file in files)
            {
                var layer = new InputFileDto()
                {
                    Name = file.Name,
                    FileInput = await FileReader.ReadFileStream(file.Path),
                    Masks = file.Masks != null ?  await ReadMasks(file.Masks) : null,
                };
                
                result.Add(layer);
            }

            return result;
        }
        private async Task<List<byte[]>> ReadMasks(List<string> masksPath)
        {
            var result = new List<byte[]>();

            foreach (var path in masksPath)
            {
                var maskByte = await FileReader.ReadFileByte(path);

                result.Add(maskByte);
            }

            return result;
        }
    }
}