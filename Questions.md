# C# tricky interview Quetions

## Examples

- Math.Round() ==> uses two algorithms

  - Rounding away from zero
    Midpoint values are rounded to the next number away from zero. For example, 3.75 rounds to 3.8, 3.85 rounds to 3.9, -3.75 rounds to -3.8, and -3.85 rounds to -3.9. This form of rounding is represented by the MidpointRounding.AwayFromZero enumeration member.
    Rounding away from zero is the most widely known form of rounding.
  - Rounding to nearest, or banker's rounding (Rounding to nearest even number , most people don't know this)

  ```cs
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Math.Round(6.5)); //rounded to nearest even
            Console.WriteLine(Math.Round(11.5)); //rounded to nearest even
        }
    }

    // output : 6 and 12
  ```

- Byte struct (Represents an 8-bit unsigned integer. value 0-255)

  - _tip_ treat byte as sequence of bits rather as number
  - For signed Byte i.e. SByte range is -128 to 127.
  - ECMA-334 states that addition is only defined as legal on int+int, uint+uint, long+long and ulong+ulong (ECMA-334 14.7.4).
  - under the hood what happens is this

  ```cs
    byte z = x + y;
    //actually is
    byte z = (int) x + (int) y;
  ```

  ```cs
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            byte num = 100;
            dynamic val = num;
            Console.WriteLine(val.GetType()); // will give byte
            val += 100; // any mathmatical(+,-,*,/) operation on byte result into int
            // val = (byte)val+100; this will give byte as type
            Console.WriteLine(val.GetType()); // will give int or Int32
        }
    }
  ```

  - int[] it is treated as reference type
    - if array value assigned to other variable only ref is added but both original and new references are poiting to same object

  ```cs
    using System;
    public class Program
    {
      public static void Main(string[] args)
      {
          int[] arr = new int[]{1,10};
          int[] b = arr;
          b[1] =200;
          Console.WriteLine(arr[1]);
          b[1]=20;
          Console.WriteLine(arr[1]);
      }

      // output
      // 200
      // 20
    }
  ```

- How to create --> List of Delegates

  ```cs
    using System;
    using System.Collections.Generic;
    public class Program
    {
      public static void Main(string[] args)
      {
          string[] strings = { "abc", "def", "ghi" };
          var actions = new List<MyDelgate>();
          foreach (string str in strings)
            actions.Add(() => { Console.WriteLine(str); });

          foreach (var action in actions)
            action.Invoke(); // or simply call action()
      }

        public delegate void MyDelgate();
    }
  ```

- Using Delegates as function pointer / Event handler

  ```cs
    using System;
    using System.Collections.Generic;
    namespace TechBeamers
    {
        public delegate void sampleDelegate(int num);
        public class testDelegate
        {
        public void checkEven(int num)
        {
          if(num%2 ==0)
            Console.WriteLine("This number is an even number");
          else
            Console.WriteLine("This number is an odd number");
          }

          public void squareNumber(int num)
          {
            Console.WriteLine("Square of this number is: {0}", num*num);
          }
        }

        public class sample
        {
          public static void Main( )
          {
            testDelegate obj = new testDelegate();

            // delegate as anonymous method
            sampleDelegate delegateObj= delegate(int num)
              {
                Console.WriteLine("Entered number is : {0}",num);
              };

            // binding method/event handler to delegate
            delegateObj+= obj.checkEven;
            delegateObj += obj.squareNumber;

            // declaring method as lambda and binding to delegate
            delegateObj += (num)=>{Console.WriteLine(num);};
            delegateObj(25);
          }
        }
    }

  ```
