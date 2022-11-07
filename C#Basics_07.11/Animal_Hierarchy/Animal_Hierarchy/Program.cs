using Animal_Hierarchy;

public class Program
{
public static void Main()
{
        Animal bird = new Bird("Eagle", 10);
        bird.move();
        bird.move(10);

        Animal mammal = new Mammal("Dog", 3);
        mammal.move(100);
        mammal.eat();
}

}
