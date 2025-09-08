// PizzaParty App

// declare global constants
const double SLICE_SIZE = 14.125;
const int SLICES_PER_PERSON = 4;

Console.WriteLine();
Console.WriteLine("*** Pizza Party ***");
Console.WriteLine();

int people = 0;

while (true)
{
    Console.Write("Enter the number of people attending the party: ");
    bool isValid = int.TryParse(Console.ReadLine(), out people);

    if (isValid && people >= 3)
    {
        break;
    }
    else
    {
        Console.Write("Error: Enter a number greater than or equal to 3.\n\n");
    }
}

int diameter = 0;
while (true)
{
    Console.Write("Enter the size of the pizza in inches (14, 16, 18): ");
    bool isValid = int.TryParse(Console.ReadLine(), out diameter);

    if (isValid && (diameter == 14 || diameter == 16 || diameter == 18))
    {
        break;
    }
    else
    {
        Console.Write("Error: Enter a valid pizza size.\n\n");
    }
}

// display the number of pizzas to purchase
Console.WriteLine();
Console.WriteLine("You should purchase " + CalculatePizzas(people, diameter) + " pizzas.");

// function to calculate the number of pizzas
double CalculatePizzas(int people, int diameter)
{
    // calculate the radius of the pizza
    double radius = diameter / 2;

    // calculate the area of one pizza
    double area = Math.PI * Math.Pow(radius, 2);

    // calculate the number of slices per pizza
    double slices = area / SLICE_SIZE;

    // calculate the total number of slices needed
    double total = people * SLICES_PER_PERSON;

    // calculate the pizzas required
    double required = Math.Ceiling(total / slices);

    return required;
}




