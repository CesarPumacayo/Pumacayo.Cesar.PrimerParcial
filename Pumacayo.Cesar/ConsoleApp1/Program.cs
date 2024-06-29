using Entidades;
internal class Program
{
    static void Main(string[] args)
    {
        AccesoBaseDatos ado = new AccesoBaseDatos();

        if (ado.ProbarConexion())
        {
            Console.WriteLine("Se conectó!!!");
        }
        else
        {
            Console.WriteLine("No se conectó.");
        }
    }
}