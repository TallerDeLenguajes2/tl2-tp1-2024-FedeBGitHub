# Respuestas
## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
- La relacion por **composicion** es la de Pedidos con Cliente, ya que cliente depende de la existencia de un pedido para existir.

- Las **relaciones** por agregación son Cadetes y Pedidos ya que un pedido puede reasignarese a otro cadete por lo tantos los pedidos son independientes.

Estoy en duda con los cadetes, se me hace que los cadetes tambien es una relacion por composicion ya que si no existe la cadeteria entonces no existen los clientes.

## ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
### Cadeteria:
- `TomarPedido();`
- `PrepararPedido();`
- `ContratarCadete();`
- `DespedirCadete();`
    
### Cadete: 
- `EntregarPedido();`
- `CobrarPedido();`

## Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

**Clase Cliente**

*Privados*
- Nombre
- Direccion
- Telefono
- DatosReferenciaDireccion

**Clase Pedidos**

*Privados*
- Nro
- Obs
- Cliente
- Estado

*Publicos*
- VerDireccionCliente()
- VerDatosCliente()

**Clase Cadete**

*Privados*
- Id
- Nombre
- Direccion
- Telefono
- ListadoPedidos

*Publicos*
- JornalACobrar()

**Clase Cadeteria**

*Privados*
- Nombre
- Telefono
- ListadoCadetes

*Publicos*

**Metodos agregados**
- TomarPedido();
- PrepararPedido();
- DespacharPedido();
- ContratarCadete();
     
- EntregarPedido();
- CobrarPedido();

## ¿Cómo diseñaría los constructores de cada una de las clases?
```csharp
public Cliente (string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion)
        {
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
            datosReferenciaDireccion = DatosReferenciaDireccion;
        }

public Pedido (int Nro, string Obs, string Estado , string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion)
        {
            nro = Nro;
            obs = Obs;
            Cliente cliente = new Cliente ( Nombre, Direccion, Telefono,  DatosReferenciaDireccion);
            estado = Estado;
        }

public Cadete(int Id, string Nombre, string Direccion, string Telefono, List<Pedido> ListaPedidos)
        {
            id = Id;
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
            listaPedidos = ListaPedidos;
        }

public Cadeteria (string Nombre, string Telefono, List<Cadete> ListaCadetes)
        {
            nombre = Nombre;
            telefono = Telefono;
            listaCadetes = ListaCadetes;
        }
```

## ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
...