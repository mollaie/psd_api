namespace psd_api.Services
{
    public static class FileReader
    {
        
        public static async Task<FileStream> ReadFileStream(string path)
        {
            byte[] result;
            FileStream sourceStream;
            using (sourceStream = new FileStream(path,FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
            {
                result = new byte[sourceStream.Length];
                var readAsync = await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
                
                sourceStream.Close();
                
                await sourceStream.DisposeAsync();
            }
            
            return sourceStream;
        }
        
        public static async Task<byte[]> ReadFileByte(string path)
        {
            byte[] result;
            FileStream sourceStream;
            using (sourceStream = new FileStream(path,FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
            {
                result = new byte[sourceStream.Length];
                var readAsync = await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
                
                sourceStream.Close();
                
                await sourceStream.DisposeAsync();
            }
            
            return result;
        }
    }
}