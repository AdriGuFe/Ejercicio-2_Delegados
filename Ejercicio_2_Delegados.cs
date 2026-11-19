using System;

delegate int Operacion(int a, int b);
delegate int Operar(int a, int b);
delegate int OperacionArray(int[] numeros);
delegate int Transformar(int numero);
delegate int OperacionCallback(int a, int b);
delegate double Calculo(double numero);

class Program
{
    static int Sumar(int a, int b)
    {
        return a + b;
    }

    static int Restar(int a, int b)
    {
        return a - b;
    }

    static int Multiplicar(int a, int b)
    {
        return a * b;
    }

    static int Dividir(int a, int b)
    {
        return a / b;
    }

    static void EjecutarYMostrar(Operacion operacion, int a, int b)
    {
        Console.WriteLine($"Resultado: {operacion(a, b)}");
    }

    static int Suma(int a, int b)
    {
        return a + b;
    }

    static int Resta(int a, int b)
    {
        return a - b;
    }

    static int Multiplicacion(int a, int b)
    {
        return a * b;
    }

    static int SumaArray(int[] numeros)
    {
        int suma = 0;
        for (int i = 0; i < numeros.Length; i++)
        {
            suma += numeros[i];
        }
        return suma;
    }

    static int MultiplicarArray(int[] numeros)
    {
        int producto = 1;
        for (int i = 0; i < numeros.Length; i++)
        {
            producto *= numeros[i];
        }
        return producto;
    }

    static int Doblar(int numero)
    {
        return numero * 2;
    }

    static int Triplicar(int numero)
    {
        return numero * 3;
    }

    static int Cuadrado(int numero)
    {
        return numero * numero;
    }

    static int EjecutarOperacion(OperacionCallback operacion, int a, int b)
    {
        return operacion(a, b);
    }

    static double RaizCuadrada(double numero)
    {
        if (numero < 0)
        {
            throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo");
        }
        return Math.Sqrt(numero);
    }

    static double Logaritmo(double numero)
    {
        if (numero <= 0)
        {
            throw new ArgumentException("No se puede calcular el logaritmo de un número menor o igual que cero");
        }
        return Math.Log(numero);
    }

    static void EjecutarCalculo(Calculo calculo, double numero)
    {
        try
        {
            Console.WriteLine($"{calculo.Method.Name}: {calculo(numero)}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Main()
    {
        Console.Write("Introduce el primer número: ");
        int numero1 = int.Parse(Console.ReadLine());
        Console.Write("Introduce el segundo número: ");
        int numero2 = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Ejercicio 1");
        Operacion operacion1 = Sumar;
        Console.WriteLine($"Suma: {operacion1(numero1, numero2)}");
        Console.WriteLine();

        Console.WriteLine("Ejercicio 2");
        Operacion operacion2 = Sumar;
        operacion2 += Restar;
        foreach (Operacion metodo in operacion2.GetInvocationList())
        {
            Console.WriteLine($"{metodo.Method.Name}: {metodo(numero1, numero2)}");
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 3");
        Operacion operacion3 = Sumar;
        operacion3 += Restar;
        operacion3 += Multiplicar;
        foreach (Operacion metodo in operacion3.GetInvocationList())
        {
            Console.WriteLine($"{metodo.Method.Name}: {metodo(numero1, numero2)}");
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 4");
        Operacion operacion4 = Sumar;
        operacion4 += Restar;
        operacion4 += Multiplicar;
        operacion4 += Dividir;
        foreach (Operacion metodo in operacion4.GetInvocationList())
        {
            try
            {
                Console.WriteLine($"{metodo.Method.Name}: {metodo(numero1, numero2)}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"{metodo.Method.Name}: no se puede dividir entre cero");
            }
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 5");
        Console.Write("Sumar - ");
        EjecutarYMostrar(Sumar, numero1, numero2);
        Console.Write("Restar - ");
        EjecutarYMostrar(Restar, numero1, numero2);
        Console.Write("Multiplicar - ");
        EjecutarYMostrar(Multiplicar, numero1, numero2);
        Console.WriteLine();

        Console.WriteLine("Ejercicio 6");
        Operar operar = Suma;
        operar += Resta;
        operar += Multiplicacion;
        foreach (Operar metodo in operar.GetInvocationList())
        {
            Console.WriteLine($"{metodo.Method.Name}: {metodo(numero1, numero2)}");
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 7");
        int[] valores = { 2, 4, 6, 8 };
        OperacionArray operacionArray = SumaArray;
        operacionArray += MultiplicarArray;
        foreach (OperacionArray metodo in operacionArray.GetInvocationList())
        {
            Console.WriteLine($"{metodo.Method.Name}: {metodo(valores)}");
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 8");
        Console.Write("Introduce un número: ");
        int numeroTransformar = int.Parse(Console.ReadLine());
        Transformar transformar = Doblar;
        transformar += Triplicar;
        transformar += Cuadrado;
        foreach (Transformar metodo in transformar.GetInvocationList())
        {
            Console.WriteLine($"{metodo.Method.Name}: {metodo(numeroTransformar)}");
        }
        Console.WriteLine();

        Console.WriteLine("Ejercicio 9");
        Console.WriteLine($"Suma: {EjecutarOperacion(Suma, numero1, numero2)}");
        Console.WriteLine($"Resta: {EjecutarOperacion(Resta, numero1, numero2)}");
        Console.WriteLine($"Multiplicar: {EjecutarOperacion(Multiplicar, numero1, numero2)}");
        Console.WriteLine();

        Console.WriteLine("Ejercicio 10");
        Console.Write("Introduce un número: ");
        double numeroCalculo = double.Parse(Console.ReadLine());
        EjecutarCalculo(RaizCuadrada, numeroCalculo);
        EjecutarCalculo(Logaritmo, numeroCalculo);
    }
}
