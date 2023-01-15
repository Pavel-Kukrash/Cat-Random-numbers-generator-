
// numbers of dogs + cat speed

int dog = Random(2, 7); 
int scat = Random(7, 13);

// set of random numbers needed for coordinate (2 (for cat's coordinates) + 2 (for tree) + 2 * dogs)
int num = 2 + 2 + 2 * dog;

int[] arr = new int[num];
for (int i = 0; i < num; i++)
{
 var rRange = Random(0, 20);
 arr[i] = rRange;
}

// speed generation for every dog
int[] arr1 = new int[dog];
for (int i = 0; i < dog; i++)
{
    int sdog = Random(5, 15);
    arr1[i] = sdog;
}

Console.WriteLine("Hello, find the right answer if a cat is able to escape from dogs\n");
Console.WriteLine("Find an primary information below\n");
Console.WriteLine($"Cat coordinates are ({arr[0]} , {arr[1]}) and speed is {scat} ");
Console.WriteLine($"Tree coordinates are ({arr[2]} , {arr[3]}) \n");
Console.WriteLine($"Cat is surrounded by {dog} dogs");


// dog's block
int count = 4; // cat and tree coordinate require 4 numbers, other - for dogs
for (int i = 1; i <= dog; i++)
{      
    Console.WriteLine($"Coordinate of {i} dog is ({arr[count]} , {arr[count+1]}) and speed is {arr1[i-1]}");
    count+=2; // for every coordinate we need 2 numbers     

}

Console.WriteLine(" ");

Console.WriteLine("Please write your solution whether cat will be able to escape (Y/N)");
char answer = (char)Console.Read();

Console.WriteLine(" ");
Console.WriteLine("Solution \n");

// solution block

//time that cat need to achieve tree
double catt1 = Result(arr[0], arr[2], arr[1], arr[3], scat);

// time that dogs need to achieve tree
double[] dogt = new double[dog];

int count1 = 4;
for (int i = 0; i < dog; i++)
{
    dogt[i] = Result(arr[count1], arr[2], arr[count1+1], arr[3], arr1[i]);
    count += 2;
    Console.WriteLine($" {i+1} dog can reach a tree for {dogt[i]} min ");
}

Console.WriteLine($"Cat can reach a tree for {catt1} min \n");

//matching the time needed cat and doogs to reach a tree

if (dogt.Min()<=catt1)
{
    Console.WriteLine("Sorry, cat will be cought ");
    string answ1 = answer.Equals('Y') ? "Your answer is false" : "Correct";
    Console.WriteLine(answ1);
}
else
{
    Console.WriteLine("Cat will be able to escape :)");
    string answ2 = answer.Equals('N') ? "Your answer is false" : "Correct";
    Console.WriteLine(answ2);
}

// Methods

static int Random(int rand1, int rand2)
{
    var res = new Random();
    int result = res.Next(rand1, rand2);

    return result;
    }

 static double Result(double x,double x1, double y, double y1, int speed)
{
    double result = Math.Sqrt(Math.Abs((Math.Pow(x - x1, 2)) - (Math.Pow(y - y1, 2))));
    result = Math.Round(result, 2);
    double final = Math.Round(result / speed, 2);

    return final;
    
}

Console.ReadKey();
