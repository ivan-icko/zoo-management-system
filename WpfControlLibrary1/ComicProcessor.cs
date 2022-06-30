using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Server.Main
{
    public class ComicProcessor
    {



        public static async Task<ComicModel> LoadCommic(int comicNumber = 0)//async kako ne bi zavisila od performansi servera
        {
            string url = "";
            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            //omogucuje slanje novih zahteva dok cekamo trenutni
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    //prevodi json u objekat klase ComicModel (samo one vrednosti koje postoje kao property u klasi ComicModel)

                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}