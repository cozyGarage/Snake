# Snake
Snake game
Snake will be present on a grid
![image](https://user-images.githubusercontent.com/9263674/235168735-0e7b06b0-82f0-44cc-b322-8a386584b188.png)
During the course of the game, some position will be occupied by the snake and one position will be occupied by food.
![image](https://user-images.githubusercontent.com/9263674/235169235-2cc98971-b4ed-4a5d-9f66-90a1c80908c5.png)
Mapping the top left corner in [0,0] position.
![image](https://user-images.githubusercontent.com/9263674/235169913-c3f53686-ba23-4693-aea6-f702a17cfe79.png)
The grid will be presented with 2 dimensional arrays.
Empty space will be presented with value 0.
Snake will be presented with value 1.
Food will be presented with value 2.

##ENUM:
an enum is a data type that allows you to define a set of named values. A public enum is an enum that is accessible from any code that can access the class or namespace in which it is defined.
For example: 
public enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

DaysOfWeek myDay = DaysOfWeek.Monday;


##readonly
In programming, readonly is a keyword that is used to indicate that a variable or field can only be assigned a value once, either at initialization or in a constructor, and cannot be modified thereafter.

Here is an example of using the readonly keyword in C#:

csharp
Copy code
public class MyClass
{
    public readonly int MyReadOnlyField;

    public MyClass(int value)
    {
        MyReadOnlyField = value;
    }
}
In this example, we have a class MyClass with a readonly field MyReadOnlyField. This field can only be assigned a value once, either at initialization or in a constructor, and can't be modified thereafter.

One use case for readonly is to create immutable objects, which are objects whose state cannot be changed once they are created. This can be useful for creating objects that are safe to pass around between different parts of your code without worrying about them being modified unexpectedly.

Another use case for readonly is to optimize performance. Since readonly fields cannot be modified, the compiler can optimize the code that uses them, making it more efficient.

Overall, readonly is a useful keyword for creating immutable objects and optimizing performance in your code.

Add more code!
