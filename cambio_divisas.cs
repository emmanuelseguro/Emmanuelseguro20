//creamos el diccionario de monedas con sus valores actuales y porcentajes de intermediación
Dictionary<string, (double valor, double porcentaje) > moneda = new Dictionary<string, (double, double)>
{
{"GBP", (5296, 0.04)},
{"EUR", (4500, 0.09)},
{"USD", (4021, 0.11)},
{"JPY", (27.85, 0.06)},
{"COP", (1,0)}
};

for (int i = 0; i < 5; i++)
{
//le damos la bienvenida al usuario y le pedimos que ingrese los datos para el cambio de divisa
Console.WriteLine("Hola, Bienvenido al programa de cambio de divisas del Banco WCG");
Console.WriteLine("Ingrese su nombre y apellido: ");
string nombre = Console.ReadLine();
Console.WriteLine("Ingrese su documento de identidad: ");
int Documento_Identidad = int.Parse(Console.ReadLine());

//le pedimos al usuario que ingrese la moneda de origen y imprimimos su respuesta
Console.WriteLine("GBP = (Libra esterlina)");
Console.WriteLine("EUR = (Euro)");
Console.WriteLine("USD = (Dólar estadounidense)");
Console.WriteLine("JPY = (Yen japonés)");
Console.WriteLine("COP = (Peso colombiano)");
Console.Write("Ingrese la moneda origen: ");
string moneda_origen = (Console.ReadLine()).ToUpper();

//le pedimos al usuario que ingrese la moneda de destino y imprimimos su respuesta
Console.WriteLine("GBP = (Libra esterlina)");
Console.WriteLine("EUR = (Euro)");
Console.WriteLine("USD = (Dólar estadounidense)");
Console.WriteLine("JPY = (Yen japonés)");
Console.WriteLine("COP = (Peso colombiano)");
Console.Write("Ingrese la moneda destino: ");
string moneda_destino = (Console.ReadLine()).ToUpper();;

//hacemos una condicion, si la moneda origen o de destino no existe, se le hace saber a los usuarios
if (!moneda.ContainsKey(moneda_origen)|| !moneda.ContainsKey(moneda_destino)) 
{
    Console.WriteLine("Moneda no valida intente de nuevo");
    continue; 
}

//se hace el proceso de la operacion para el cambio de divisas
Console.Write($"Ingrese la cantidad a cambiar en {moneda_origen}: $");
double Cantidad = Double.Parse(Console.ReadLine());

double valor_moneda_origen = moneda[moneda_origen].valor;
double valor_moneda_destino = moneda[moneda_destino].valor;
double intermediacion = moneda[moneda_destino].porcentaje;
double cantidad_convertida = (valor_moneda_origen/valor_moneda_destino)*Cantidad;
double cantidad_intermediación_pesos = (Cantidad * intermediacion);
double cantidad_intermediación = (cantidad_convertida * intermediacion);
double Total_conversion = cantidad_convertida - cantidad_intermediación;
double porcentaje_limite = 0.10;


/*hacemos otra condicion,  si al cambiar a la moneda más comercial el porcentaje de intermediación 
supera el 10% del dinero expresado en pesos colombianos se deberá preguntar al usuario si desea hacer 
el cambio; si está de acuerdo mostrar los datos,  si no está de acuerdo, la operación de cambio se cancela. */

if (cantidad_intermediación > (cantidad_convertida * porcentaje_limite))
{
Console.WriteLine("El porcentaje de intermediación supera el 10% del dinero.");
Console.Write("¿Desea continuar con el cambio? (S/N): ");
string respuesta = Console.ReadLine().ToUpper();
if (respuesta != "S")
{
Console.WriteLine("Operación de cambio cancelada.");
return;
}
}


//se muestran los datos
Console.WriteLine($"Usuario: {nombre}");
Console.WriteLine($"Documento de identidad: {Documento_Identidad}");
Console.WriteLine($"Moneda origen: {moneda_origen}");
Console.WriteLine($"Moneda destino: {moneda_destino}");
Console.WriteLine($"Porcentaje de intermediación: {intermediacion}%");
Console.WriteLine($"Cantidad convertida: ${cantidad_convertida}"+$"{moneda_destino}");
Console.WriteLine($"Intermediacion: ${cantidad_intermediación_pesos}"+"COP");
Console.WriteLine($"total de la conversion: ${Total_conversion}"+$"{moneda_destino}");
}
            

