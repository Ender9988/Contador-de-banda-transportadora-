# Contador-de-banda-transportadora-
El proyecto consiste en desarrollar un sistema de conteo de artículos que pasan por una banda transportadora. Este sistema utilizará un sensor para detectar cuándo un artículo pasa por él, y a medida que los artículos pasan, el contador se incrementará. Además, se implementará una interfaz de usuario creada en Visual Basic C# que permitirá al usuario reiniciar el contador o ver el número actual de artículos contados.

Interfaz de Usuario: 
La interfaz gráfica de usuario está desarrollada en Visual Basic. Esta interfaz proporciona una manera intuitiva para que el usuario interactúe con el sistema. A través de esta interfaz, los usuarios pueden visualizar de forma clara y precisa el número actual de artículos contados, así como realizar acciones como reiniciar el contador con un simple clic.

Hardware: 
El sistema hace uso de un microcontrolador Bluepill, que es una placa de desarrollo basada en el microcontrolador STM32 de STMicroelectronics. Se encarga de recibir las señales del sensor de detección de artículos y procesarlas para incrementar el contador de manera adecuada. 

Comunicación: 
Establece la comunicación entre el microcontrolador y la interfaz de usuario a través de un puerto serial. De esta manera, la interfaz de usuario puede enviar comandos de configuración al microcontrolador y recibir datos de estado del sistema para mostrarlos al usuario en tiempo real.
