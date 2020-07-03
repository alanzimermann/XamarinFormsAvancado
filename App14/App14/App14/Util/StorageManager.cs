using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
namespace App14.Util
{
    public class StorageManager
    {
        public async static void SalvarArquivo(string fileName, string conteudo)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("arquivos", CreationCollisionOption.OpenIfExists);
            
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(conteudo);
        }
        public async static Task<string> LerArquivo(string fileName)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("arquivos", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync(fileName);

            return await file.ReadAllTextAsync();
        }
    }
}
