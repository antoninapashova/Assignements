
using DelegatesProject;
using DelegatesProject.Extensions;

Planet[] planets = new[]
{
    new Planet {Name = "Mars", DaysAroundTheSum=298, MinDegrees=-120, MaxDegrees=21, WaterPercentage=0.15, OxygenPercentage=0.1},
    new Planet {Name = "Jupiter", DaysAroundTheSum=4_333, MinDegrees=-134, MaxDegrees=-134, WaterPercentage=56, OxygenPercentage=0.3},
    new Planet {Name = "Venus", DaysAroundTheSum=415, MinDegrees=-120, MaxDegrees=21, WaterPercentage=0.0, OxygenPercentage=0.1}
};

foreach(var planet in planets)
{
    planet.Analyze();
   (planet as IPlanetExtender).ClearFormatting();
}
Action<int, string> myAction = TestMethod;

Func<Action,int, int, int, string> myFuncDelegate = CalculateVolume;
DelegateExecutor(myFuncDelegate);


void DelegateExecutor(Delegate myDelegate)
{
    Console.WriteLine("");
   
    Console.WriteLine(myDelegate.DynamicInvoke(1,2,3));
}
    
void TestMethod(int number, string text)
{

}
string CalculateVolume( Action ac,int x, int y, int z)
{
    ac();
    return (x * y * z).ToString();

} 
void NewRandomMethod()
{
    Console.WriteLine("Hello agag");
}

void MethodWithParams(int x, int y)
{

}