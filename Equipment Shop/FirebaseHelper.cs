using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Shop
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient(GlobalData.firebaseDatabase);

        public async Task<List<Merchandise>> GetAllMerchandise()
        {
            List<Merchandise> merchs = null;
            var task = await firebase.Child("Merchandise").OnceAsync<Merchandise>();
            Debug.WriteLine("Number of records: " + task.Count);
            string name = task.First().Key;
            Debug.WriteLine("Number of records: " + name);
            try
            {
                merchs = (await firebase
                     .Child("Merchandise") 
                     .OnceAsync<Merchandise>())
                     .Select(item =>
                     {
                         Debug.WriteLine("Merchandise ID: " + item.Key.ToString());
                         return new Merchandise
                         {
                             MerchandiseID = item.Key.ToString(),
                             Name = item.Object.Name,
                             Type = item.Object.Type,
                             Price = item.Object.Price,
                             ImageURL = item.Object.ImageURL,
                         };
                     }).ToList();
                
            }
            catch (FirebaseException firebaseException)
            {
                Debug.WriteLine(firebaseException.Message);
            }
            return merchs;
        }

        public async Task CreateNewMerch(string name, string type, string price, string imageURL)
        {
            Merchandise newMerch = new Merchandise { Name = name, Type = type, Price = price , ImageURL = imageURL};

            var Result = await firebase.Child("Merchandise").PostAsync(new Merchandise { Name = name, Type = type, Price = price, ImageURL = imageURL });
        }

        public async Task UpdateItem(string name, string type, string price, string imageurl)
        {
            var toUpdateItem = (await firebase
              .Child("Merchandise")
              .OnceAsync<InsertUpdateMerch>()).Where(a => a.Object.Name == name).FirstOrDefault();

            string key = toUpdateItem.Key;
            toUpdateItem.Object.ImageURL = imageurl;
            toUpdateItem.Object.Name = name;
            toUpdateItem.Object.Type = type;
            toUpdateItem.Object.Price = price;

            await firebase
             .Child("Merchandise")
             .Child(key)
             .PutAsync(JsonConvert.SerializeObject(toUpdateItem.Object));
        }

        public async Task DeleteItem(string name)
        {
            var toDeleteItem = (await firebase
              .Child("Merchandise")
              .OnceAsync<Merchandise>()).Where(a => a.Object.Name == name).FirstOrDefault();

            string key = toDeleteItem.Key;

            await firebase.Child("Merchandise").Child(toDeleteItem.Key).DeleteAsync();

        }
    }
}
