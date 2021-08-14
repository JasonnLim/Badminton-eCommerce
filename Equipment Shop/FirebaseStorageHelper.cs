using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Shop
{
    class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage(GlobalData.firebaseStorage);

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("Images")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }
    }
}
