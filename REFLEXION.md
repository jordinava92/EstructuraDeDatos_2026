Markdown# Preguntas de Reflexión Final - Estructura de Datos

## 1. Sobre la estructura del árbol
**Orden de inserción:** 10, 5, 15, 3, 7, 12, 20

### Jerarquía del Árbol (Representación ASCII)
       10
     /    \
    5      15
   / \    /  \
  3   7  12  20
Altura del árbolLa altura del árbol resultante es 2 (contando desde la raíz hacia las hojas por niveles de aristas) o 3 niveles de nodos en total. Es un árbol perfectamente balanceado.2. Sobre la complejidad Big O Orden de inserción: 1, 2, 3, 4, 5, 6, 7Jerarquía del Árbol resultantePlaintext 1
  \
   2
    \
     3
      \
       4
        \
         5
          \
           6
            \
             7
Análisis de Complejidad

¿Por qué la búsqueda ya no es O(log n)? 
Porque al insertar los elementos en orden estrictamente creciente, cada nodo nuevo se convierte en el hijo derecho del anterior. El árbol no se bifurca, perdiendo su propiedad de división binaria. Para buscar el número 7, tenemos que recorrer todos los elementos uno por uno.Nombre del problema: El árbol se ha convertido en un Árbol Degenerado (funciona exactamente igual que una Lista Enlazada simple).

 Su complejidad de búsqueda pasa a ser de peor caso $O(n)$.Solución existente: Para evitar esto se utilizan árboles auto-balanceables, como los Árboles AVL o los Árboles Rojo-Negro, los cuales rotan sus nodos automáticamente al insertar datos para mantener una altura equilibrada y asegurar que la búsqueda siga siendo $O(\log n)$.3. 

Sobre la recursiónDiferencia entre Caso Base y Caso Recursivo en BuscarNodoCaso Base: Es la condición de parada. En la búsqueda, son las situaciones donde ya sabemos la respuesta inmediatamente sin necesidad de seguir buscando: cuando encontramos el nodo con el valor deseado (éxito) o cuando llegamos a un nodo nulo/vacío (el valor no existe en el árbol).Caso Recursivo: Es la parte donde el problema aún es muy grande y se divide en una versión más pequeña. Si el nodo actual no es el que buscamos, decidimos si avanzar hacia el subárbol izquierdo (si el valor buscado es menor) o al derecho (si es mayor), llamando de nuevo a la función.

¿Qué ocurriría si eliminas el caso base?Si eliminamos el caso base, la función no sabrá cuándo detenerse. Seguirá llamándose a sí misma infinitamente en la memoria.Error en tiempo de ejecución: Se producirá un error de StackOverflowException (Desbordamiento de Pila).

 La memoria asignada para las llamadas de funciones se llena por completo y el programa se congela o se cierra abruptamente.4. Sobre aplicaciones realesCaso 1: Sistemas de Archivos y Directorios en un Sistema OperativoJustificación: Las carpetas y archivos se organizan de forma jerárquica nativa. Buscar un archivo específico en un disco con millones de elementos mediante una lista ordenada requeriral mover bloques masivos de memoria al indexar. Un árbol binario estructurado permite descartar ramas enteras instantáneamente, logrando que el tiempo de acceso sea casi inmediato con $O(\log n)$.
 
 Caso 2: Tablas de enrutamiento de Redes (Routers de Internet)Justificación: Los routers necesitan decidir a qué IP enviar un paquete de datos en microsegundos analizando millones de prefijos de red disponibles. Utilizar una lista ordenada implicaría búsquedas lineales costosas o reordenamientos lentos ante cambios de red. El árbol binario de búsqueda permite encontrar la coincidencia de IP más larga de forma extremadamente eficiente, manteniendo el tráfico de internet fluido gracias a la velocidad de la escala logarítmica.