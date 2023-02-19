using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationGenerator.Tests;

public class BaseTest
{

    public static string ProjectDirectory => Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;

    public static Assembly CurrentAssembly => typeof(BaseTest).Assembly;


    
}
