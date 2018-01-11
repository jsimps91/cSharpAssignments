using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            // var artists = Artists.Select(a => a.ArtistName).Where(x => x[0] == 'L');
            // foreach(var artist in artists)
            // {
            //     System.Console.WriteLine(artist);
            // } 
          
            // System.Console.WriteLine(mtVernon.ArtistName);
            // System.Console.WriteLine(mtVernon.Age);
            

            //Who is the youngest artist in our collection of artists?

            // var youngest = Artists.OrderBy(artist => artist.Age).First();
            // System.Console.WriteLine(youngest.ArtistName);
            // System.Console.WriteLine(youngest.Age);

            //Display all artists with 'William' somewhere in their real name

            //  var william = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            //  foreach(var artist in william)
            //  {
            //      System.Console.WriteLine(artist.ArtistName);
            //  }

            //Display all groups with names less than 8 characters in length.
            // var lessThanEight = Groups.Where(group => group.GroupName.Length < 8).ToList();
            // foreach(var group in lessThanEight)
            // {
            //     System.Console.WriteLine(group.GroupName);
            // }

            //Display the 3 oldest artist from Atlanta

            // var atlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderBy(artist => artist.Age).ToList();
            // System.Console.WriteLine(atlanta[0].ArtistName);
            // System.Console.WriteLine(atlanta[0].Age);
            // System.Console.WriteLine(atlanta[1].ArtistName);
            // System.Console.WriteLine(atlanta[1].Age);
            // System.Console.WriteLine(atlanta[2].ArtistName);
            // System.Console.WriteLine(atlanta[2].Age);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            // var notFromNewYork = Groups.Join(Artists, group => group.Id, artist => artist.GroupId, (group, artist) => {
            //     if(artist.Hometown != "New York City")
            //     {
            //         return group.GroupName;
            //     }
            //     else
            //     {
            //         return null;
            //     }
            // }).ToList().Distinct();

        
            
            // foreach(var group in notFromNewYork)
            // {
            //     System.Console.WriteLine(group);
            // }
            

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'



            // var wuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan").Join(Artists, g => g.Id, a => a.GroupId, (g, a) =>
            // {
            //    return a.ArtistName;
            // }).ToList();

            // foreach(var rapper in wuTang)
            // {
            //     System.Console.WriteLine(rapper);
            // }
      
        }
    }
}
