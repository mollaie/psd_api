using Aspose.PSD;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using psd_merge.Dtos;
namespace psd_merge.Services;

public interface IMerge
{
    public Task<bool> ConvertToPsd(InputDto dto);
}

public class Merge:IMerge
{
    public async Task<bool> ConvertToPsd(InputDto dto)
    {

            PsdImage image = new PsdImage(dto.Width, dto.Height);
            Layer? layer = null;
            try
            {
                if (dto.Files != null)
                    foreach (var file in dto.Files)
                    {
                        if (file.FileInput != null)
                        {
                            layer = new Layer(file.FileInput);
                            layer.Name = file.Name;
                            layer.Top = 0;
                            layer.Left = 0;
                            
                            if (file.Masks != null)
                            {
                                foreach (var mask in file.Masks)
                                {
                                    LayerMaskData layerMask = new LayerMaskDataFull();
                                    layerMask.MaskRectangle = new Rectangle(0, 0, dto.Width, dto.Height);
                                    layerMask.ImageData =  mask;
                                    layer.AddLayerMask(layerMask);
                                }
                            }

                            image.AddLayer(layer);
                        }
                    }
                image.Save(dto.OutputPath + "CreatePSD.psd",true);
                
            }
            catch (Exception e)
            {
                layer?.Dispose();
                Console.WriteLine(e);
                return false;
            }

            return true;

      
    }

    // private async Task<byte[]> GetMaskByte(FileStream mask)
    // {
    //     using MemoryStream ms = new MemoryStream();
    //     await mask.CopyToAsync(ms);
    //     return ms.ToArray();
    // }
}

