using Aspose.PSD;
namespace psd_merge.Services
{
    public interface IInitial
    {
        void Initialization();
    }

    public class Initial : IInitial
    {
        public Initial()
        {
            Initialization();
        }

        public void Initialization()
        {
            License license = new License();

            license.SetLicense(LicensePath);
        }

        private string LicensePath { get; } = $"/Users/moe/Documents/Work/AND/POCs/psd_api/psd_api/services/psd_merge/Aspose.PSD.NET.lic";
    
    }
}