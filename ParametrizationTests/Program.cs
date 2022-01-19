using System;
using System.Linq;
using AndreasMichelis.Parametrization;
using AndreasMichelis.Parametrization.Reflection;
using ParametrizationTests.paramObjects;

namespace ParametrizationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
################################################################
### Checking if the created types are parametric ###############
################################################################");
            Console.WriteLine("ParObj1: " + typeof(ParObj1).IsParametric());
            Console.WriteLine("ParObj2: " + typeof(ParObj2).IsParametric());
            Console.WriteLine("ParObj3: " + typeof(ParObj3).IsParametric());
            Console.WriteLine("ParObj4: " + typeof(ParObj4).IsParametric());
            Console.WriteLine("ParObj5: " + typeof(ParObj5).IsParametric());

            
            Console.WriteLine(@"
################################################################
### Getting the parameters of ParObj1 ##########################
################################################################");
            
            Console.WriteLine(string.Join(
                "------------------\n" , 
                typeof(ParObj1).GetParameters()?.Select(x => $"Name: {x.Name}\nDefault Value: \"{x.DefaultValue}\"\nDescription: {x.Description}\n") ?? Array.Empty<string>()));

            Console.WriteLine(@"
################################################################
### Getting the parameters of ParObj2 ##########################
################################################################");

            Console.WriteLine(string.Join(
                "------------------\n" , 
                typeof(ParObj2).GetParameters()?.Select(x => $"Name: {x.Name}\nDefault Value: \"{x.DefaultValue}\"\nDescription: {x.Description}\n") ?? Array.Empty<string>()));
            
            Console.WriteLine(@"
################################################################
### Getting the parameters of ParObj3 ##########################
################################################################");

            Console.WriteLine(string.Join(
                "------------------\n" , 
                typeof(ParObj3).GetParameters()?.Select(x => $"Name: {x.Name}\nDefault Value: \"{x.DefaultValue}\"\nDescription: {x.Description}\n") ?? Array.Empty<string>()));

            Console.WriteLine(@"
################################################################
### Getting the parameters of ParObj4 ##########################
################################################################");
            
            Console.WriteLine(string.Join(
                "------------------\n" , 
                typeof(ParObj4).GetParameters()?.Select(x => $"Name: {x.Name}\nDefault Value: \"{x.DefaultValue}\"\nDescription: {x.Description}\n") ?? Array.Empty<string>()));

            Console.WriteLine(@"
################################################################
### Getting the parameters of ParObj5 ##########################
################################################################");
            
            Console.WriteLine(string.Join(
                "------------------\n" , 
                typeof(ParObj5).GetParameters()?.Select(x => $"Name: {x.Name}\nDefault Value: \"{x.DefaultValue}\"\nDescription: {x.Description}\n") ?? Array.Empty<string>()));


            Console.WriteLine(@"
################################################################
### Creating a new ParObj1 #####################################
################################################################");

            ParametricObject obj = new ParObj1();
            
            Console.WriteLine("\n### Printing the default value of \"DefaultInt\" #################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultInt"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultInt")); 
            
            Console.WriteLine("\n### Setting the default value of \"DefaultInt\" ##################\n");

            obj.SetParameter("DefaultInt", 24);
            
            Console.WriteLine("\n### Printing the value of \"DefaultInt\" #########################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultInt"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultInt")); 
            
            Console.WriteLine("\n### Parsing the default value of \"DefaultInt\" ##################\n");
            obj.ParseParameter("DefaultInt", "32");
            
            Console.WriteLine("\n### Printing the value of \"DefaultInt\" #########################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultInt"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultInt")); 
            

            Console.WriteLine(@"
################################################################
### Creating a new ParObj2 #####################################
################################################################");

            obj = new ParObj2();
            
            Console.WriteLine("\n### Printing the default value of \"DefaultFloat\" ###############\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            
            Console.WriteLine("\n### Setting the default value of \"DefaultFloat\" ################\n");

            obj.SetParameter("DefaultFloat", 24.1f);
            
            Console.WriteLine("\n### Printing the value of \"DefaultFloat\" #######################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            
            Console.WriteLine("\n### Parsing the default value of \"DefaultFloat\" ################\n");
            obj.ParseParameter("DefaultFloat", "32.12");
            
            Console.WriteLine("\n### Printing the value of \"DefaultFloat\" #######################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            

            Console.WriteLine(@"
################################################################
### Creating a new ParObj4 #####################################
################################################################");

            obj = new ParObj4();
            
            Console.WriteLine("\n### Printing the default value of \"DefaultFloat\" ###############\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            
            Console.WriteLine("\n### Setting the default value of \"DefaultFloat\" ################\n");

            obj.SetParameter("DefaultFloat", 24.1f);
            
            Console.WriteLine("\n### Printing the value of \"DefaultFloat\" #######################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            
            Console.WriteLine("\n### Parsing the default value of \"DefaultFloat\" ################\n");
            obj.ParseParameter("DefaultFloat", "32.12");
            
            Console.WriteLine("\n### Printing the value of \"DefaultFloat\" #######################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultFloat"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultFloat")); 
            
            Console.WriteLine(@"
################################################################
### Creating a new ParObj5 #####################################
################################################################");

            obj = new ParObj5();
            
            Console.WriteLine("\n### Printing the default value of \"DefaultString\" ##############\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultString"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultString")); 
            
            Console.WriteLine("\n### Setting the default value of \"DefaultString\" ###############\n");

            obj.SetParameter("DefaultString", "Test string 1");
            
            Console.WriteLine("\n### Printing the value of \"DefaultString\" #####################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultString"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultString")); 
            
            Console.WriteLine("\n### Parsing the default value of \"DefaultString\" ###############\n");
            obj.ParseParameter("DefaultString", "Test String 2");
            
            Console.WriteLine("\n### Printing the value of \"DefaultString\" ######################\n");

            Console.WriteLine("With GetParameter: " + obj.GetParameter("DefaultString"));
            Console.WriteLine("With SerializeParameter: " + obj.SerializeParameter("DefaultString")); 
        }
    }
}
