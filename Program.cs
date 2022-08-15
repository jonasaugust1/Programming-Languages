using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

        // foreach(var lang in languages){
        //     Console.WriteLine(lang.Prettify());
        // }

        var language = languages.Select(lan => $" Year: {lan.Year}\n Name: {lan.Name}\n Chief Developer: {lan.ChiefDeveloper}\n");

        // foreach(var lang in language){
        //     Console.WriteLine(lang);
        // }

        var cSharp = languages.Where(lang => lang.Name.Contains("C#")).Select(lang => lang.Prettify());
        // foreach(var lang in cSharp){
        //   Console.WriteLine(lang);
        // }

        var microsoft = languages.Where(lang => lang.ChiefDeveloper.Contains("Microsoft"));

        // foreach(var lang in microsoft){
        //   Console.WriteLine($"{lang.Prettify()}\n");
        // }
        
        var lispPredecessors = languages.Where(lang => lang.Predecessors.Contains("Lisp"));

        // foreach(var lang in lispPredecessors){
        //   Console.WriteLine($"{lang.Prettify()}\n");
        // }

        var scriptLangs = languages.Where(lang => lang.Name.Contains("Script"));
        
        // foreach(var lang in scriptLangs){
        //   Console.WriteLine($"{lang.Prettify()}\n");
        // }

        int numberOfLanguages = languages.Count;
        // Console.WriteLine(numberOfLanguages);

        var nearMilleniumLangs = languages.Where(lang => lang.Year >= 1995 && lang.Year <= 2005).Select(lang => $"{lang.Name} was invented in {lang.Year}");

        int numberOfNearMilleniumLangs = nearMilleniumLangs.Count();

        // Console.WriteLine(numberOfNearMilleniumLangs);

        // foreach(var lang in nearMilleniumLangs){
        //   Console.WriteLine($"{lang}\n");
        // }

      PrintAll(nearMilleniumLangs);
    }
    public static void PrintAll(IEnumerable<Language> languages){
      foreach(Language lang in languages){
        Console.WriteLine($"{lang.Prettify()}");
      }
    }

    public static void PrintAll(IEnumerable<Object> sequence){
      foreach(Object obj in sequence){
        Console.WriteLine(obj);
      }
    }
  }
}
