# MVVM VIII Uso de IValueConverter para la transformación de datos en las vistas
Siguiendo con la serie de post de [**MVVM**](https://saturninopimentel.com/tag/mvvm/) en este post vamos a hablar de cómo trabajar con los **convertidores de datos**.
Los **convertidores de datos** son elementos que nos permiten hacer cambios en la forma en que son presentados los elementos en la vista, utilizarlos es realmente sencillo solo tenemos que hacer una implementación de **IValueConverter** que contiene dos métodos, **Converter** y **ConverterBack** el primero y el más comúnmente utilizado nos sirve para convertir datos de una propiedad en valores diferentes y funciona con el modo de notificación **OneWay**, el segundo por su parte nos permite regresar un valor a la propiedad en base al contenido de la propiedad del control que hayamos vinculado y funciona con el método **TwoWay**.
**IValueConverter** está ubicado en el espacio de nombres **System.Windows.Data**, veamos un ejemplo sencillo en el cual vamos a cambiar un mensaje y el color de las letras con base en si la edad proporcionada en un TextBox corresponde a alguien considerado mayor de edad o menor de edad (en México eres considerado un adulto a los 18 años). 

Primero vamos a crear una implementación de **IValueConverter** para hacer los cambios en el mensaje para lo cual usaremos el siguiente código.

```language-csharp
public class AgeToMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int valueResult = (int)value;
            return valueResult >= 18 ? "Mayor de edad" : "Menor de edad";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
```
Después crearemos la implementación para hacer el cambio de color también con base en la edad, verde para mayores de edad y rojo para menores de edad.
```language-csharp
 public class AgeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Green);
            int valueResult = (int)value;
            if (valueResult < 18)
            {
                brush.Color = Colors.Red;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
```
Ahora vamos a agregar un recurso en el archivo App.xaml, para esto tendremos que incluir el espacio de nombres donde se ubican nuestros **convertidores de datos**.
```language-csharp
xmlns:converters="using:MVVMConverters.Views.Converters"
```
Y después crearemos recursos para utilizar nuestros convertidores de datos.
```language-csharp
 <Application.Resources>
        <converters:AgeToColorConverter x:Key="AgeToColorConverter" />
        <converters:AgeToMessageConverter x:Key="AgeToMessageConverter" />
 </Application.Resources>
```
Con esto podremos utilizar nuestras implementaciones **IValueConverter** en todas las secciones de nuestra aplicación.

Por último haremos uso del convertidor **AgeToColorConverter** en la propiedad **Foreground** y el convertidor **AgeToMessageConverter** en la propiedad **Text** de nuestro control **TextBlock** que tienen un atado de datos con la propiedad Age por medio del identificador **Converter** en nuestra expresión de atado de datos indicando que se trata de un recurso.
```language-csharp
<TextBlock FontSize="20"
                   Foreground="{Binding Age,
                                        Converter={StaticResource AgeToColorConverter}}"
                   Text="{Binding Age,
                                  Converter={StaticResource AgeToMessageConverter}}" />
```
Con esto podrás ver resultados como los que se muestran a continuación.

![Converter1](https://saturninopimentel.com/content/images/2015/07/Converter1.png)
![Converter2](https://saturninopimentel.com/content/images/2015/07/Converter2.png)
Como podrás darte cuenta es muy sencillo hacer uso de los convertidores de datos, dejo el código de ejemplo en [github](https://github.com/Satur01/MVVMConverters), espero te resulte útil y te invito a leer los demás post de la serie de [**MVVM**](https://saturninopimentel.com/tag/mvvm/). Saludos!!
