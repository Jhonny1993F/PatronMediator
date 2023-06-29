using System;
using System.Collections.Generic;

// Interfaz del mediador
public interface IMediator
{
    void EnviarMensaje(string mensaje, Colaborador remitente);
}

// Clase mediador concreto
public class Mediador : IMediator
{
    private List<Colaborador> _colaboradores = new List<Colaborador>();

    public void AgregarColaborador(Colaborador colaborador)
    {
        _colaboradores.Add(colaborador);
    }

    public void EnviarMensaje(string mensaje, Colaborador remitente)
    {
        foreach (var colaborador in _colaboradores)
        {
            // No envía el mensaje al remitente original
            if (colaborador != remitente)
                colaborador.RecibirMensaje(mensaje);
        }
    }
}

// Clase colaborador
public class Colaborador
{
    private IMediator _mediador;
    public string Nombre { get; set; }

    public Colaborador(IMediator mediador, string nombre)
    {
        _mediador = mediador;
        Nombre = nombre;
    }

    public void EnviarMensaje(string mensaje)
    {
        Console.WriteLine($"[{Nombre}] envía mensaje: {mensaje}");
        _mediador.EnviarMensaje(mensaje, this);
    }

    public void RecibirMensaje(string mensaje)
    {
        Console.WriteLine($"[{Nombre}] recibe mensaje: {mensaje}");
    }
}

// Ejemplo de uso
public class Program
{
    public static void Main(string[] args)
    {
        // Crear el mediador
        Mediador mediador = new Mediador();

        // Crear los colaboradores
        Colaborador colaborador1 = new Colaborador(mediador, "Colaborador 1");
        Colaborador colaborador2 = new Colaborador(mediador, "Colaborador 2");
        Colaborador colaborador3 = new Colaborador(mediador, "Colaborador 3");

        // Agregar los colaboradores al mediador
        mediador.AgregarColaborador(colaborador1);
        mediador.AgregarColaborador(colaborador2);
        mediador.AgregarColaborador(colaborador3);

        // Enviar mensajes
        colaborador1.EnviarMensaje("Hola a todos");
        colaborador2.EnviarMensaje("Hola Colaborador 1");
    }
}
